using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models;

namespace WebAppMVCbasics2app.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        public CitiesController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //Ändra ICityService och CityService och sen här!
            return View(_cityService.All());
        }

        public IActionResult Create()
        {
            //TODO: Kolla om denna konverterng funkar. 
            CreateCity createCity = new CreateCity();
            createCity.Countries = _countryService.All().CountryList;
            return View(createCity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCity createCity)
        {
            if (ModelState.IsValid)
            {
                _cityService.Add(createCity);
                return RedirectToAction(nameof(Index));
            }

            createCity.Countries = _countryService.All().CountryList;
            return View(createCity);
        }
    }
}
