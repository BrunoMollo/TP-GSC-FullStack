using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TP_GSC_BackEnd.Data_Access.Uow;
using TP_GSC_BackEnd.Entities;


namespace TP_GSC_BackEnd.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork Uow;
        public PeopleController(IUnitOfWork Uow)
        {
            this.Uow = Uow;
        }




        [HttpGet]
        [Authorize(Roles = "USER")]
        public IActionResult getAllPeople() => Ok(Uow.PeopleRepo.GetAll());



        [HttpGet("{id}")]
        public IActionResult getOnePerson(int id)
        {
            var person = Uow.PeopleRepo.GetOne(id);

            if (person == null)
                return NotFound();
            else
                return Ok(person);
        }



        [HttpPost]
        [Authorize(Roles = "USER")]
        public IActionResult createPerson([FromBody] Person newPerson)
        {
            
            if (newPerson.Name is null || newPerson.Name==String.Empty)
                return BadRequest("Name is required");
            
            newPerson = Uow.PeopleRepo.add(newPerson);
            Uow.SaveChanges();
            return Created("uri??", newPerson);
        }



        [HttpPut("{id}")]
        [Authorize(Roles = "USER")]
        public IActionResult updatePerson(int id, Person changedPerson) {
            if (changedPerson.Name is null || changedPerson.Name.Length < 3)
                return BadRequest("the name of the person must have at least 3 characters");

            var person=Uow.PeopleRepo.GetOne(id);
            if (person is null)
                return NotFound();

            person.Name = changedPerson.Name;
            person.PhoneNumber = changedPerson.PhoneNumber;
            person.Email = changedPerson.Email;


            Uow.PeopleRepo.update(person);
            Uow.SaveChanges();

            return NoContent();
        }



        [HttpDelete("{id}")]
        [Authorize(Roles = "USER")]
        public IActionResult deletePerson(int id) { 
            Uow.PeopleRepo.DeleteById(id);
            Uow.SaveChanges();
            return NoContent();
        }






    }
}
