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
    [Authorize(Roles = "Admin")] //låser ner admin controllern för alla användare som inte är Admin.
    public class AdminController : Controller
    {
        UserManager<IdentityUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserList()
        {
            return View(_userManager.Users.ToList());
        }
        public async Task<IActionResult> Details(string id)
        {
            IdentityUser userFound = await _userManager.FindByIdAsync(id);

            if (userFound == null)
                return RedirectToAction(nameof(UserList));

            return View(userFound);
        }
        public async Task<IActionResult> RolesManagement(string id)
        {
            //Hämta anvädaren
            IdentityUser userFound = await _userManager.FindByIdAsync(id);
            if (userFound == null)
                return RedirectToAction(nameof(UserList));

            // Hämta anvädarens roller. (IList behövs för att det är ett await anrop!)
            IList<string> roles = await _userManager.GetRolesAsync(userFound);

            //Hämta tillgängliga roller.
            List<IdentityRole> identityRoles = _roleManager.Roles.ToList();

            RolesManagementViewModel viewModel = new RolesManagementViewModel(id, roles, identityRoles);

            return View(viewModel);
        }
        public async Task<IActionResult> AddRoleToUser(string userId, string roleName)
        {
            IdentityUser userFound = await _userManager.FindByIdAsync(userId);

            if (userFound == null)
                return RedirectToAction(nameof(UserList));

            var result = await _userManager.AddToRoleAsync(userFound, roleName);

            if (result.Succeeded)
                return RedirectToAction("RolesManagement", new { id = userId });

            IList<string> userRoles = await _userManager.GetRolesAsync(userFound);

            List<IdentityRole> identityRoles = _roleManager.Roles.ToList();

            RolesManagementViewModel viewModel = new RolesManagementViewModel(userId, userRoles, identityRoles);

            ViewBag.ErrorMsg = "Failed to change role for user!";

            return View("RolesManagment", viewModel);
        }
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleName)
        {
            IdentityUser userFound = await _userManager.FindByIdAsync(userId);

            if (userFound == null)
                return RedirectToAction(nameof(UserList));

            var result = await _userManager.RemoveFromRoleAsync(userFound, roleName);

            if (result.Succeeded)
                return RedirectToAction("RolesManagement", new { id = userId });

            IList<string> userRoles = await _userManager.GetRolesAsync(userFound);

            List<IdentityRole> identityRoles = _roleManager.Roles.ToList();

            RolesManagementViewModel viewModel = new RolesManagementViewModel(userId, userRoles, identityRoles);

            ViewBag.ErrorMsg = "Failed to change role for user!";

            return View("RolesManagment", viewModel);
        }
        public IActionResult RoleList()
        {
            return View(_roleManager.Roles.ToList());
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (String.IsNullOrWhiteSpace(roleName))
            {
                ViewBag.ErrorMsg = "Role name needs to be 3 long and not be blankspaces";
                return View("CreateRole", roleName);
            }

            IdentityRole role = new IdentityRole(roleName);

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
                return RedirectToAction(nameof(RoleList));

            ViewBag.ErrorMsg = "Role was not created.";

            return View("CreateRole", roleName);
        }
        public async Task<IActionResult> RemoveRole(string roleName)
        {
            if (!String.IsNullOrWhiteSpace(roleName) && await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = await _roleManager.FindByNameAsync(roleName);
                var result = await _roleManager.DeleteAsync(role);
                //ToDo inform user of result
            }
            return RedirectToAction(nameof(RoleList));
        }
    }
}
