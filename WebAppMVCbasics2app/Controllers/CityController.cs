using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;
using WebAppMVCbasics2app.Interfaces;

namespace WebAppMVCbasics2app.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        public CityController(ICityService cityService)
        {
            this._cityService = cityService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Get anrop för att hämta sidan/viewn
        public ActionResult Create()
        {
            CreateCity createCity = new CreateCity();
            createCity.CityList = _cityService.All();
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
            return View(createCity);
        }
    }
}
