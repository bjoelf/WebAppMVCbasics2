﻿using Microsoft.AspNetCore.Mvc;
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
        readonly IPeopleService _peopleService = new PeopleService();

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
            {
                return RedirectToAction(nameof(Index));
            }
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
            {
                return NotFound();
            }

            return PartialView("_PeopleDetailsTableRow", person);
        }

        public IActionResult Filter(PeopleViewModel filter)
        {
            //Skapa NY lista och skicka den!
            PeopleViewModel pvm = _peopleService.FindBy(filter);
            return View("Index", pvm);
        }
               
        //public IActionResult Delete(int id)
        //{
        //    _peopleService.Remove(id);
        //    return RedirectToAction(nameof(Index));
        //}

        public IActionResult Delete(int id)
        {
            Person person = _peopleService.FindBy(id);

            if (person == null)
            {
                return NotFound();
            }

            if (_peopleService.Remove(id))
            {
                return Ok("person" + id);
            }
            //return RedirectToAction(nameof(Index));
            return BadRequest();
        }
    }
}
