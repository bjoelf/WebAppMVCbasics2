using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVCbasics2app.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace WebAppMVCbasics2app.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegViewModel userReg)
        {
            if (ModelState.IsValid)
            {
                IdentityUser newUsr = new IdentityUser()
                {
                    UserName = userReg.UserName,
                    Email = userReg.Email,
                    PhoneNumber = userReg.Phone
                };
                IdentityResult res = await _userManager.CreateAsync(newUsr, userReg.Password);

                if (res.Succeeded)
                    //TODO: log user in!
                    return RedirectToAction("Index", "Home");

                foreach (var item in res.Errors)
                    ModelState.AddModelError(item.Code, item.Description);
            }
            return View(userReg);
        }

        [HttpGet]
        public IActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logon(LogonViewModel logUser)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult res = await _signInManager.PasswordSignInAsync(logUser.UserName, logUser.Password, false, false);
                
                if (res.Succeeded)
                    return RedirectToAction("Index", "Home");

                if (res.IsLockedOut)
                    ModelState.AddModelError("Locked out!", "Too many attemts");
            }
            return View(logUser);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
