using AddressBookAPI.Models;
using AddressBookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AddressBookAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        //Uncomment in order to have a fast backend for the UI visualization
        //private static readonly List<Person> People = new List<Person>
        //{
        //    new Person { Id = 1, Name = "John Doe", Address = "123 Main St, Springfield" },
        //    new Person { Id = 2, Name = "Jane Smith", Address = "456 Elm St, Springfield" },
        //    new Person { Id = 3, Name = "Michael Brown", Address = "789 Oak St, Springfield" },
        //    new Person { Id = 4, Name = "Suzy Bridgeton", Address = "789 Oak St, Springfield" },
        //    new Person { Id = 5, Name = "Suzy Bridgeton", Address = "789 Oak St, Springfield" }
        //};

        //[HttpGet]
        //public ActionResult<IEnumerable<Person>> GetPeople()
        //{
        //    return People;
        //}

        //[HttpGet("{id}")]
        //public ActionResult<Person> GetPerson(int id)
        //{
        //    var person = People.Find(p => p.Id == id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }
        //    return person;
        //}

        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var people = await _peopleService.GetPeopleAsync();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await _peopleService.GetPersonByIdAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }
    }
}
