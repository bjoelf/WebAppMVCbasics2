using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;
using WebAppMVCbasics2app.Interfaces;

namespace WebAppMVCbasics2app.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            CreateCountry createCountry = new CreateCountry();
            createCountry.CountryList = _countryService.All();
            return View(createCountry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountry createCountry)
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
