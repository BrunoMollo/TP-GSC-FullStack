using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TP_GSC_BackEnd.Controllers.API;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto.CategotyDto;
using TP_GSC_BackEnd.Entities;
using FluentAssertions;
using FluentAssertions.Execution;

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











    }
}