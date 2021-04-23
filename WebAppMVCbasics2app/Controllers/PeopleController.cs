using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;
using WebAppMVCbasics2app.Models.ViewModel;

namespace WebAppMVCbasics2app.Controllers
{

    public class PeopleController : Controller
    {
        IPeopleService _peopleService = new PeopleService();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }

        [HttpPost]
        public IActionResult Index(CreatePersonViewModel createPersonViewModel)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPersonViewModel);
            }
            return View(_peopleService.All());
        }
       
        public IActionResult Delete(int id)
        {
            _peopleService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index(PeopleViewModel list)
        {
            return View(list);
        }

        public IActionResult Filter(PeopleViewModel filter)
        {
            //Skapa NY lista och skicka den!
            PeopleViewModel pvm = _peopleService.FindBy(filter);
            return View("Index", pvm);
        }
    }
}
