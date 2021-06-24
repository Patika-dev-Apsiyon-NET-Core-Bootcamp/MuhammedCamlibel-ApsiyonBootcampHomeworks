using AuthService.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IConfiguration _configuration;
        public AuthController(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserModel model) 
        {
            var result = await _signInManager.PasswordSignInAsync(model.username,model.password, false, false);
            var user = await _userManager.FindByNameAsync(model.username);
            if (result.Succeeded)
            {
                JwtService jwtService = new JwtService(_configuration);
                string token = jwtService.CreateAccessToken(user);
                return Ok(token);
            }

            return BadRequest( new { error = "Giriş başarısız" });
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserModel model) 
        {

            var result = await _userManager.CreateAsync(new Data.User { UserName = model.username , Email = "abc@abc" },model.password);
            if (result.Succeeded) 
            {
               return Ok(new { success = "Kullanıcı Oluşturuldu" });
            }

            return BadRequest(new { error = "Bir Hata oluştu" });
            
        }

        [HttpGet("Index")]
        public IActionResult Index() 
        {
            return Ok("Hoşgeldiniz");
        }

        [HttpGet("GetAllUsers")]
        
        public IActionResult GetAllUsers() 
        {
            return Ok(new { usersCount= _userManager.Users.Count() ,users = _userManager.Users.Select(u=> new { u.UserName }) });
        }

    }
}
