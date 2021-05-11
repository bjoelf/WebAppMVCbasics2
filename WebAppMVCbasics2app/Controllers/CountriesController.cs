using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;
using WebAppMVCbasics2app.Interfaces;

namespace WebAppMVCbasics2app.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_countryService.All());
        }

        [HttpPost]
        public IActionResult Index(CreateCountry createCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Add(createCountry);
                return RedirectToAction(nameof(Index));
            }
            return View(_countryService.All());
        }


        public ActionResult Create()
        {
            //Listan visas i index, inte create!

            //CreateCountry createCountry = new CreateCountry();
            //createCountry.CountryList = _countryService.All();
            //return View(createCountry);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCountry createCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Add(createCountry);
                return RedirectToAction(nameof(Index));
            }
            return View(createCountry);
        }
    }
}
