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
using Microsoft.AspNetCore.Cors;

namespace WebAppMVCbasics2app.Controllers
{
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IPeopleService _peopleService;
        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageService _personLanguageService;
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public ApiController(IPeopleService peopleService, ILanguageService languageService, IPersonLanguageService personLanguageService, ICityService cityService, ICountryService countryService) 
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _personLanguageService = personLanguageService;
            _cityService = cityService;
            _countryService = countryService;
        }

        [HttpPost]
        public ActionResult<Person> Post([FromBody] CreatePersonViewModel newPerson)
        {
            // Code 201 created / code 400 bad request(validation failed) / code 500 database failed to create person
            // Returformat int kan bytas mot IActionResult och return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(newPerson);

            if (newPerson.CityId == 0)
                newPerson.CityId = 1;

            Person p = _peopleService.Add(newPerson);
            if (p == null)
                return StatusCode(StatusCodes.Status500InternalServerError);

            return Created("", p);
        }

        [HttpGet]
        public ActionResult <IEnumerable<Person>> Get()
        {
            return Ok(_peopleService.AllPerson());
        }

        [HttpGet("{id}")]
        public ActionResult <Person> Get(int id)
        {
            Person p = _peopleService.FindBy(id);
            if (p == null)
                return BadRequest();

            if (p.PersonLanguage != null)
            {
                foreach (var item in p.PersonLanguage)
                {
                    item.Person = null;
                    item.Language.PersonLanguage = null;
                }
            }

            if (p.CityId != null)
            {
                p.LiveInCity = _cityService.FindById((int)p.CityId);
                p.LiveInCity.PersonInCity = null;

                if (p.LiveInCity.Country != null)
                    p.LiveInCity.Country.CityInCountry = null;
            }
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //Code 200 was removed / code 404 not found / code 500 database failed to delete person
            if (!_peopleService.Remove(id))
                Response.StatusCode = 400;
            else
                Response.StatusCode = 200;
        }

        //---------------- City / Cities -----------------
        //CRUD

        [HttpPost("/api/City")]
        public ActionResult<City> Post([FromBody] CreateCity newCity)
        {
            City c = new City();
            //TODO: Implement method
            return Created("", c);
        }

        [HttpGet("/api/Cities")]
        public ActionResult<IEnumerable<City>> GetCities()
        {
            List<City> c = _cityService.All().CityList;
            foreach (var item in c)
            {
                item.Country = null;
                item.PersonInCity = null;
            }
            return Ok(c);
        }

        [HttpDelete("/api/City/{id}")]
        public void DeleteCity(int id)
        {
            if (!_cityService.Remove(id))
                BadRequest();
            Ok();
        }



        //---------------- Country / Countries -----------------

        [HttpGet("/api/Countries")]
        public ActionResult<IEnumerable<Country>> GetCountries()
        {
            List<Country> c = _countryService.All().CountryList;
            foreach (var item in c)
                item.CityInCountry = null;
            return Ok(c);
        }

    }
}
