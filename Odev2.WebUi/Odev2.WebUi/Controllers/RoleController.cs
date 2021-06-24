using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev2.WebUi.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;

        public RoleController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
        public IActionResult CreateRole() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName) 
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult AddToRole() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(string roleName,string userName) 
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (!await _userManager.IsInRoleAsync(user, roleName))
                await _userManager.AddToRoleAsync(user, roleName);

            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Auth");
        }

    }
}
