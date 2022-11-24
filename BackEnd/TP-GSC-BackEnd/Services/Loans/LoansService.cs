using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto.LoanDto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Services.Loans
{
   
    public class LoansService : ILoansService
    {
        private readonly IUnitOfWork Uow;

        public LoansService(IUnitOfWork uow) {
            this.Uow = uow;
        }


        public ServiceResult<Loan> Create(CreateLoanDto dto) {

            if (dto.AgreedReturnDate < DateTime.Now)
                return ServiceResult<Loan>.InvalidInput("invalid Date");

            var thing=Uow.ThingsRepo.GetOne(dto.ThingId);
            if (thing is null)
                return ServiceResult<Loan>.NotFound("Thing not found");

            var person=Uow.PeopleRepo.GetOne(dto.PersonId);
            if (person is null)
                return ServiceResult<Loan>.NotFound("Person not found");

            var PendingLoans = Uow.LoansRepo.GetPendingLoans();
            if (PendingLoans.Select(l => l.Thing).Any(t => t.Id == dto.ThingId))
                return ServiceResult<Loan>.BussinesLogicError("Thing is already on a loan");

            var newLoan = new Loan()
            {
                Thing = thing,
                Person = person,
                CreationDate = DateTime.Now,
                AgreedReturnDate = dto.AgreedReturnDate,
                RealReturnDate = null,
            };

            Uow.LoansRepo.add(newLoan);
            Uow.SaveChanges();

            return ServiceResult<Loan>.Ok(newLoan);
        }




        public ServiceResult<Loan> Close(int LoanId)
        {
            var loan=Uow.LoansRepo.GetOne(LoanId);
            if (loan is null) 
                return ServiceResult<Loan>.NotFound("Loan not found");

            if (loan.isClosed())
                return ServiceResult<Loan>.BussinesLogicError("Loan is already cloased");

            loan.Close();
            Uow.SaveChanges();

            return ServiceResult<Loan>.Ok(loan);
        }

        public ServiceResult<List<Loan>> GetPendingLoans()
        {
            var loans = Uow.LoansRepo.GetPendingLoans();
            return ServiceResult<List<Loan>>.Ok(loans);
        }
    }
}
