using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Dto.ThingDto;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThingsController : ControllerBase
    {
        private readonly IUnitOfWork Uow;

        public ThingsController(IUnitOfWork uow)
        {
            Uow = uow;
        }



        [HttpGet]
        public IActionResult getAllThings()
        {
            return Ok(Uow.ThingsRepo.GetAll().Select(t => createShowDto(t)));
        }


        [HttpGet("{id}")]
        public IActionResult GetThingById(int id)
        {
            var thing = Uow.ThingsRepo.GetOne(id);
            if (thing is null)
                return NotFound();

            else return Ok(createShowDto(thing));
        }


        [HttpPost]
        public IActionResult createThing([FromBody] CreateThingDto newThingDto)
        {

            var selectedCategory = Uow.CategoryRepo.GetOne(newThingDto.CategoryId);

            if (selectedCategory is null)
                return BadRequest("Category not found");

            var newThing = new Thing
            {
                Description = newThingDto.Description,
                Category = selectedCategory
            };

            if (!newThing.hasValidDescription())
                return BadRequest("invalid thing description");

            newThing = Uow.ThingsRepo.add(newThing);
            Uow.SaveChanges();

            return Created("creado", createShowDto(newThing));
        }


        [HttpDelete("{id}")]
        public IActionResult deleteThing(int id)
        {
            var thing = Uow.ThingsRepo.GetOne(id);
            if (thing is null)
                return NotFound();

            Uow.ThingsRepo.Delete(thing);
            Uow.SaveChanges();

            return Ok();
        }


        [HttpPatch("{id}/description/{newDesc}")]
        public IActionResult changeThingDescription(int id, string newDesc)
        {
            if (id <= 0)
                return BadRequest("Invlaid thing Id");

            var thing = Uow.ThingsRepo.GetOne(id);
            if (thing is null)
                return NotFound("Thing not found");

            thing.Description = newDesc;

            if (!thing.hasValidDescription())
                return BadRequest("Invalid thing descripton");

            var modifiedRows = Uow.SaveChanges();

            return Ok(modifiedRows > 0 ? createShowDto(thing) : "Nothing has changed");

        }


        [HttpPatch("{id}/category/{newCategoryId}")]
        public IActionResult changeThingCategory(int id, int newCategoryId)
        {
            if (id <= 0)
                return BadRequest("Invlaid thing Id");
            if (newCategoryId <= 0)
                return BadRequest("Invalid Category Id");

            var thing = Uow.ThingsRepo.GetOne(id);
            if (thing is null)
                return NotFound("Thing not found");


            var newCategory = Uow.CategoryRepo.GetOne(newCategoryId);
            if (newCategory is null)
                return NotFound("Category not found");

            thing.Category = newCategory;

            var modifiedRows = Uow.SaveChanges();

            return Ok(modifiedRows > 0 ? createShowDto(thing) : "Nothing has changed");

        }


        [HttpPut("{id}")]
        public IActionResult updateThing(int id, [FromBody] CreateThingDto updatedThingDto)
        {
            if (id <= 0)
                return BadRequest("Invlaid thing Id");

            var thing = Uow.ThingsRepo.GetOne(id);
            if (thing is null)
                return NotFound("Thing not found");

            thing.Description = updatedThingDto.Description;

            if (!thing.hasValidDescription())
                return BadRequest("Invalid thing descripton");

            var newCategory = Uow.CategoryRepo.GetOne(updatedThingDto.CategoryId);
            if (newCategory is null)
                return NotFound("Category not found");

            thing.Category = newCategory;

            var modifiedRows = Uow.SaveChanges();

            return Ok(modifiedRows > 0 ? createShowDto(thing) : "Nothing has changed");

        }





        private ShowThingDto createShowDto(Thing thing)
        { //Esto con AutoMapper se tendria que ir
            var showThingDto = new ShowThingDto();
            showThingDto.Id = thing.Id;
            showThingDto.Description = thing.Description;
            if (thing.Category is not null)
            {
                showThingDto.Category.Id = thing.Category.Id;
                showThingDto.Category.Description = thing.Category.Description;
            }
            return showThingDto;
        }

    }
}
