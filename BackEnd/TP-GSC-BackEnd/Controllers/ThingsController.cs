using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        private readonly IUnitOfWork Uow;

        public ThingsController(IUnitOfWork uow) {
            this.Uow = uow;
        }


        [HttpGet]
        public IActionResult getAllthings()
        {
            return Ok(Uow.ThingsRepo.GetAll());
        }


        [HttpPost]
        public IActionResult createThing([FromBody]CreateThingDto newThingDto) {
            
            var selectedCategory=Uow.CategoryRepo.GetOne(newThingDto.CategoryId);
         
            if (selectedCategory is null)
                return BadRequest("Category not found");

            var newThing = new Thing { 
                Description=newThingDto.Description, 
                Category=selectedCategory 
            };
           
            if (!newThing.hasValidDescription())
                return BadRequest("invalid thing description");
                
            newThing = Uow.ThingsRepo.add(newThing);
            Uow.Complete();

            return Created("creado",newThing);
        }






    }
}
