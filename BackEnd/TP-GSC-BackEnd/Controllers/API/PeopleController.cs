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
        public IActionResult createPerson([FromBody] Person newPerson)
        {
            newPerson = Uow.PeopleRepo.add(newPerson);
            Uow.SaveChanges();
            return Created("uri??", newPerson);
        }



    }
}
