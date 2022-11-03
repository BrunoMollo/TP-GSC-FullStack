using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto.CategotyDto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork Uow;

        private readonly IMapper mapper;

        public CategoriesController(IUnitOfWork uow, IMapper mapper)
        {
            Uow = uow;
            this.mapper = mapper;
        }



        [HttpGet]
        public IActionResult getCategories()
        {
            var categories=Uow.CategoryRepo.GetAll();
            var dtoCategories = mapper.Map<ShowCategoryDto[]>(categories);
            return Ok(dtoCategories);
        }


        [HttpGet("{id}")]
        public IActionResult getCategoryById(int id)
        {
            var category = Uow.CategoryRepo.GetOne(id);
            if (category is null)
                return NotFound();

            var dtoCategory = mapper.Map<ShowCategoryDto>(category);
            return Ok(dtoCategory);
        }


        [HttpPost]
        public IActionResult addCategory([FromBody] CreateCategoryDto newCategoryDto)
        {
            var newCategory = mapper.Map<Category>(newCategoryDto);

            if (!newCategory.hasValidDescription())
                return BadRequest("Invalid description");

            try
            {
                newCategory = Uow.CategoryRepo.add(newCategory);
                Uow.SaveChanges();

                var createdCategoryDto = mapper.Map<ShowCategoryDto>(newCategory);
                return Created("uri??", createdCategoryDto);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Another category already has that description");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult deleteCategory(int id) {
            var category = Uow.CategoryRepo.GetOne(id);
            if (category is null)
                return NotFound();

            Uow.CategoryRepo.Delete(category);
            Uow.SaveChanges();

            return NoContent();
        }


        [HttpPut("{id}")] //Es el verbo correcto??? porque no Patch???
        public IActionResult updateCategory(int id, [FromBody]CreateCategoryDto modifiedCategoryDto) {

            var Recivedcategory = mapper.Map<Category>(modifiedCategoryDto);

            if (Recivedcategory.hasInvalidDescription())
                return BadRequest("Invalid Description");

            var DbCategory = Uow.CategoryRepo.GetOne(id);
            if (DbCategory is null)
                return NotFound();

            DbCategory.Description=Recivedcategory.Description;
            try
            {
                Uow.SaveChanges();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Another category already has that description");
            }
            
        }

    }
}
