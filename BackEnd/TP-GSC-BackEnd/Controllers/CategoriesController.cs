using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Data_Access.CategoryData;

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

    }
}
