using AutoMapper;
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
        private readonly IMapper mapper;

        public ThingsController(IUnitOfWork uow, IMapper mapper)
        {
            Uow = uow;
            this.mapper = mapper;
        }



        [HttpGet]
        public IActionResult getAllThings()
        {
            var things = Uow.ThingsRepo.GetAll();
            var thingsDto = mapper.Map<ShowThingDto[]>(things);
            return Ok(thingsDto);
        }


        [HttpGet("{id}")]
        public IActionResult GetThingById(int id)
        {
            var thing = Uow.ThingsRepo.GetOne(id);
            if (thing is null)
                return NotFound();

            var thingDto = mapper.Map<ShowThingDto>(thing);
            return Ok(thingDto);
        }


        [HttpPost]
        public IActionResult createThing([FromBody] CreateThingDto newThingDto)
        {
            var newThing = mapper.Map<Thing>(newThingDto);

            if (!newThing.hasValidDescription())
                return BadRequest("invalid thing description");


            var selectedCategory = Uow.CategoryRepo.GetOne(newThingDto.CategoryId);
            if (selectedCategory is null)
                return BadRequest("Category not found");
            else
                newThing.Category = selectedCategory;


            var createdThing = Uow.ThingsRepo.add(newThing);
            Uow.SaveChanges();

            var createdThingDto = mapper.Map<ShowThingDto>(createdThing);
            return Created("uri??", createdThingDto);
        }


        [HttpDelete("{id}")]
        public IActionResult deleteThing(int id)
        {
            var thing = Uow.ThingsRepo.GetOne(id);
            if (thing is null)
                return NotFound();

            Uow.ThingsRepo.Delete(thing);
            Uow.SaveChanges();

            return NoContent();
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

            var modifiedThingDto = mapper.Map<ShowThingDto>(thing);
            return Ok(modifiedRows > 0 ? modifiedThingDto : "Nothing has changed");

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

            var modifiedThingDto = mapper.Map<ShowThingDto>(thing);
            return Ok(modifiedRows > 0 ? modifiedThingDto : "Nothing has changed");
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

            var modifiedThingDto = mapper.Map<ShowThingDto>(thing);
            return Ok(modifiedRows > 0 ? modifiedThingDto : "Nothing has changed");
        }




    }
}
