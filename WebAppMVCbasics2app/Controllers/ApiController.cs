using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;
using WebAppMVCbasics2app.Interfaces;
using Microsoft.AspNetCore.Authorization;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageService _personLanguageService;

        public ApiController(IPeopleService peopleService, ILanguageService languageService, IPersonLanguageService personLanguageService) 
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _personLanguageService = personLanguageService;
        }

        // GET: api/<ApiController>
        [HttpGet]
        public ActionResult <IEnumerable<Person>> Get()
        {
            return Ok(_peopleService.AllPerson());
        }

        // GET api/<ApiController>/1
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _peopleService.FindBy(id);
        }

        // POST api/<ApiController>
        [HttpPost]
        public int Post([FromBody] CreatePersonViewModel newPerson)
        {
            //ToDo - code 201 created / code 400 bad request(validation failed) / code 500 database failed to create person
            // Returformat int kan bytas mot IActionResult och return BadRequest();

            if (!ModelState.IsValid)
                return Response.StatusCode = 400;

            Person p = _peopleService.Add(newPerson);
            if (p == null)
                return Response.StatusCode = 500;

            return Response.StatusCode = 201;
        }

        // DELETE api/<ApiController>/3
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            //ToDo - code 200 was removed / code 404 not found / code 500 database failed to delete person
            Person p = _peopleService.FindBy(id);
            if (p == null)
                return Response.StatusCode = 404;

            if (!_peopleService.Remove(id))
                return Response.StatusCode = 500;

            return Response.StatusCode = 200;
        }
    }
}
