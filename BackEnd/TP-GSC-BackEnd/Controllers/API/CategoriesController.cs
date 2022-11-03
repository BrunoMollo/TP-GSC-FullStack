using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TP_GSC_BackEnd.Data_Access.CategoryData;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork Uow;
        public CategoriesController(IUnitOfWork uow)
        {
            Uow = uow;
        }


        [HttpGet]
        public IActionResult getCategories() => Ok(Uow.CategoryRepo.GetAll());


        [HttpPost]
        public IActionResult addCategory([FromBody] Category newCategory)
        {
            if (!newCategory.hasValidDescription())
                return BadRequest("Debe tener entre 4 y 99 caracteres");

            try
            {
                newCategory = Uow.CategoryRepo.add(newCategory);
                Uow.Complete();
                return Created("created: ", newCategory);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Parece que la categoria ya existe.\n\n" + ex.InnerException?.Message);
            }
        }

    }
}
