using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TP_GSC_BackEnd.Controllers.API;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto.CategotyDto;
using TP_GSC_BackEnd.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Test_GSC
{
    public class CategoryControllerTests
    {

        private Mock<IUnitOfWork> uow= new Mock<IUnitOfWork>();
        private Mock<IMapper> mapper= new Mock<IMapper>();
        private CategoriesController target;




        private ShowCategoryDto[] Arrange_getCategories() {
            var DbData = new List<Category>() { new Category
                { Id=1, Description="cat", CreationDate=new DateTime(32) }
            };
            uow.Setup(u => u.CategoryRepo.GetAll()).Returns(DbData);

            var ExpectedDtos = new ShowCategoryDto[]{ new ShowCategoryDto
                { Id=1, Description="cat" }
            };
            mapper.Setup(m => m.Map<ShowCategoryDto[]>(DbData)).Returns(ExpectedDtos);

            target = new CategoriesController(uow.Object, mapper.Object);

            return ExpectedDtos;
        }

        [Fact]
        public void getCategories_should_return_ok()
        {
            Arrange_getCategories();
            var result=target.getCategories();
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void getCategories_should_return_expetedDtos_type() {
            var expectedDtos=Arrange_getCategories();

            var result = target.getCategories();
            var castedResult = (OkObjectResult)result;
            var body = castedResult.Value;

            body.Should().NotBeNull();
            if (body is not null) { 
                var dto = (ShowCategoryDto[])body;
                dto.Should().BeSameAs(expectedDtos); //Se que es considerarlo mala practica tener varios Asserts en el mismo test, pero concientemente decido ignorarlo
            }
        }


        [Fact]
        public void addCategory_should_not_add_repeated_category() {
            
            uow.Setup(u => u.CategoryRepo.add(It.IsAny<Category>())).Throws(new DbUpdateException());
            mapper.Setup(m => m.Map<Category>(It.IsAny<CreateCategoryDto>())).Returns(new Category() { Description="repeated"});
            
            var target = new CategoriesController(uow.Object, mapper.Object);

            var result=target.addCategory(new CreateCategoryDto());

            result.Should().BeOfType<BadRequestObjectResult>();
            uow.Verify(u => u.SaveChanges(), Times.Exactly(0));
        }

       
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        [InlineData("bb")] //TODO: ver si elimino le metodo hasValidDescription de Category para eliminar la dependencia
        [InlineData("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz")]// son 100
        [InlineData("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz")]// son 101
        public void addCategory_should_not_add_category_with_less_than_3_or_more_than_100_letters_or_null(string invalid_description) {
            mapper.Setup(m => m.Map<Category>(It.IsAny<CreateCategoryDto>())).Returns(new Category() { Description = invalid_description });

            var target = new CategoriesController(uow.Object, mapper.Object);

            var result = target.addCategory(new CreateCategoryDto());

            result.Should().BeOfType<BadRequestObjectResult>();
            uow.Verify(u => u.SaveChanges(), Times.Exactly(0));
        }


        [Theory]
        [InlineData("toy")]
        [InlineData("tool")]
        [InlineData("something else")]
        [InlineData("random category #12")]
        public void addCategory_should_add_category_with_valid_descrition_and_not_repeted(string valid_description) {
            mapper.Setup(m => m.Map<Category>(It.IsAny<CreateCategoryDto>())).Returns(new Category() { Description = valid_description });

            var target = new CategoriesController(uow.Object, mapper.Object);
            uow.Setup(u => u.CategoryRepo.add(It.IsAny<Category>())).Returns(new Category());

            var result = target.addCategory(new CreateCategoryDto());

            result.Should().BeOfType<CreatedResult>();
            uow.Verify(u => u.SaveChanges(), Times.Exactly(1));

        }










    }
}