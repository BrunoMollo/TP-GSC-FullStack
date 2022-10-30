using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_GSC_BackEnd.Data_Access.CategoryData;
using TP_GSC_BackEnd.Data_Access.PersonData;
using TP_GSC_BackEnd.Entities;

namespace TP_GSC_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonRepository peopleRepo;
        public PeopleController(IPersonRepository peopleRepo)
        {
            this.peopleRepo = peopleRepo;
        }


        [HttpGet]
        public IActionResult getAllPeople() => Ok(peopleRepo.GetAll());

        [HttpGet("{id}")]
        public IActionResult getOnePerson(int id)
        {
            var person = peopleRepo.GetOne(id);

            if(person == null)
                return NotFound();
            else
                return Ok(person);
        }

        [HttpPost]
        public IActionResult createPerson([FromBody]Person newPerson) {
            peopleRepo.add(newPerson);
            return Ok();
        }



    }
}
