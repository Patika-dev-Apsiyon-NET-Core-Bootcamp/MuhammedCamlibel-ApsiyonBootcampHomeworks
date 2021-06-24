using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Odev2.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev2.WebUi.Controllers
{
    public class AuthController : Controller
    {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model) 
        {
            var user = new User
            {
                LastName = model.LastName,
                FirstName = model.FirstName,
                UserName = model.UserName,
                Email = model.Email,

            };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            } 
            return RedirectToAction("Register");
        }

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username,string password) 
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded) 
            {
                return RedirectToAction("Index","Restaurant");
            }
            return View();
        }
        
        public async Task<IActionResult> Logout() 
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","Restaurant");
        }

        public IActionResult Accsessdenied() 
        {
            return View();
        }
    }
}
