using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models;
using WebAppMVCbasics2app.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using WebAppMVCbasics2app.Interfaces;


namespace WebAppMVCbasics2app.Controllers
{

    public class PeopleController : Controller
    {
        IPeopleService _peopleService;
        ILanguageService _languageService;
        IPersonLanguageService _personLanguageService;
        
        
        public PeopleController(IPeopleService peopleService, ILanguageService languageService, IPersonLanguageService personLanguageService)
        {
            _peopleService = peopleService;
            _languageService = languageService;
            _personLanguageService = personLanguageService;
        }
        
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

        public IActionResult Index(PeopleViewModel list)
        {
            return View(list);
        }
                
        public IActionResult Details(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
                return RedirectToAction(nameof(Index));

            return View(person);
        }

        //Ny metod för avslut av details      
        public IActionResult endPeopleDetails(int id)
        {
            return PartialView("_PeopleTableRow",_peopleService.FindBy(id));
        }

        public IActionResult PartialDetailes(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
                return NotFound();

            return PartialView("_PeopleDetailsTableRow", person);
        }

        public IActionResult Filter(PeopleViewModel filter)
        {
            PeopleViewModel pvm = _peopleService.FindBy(filter);
            return View("Index", pvm);
        }

        public IActionResult LanguageManagement(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
                return RedirectToAction("Index");

            ManageLanguageViewModel mlvm = new ManageLanguageViewModel();
            mlvm.Person = person;
            mlvm.Languages = _languageService.All();

            return View(mlvm);
        }

        public IActionResult PersonLanguageRemove(int id, int languageId)
        {
            PersonLanguage pl = _personLanguageService.FindbyId(id, languageId);

            if (pl == null)
                return RedirectToAction("Index");

            bool result = _personLanguageService.Remove(id, languageId);

            if (result)
                return RedirectToAction("Index");

            //TODO: needs fixing here!
            return RedirectToAction("Index");
        }

        public IActionResult PersonLanguageAdd(int id, int languageId)
        {
            Person person = _peopleService.FindBy(id);
            Language l = _languageService.FindbyId(languageId);

            if (person == null || l == null)
                return RedirectToAction("Index");

            //TODO: Måste ändras till rätt Action!
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
                return NotFound();

            if (_peopleService.Remove(id))
                return Ok("person" + id);

            return BadRequest();
        }
    }
}
