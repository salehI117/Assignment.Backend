using Backend.Domain.Entity;
using Backend.Domain.Interface;
using Backend.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Backend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IPerson_Service _personService;
        public HomeController(IPerson_Service person_Service)
        {
            _personService = person_Service;
        }

        [HttpGet("GetAllPersons")]
        public IActionResult GetAllPersons()
        {
            var persons = _personService.GetAsync();
            return Ok(persons);
        }

        [HttpPost("CreatePerson")]
        public IActionResult CreatePerson([FromBody] PersonRequests person)
        {
            if (string.IsNullOrEmpty(person.Name))
            {
                return BadRequest("Name is required.");
            }

            var createdPerson = _personService.SaveAsync(person);
            return Ok(person);
        }

    }
}
