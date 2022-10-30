using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Data_Access.CategoryData;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepo;
        public CategoriesController(ICategoryRepository categoryRepo) 
        {
            this.categoryRepo = categoryRepo;
        }


        [HttpGet]
        public IActionResult getCategories() => Ok(categoryRepo.GetAll());


        [HttpPost]
        public IActionResult addCategory([FromBody] Category newCategory) 
        {

            if (!newCategory.hasValidDescription())
                return BadRequest("Debe tener entre 4 y 99 caracteres");

            categoryRepo.add(newCategory);

            return Ok();
        }

    }
}
