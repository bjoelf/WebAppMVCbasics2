using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;
using WebAppMVCbasics2app.Interfaces;

namespace WebAppMVCbasics2app.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            this._cityService = cityService;
        }
        public IActionResult Index()
        {
            return View(_cityService.All());
        }
        public IActionResult Index(CreateCity createCity)
        {
            if (ModelState.IsValid)
            {
                _cityService.Add(createCity);
            }
            return View(_cityService.All());
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
