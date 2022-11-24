using FluentAssertions;
using Moq;
using System.Security.Permissions;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto.LoanDto;
using TP_GSC_BackEnd.Entities;
using TP_GSC_BackEnd.Services;
using TP_GSC_BackEnd.Services.Loans;

namespace Test_GSC
{
    public class LoansServiceTests
    {
        private Mock<IUnitOfWork> uow = new Mock<IUnitOfWork>();

        [Fact]
        public void sholud_not_create_loan_with_AgreedReturnDate_in_the_past()
        {
            var target = new LoansService(uow.Object);

            var exaples_list = new List<CreateLoanDto>() {
                new CreateLoanDto() { AgreedReturnDate = DateTime.Now.AddSeconds(-1) },
                new CreateLoanDto() { AgreedReturnDate = DateTime.Now.AddMinutes(-1) },
                new CreateLoanDto() { AgreedReturnDate = DateTime.Now.AddDays(-1) },
                new CreateLoanDto() { AgreedReturnDate = DateTime.Now.AddMonths(-1) },
                new CreateLoanDto() { AgreedReturnDate = DateTime.Now.AddYears(-1) },
            };

            foreach(var dto in exaples_list) {
                var result = target.Create(dto);

                result.type.Should().Be(ServiceResultTypes.InvalidInput);
                uow.Verify(u => u.SaveChanges(), Times.Never);
            }
        }


        [Fact]
        public void should_return_error_when_thing_doesnt_exists() {

            uow.Setup(u => u.ThingsRepo.GetOne(1)).Returns<Thing>(null);
            var target = new LoansService(uow.Object);

            var dto = new CreateLoanDto() { ThingId = 1, AgreedReturnDate=DateTime.Now.AddDays(2) };
            var result = target.Create(dto);

            result.type.Should().Be(ServiceResultTypes.NotFound);
            uow.Verify(u => u.SaveChanges(), Times.Never);
        }

        [Fact]
        public void should_return_error_when_person_doesnt_exists()
        {
            uow.Setup(u => u.ThingsRepo.GetOne(1)).Returns(new Thing());
            uow.Setup(u => u.PeopleRepo.GetOne(20)).Returns<Person>(null);
            var target = new LoansService(uow.Object);

            var dto = new CreateLoanDto() { PersonId = 20, AgreedReturnDate = DateTime.Now.AddDays(2) };
            var result = target.Create(dto);

            result.type.Should().Be(ServiceResultTypes.NotFound);
            uow.Verify(u => u.SaveChanges(), Times.Never);
        }

        [Fact]
        public void should_not_loan_a_thing_that_is_already_loaned() {
            uow.Setup(u => u.ThingsRepo.GetOne(1)).Returns(new Thing());
            uow.Setup(u => u.PeopleRepo.GetOne(20)).Returns(new Person());
            
            var pending = new List<Loan>(){
                new Loan()
                {
                    Id = 200,
                    Thing = new Thing { Id = 1 },
                    AgreedReturnDate = DateTime.Now.AddDays(7),
                    RealReturnDate = null
                }
            };
            uow.Setup(u => u.LoansRepo.GetPendingLoans()).Returns(pending);


            var target = new LoansService(uow.Object);

            var dto = new CreateLoanDto() { ThingId = 1, PersonId=20, AgreedReturnDate = DateTime.Now.AddDays(2) };
            var result = target.Create(dto);

            result.type.Should().Be(ServiceResultTypes.BussinesLogicError);
            uow.Verify(u => u.SaveChanges(), Times.Never);
        }

        [Fact]
        public void should_create_a_loan_when_is_posible() {
            uow.Setup(u => u.ThingsRepo.GetOne(It.IsAny<int>())).Returns(new Thing());
            uow.Setup(u => u.PeopleRepo.GetOne(It.IsAny<int>())).Returns(new Person());

            var pending = new List<Loan>(){
                new Loan()
                {
                    Id = 200,
                    Thing = new Thing { Id = 1 },
                    AgreedReturnDate = DateTime.Now.AddDays(7),
                    RealReturnDate = null
                }
            };
            uow.Setup(u => u.LoansRepo.GetPendingLoans()).Returns(pending);


            var target = new LoansService(uow.Object);

            var dto = new CreateLoanDto() { ThingId = 99, PersonId = 20, AgreedReturnDate = DateTime.Now.AddDays(2) };
            var result = target.Create(dto);

            result.type.Should().Be(ServiceResultTypes.Ok);
            uow.Verify(u => u.LoansRepo.add(It.IsAny<Loan>()), Times.Once);
            uow.Verify(u => u.SaveChanges(), Times.Once);

        }





        [Fact]
        public void should_not_close_a_loan_that_doesnt_exist() {
            uow.Setup(u => u.LoansRepo.GetOne(It.IsAny<int>())).Returns<Loan>(null);
            var target = new LoansService(uow.Object);

            var result = target.Close(It.IsAny<int>());

            result.type.Should().Be(ServiceResultTypes.NotFound);
            result.error_message.Should().NotBeNullOrWhiteSpace();
            uow.Verify(u => u.SaveChanges(), Times.Never);
        }

        [Fact]
        public void should_not_close_loan_that_is_already_closed() {

            var dbLoan = new Loan()
            {
                RealReturnDate = DateTime.Now.AddDays(-1)
            };
            uow.Setup(u => u.LoansRepo.GetOne(It.IsAny<int>())).Returns(dbLoan);
            var target = new LoansService(uow.Object);

            var result = target.Close(It.IsAny<int>());

            result.type.Should().Be(ServiceResultTypes.BussinesLogicError);
            result.error_message.Should().NotBeNullOrWhiteSpace();
            uow.Verify(u => u.SaveChanges(), Times.Never);
        }

        [Fact]
        public void should_close_loan_if_posible() {
            var dbLoan = new Loan()
            {
                RealReturnDate = null
            };
            uow.Setup(u => u.LoansRepo.GetOne(It.IsAny<int>())).Returns(dbLoan);
            var target = new LoansService(uow.Object);

            var result = target.Close(It.IsAny<int>());

            result.type.Should().Be(ServiceResultTypes.Ok);
            result.body.Should().NotBeNull().And.BeEquivalentTo(dbLoan);
            uow.Verify(u => u.SaveChanges(), Times.Once);

        }



    }
}
