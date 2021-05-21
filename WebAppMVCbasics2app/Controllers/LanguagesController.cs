using Microsoft.AspNetCore.Mvc;
using WebAppMVCbasics2app.Interfaces;
using WebAppMVCbasics2app.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace WebAppMVCbasics2app.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LanguagesController : Controller
    {
        private readonly ILanguageService _languageService;

        public LanguagesController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        // GET: LanguagesController
        [HttpGet]
        public ActionResult Index()
        {
            return View(_languageService.All());
        }

        // GET: LanguagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LanguagesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguage createLanguage)
        {
            if (ModelState.IsValid)
            {
                _languageService.Add(createLanguage);
                return RedirectToAction(nameof(Index));
            }
            return View(createLanguage);
        }
    }
}
