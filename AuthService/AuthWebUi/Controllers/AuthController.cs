using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AuthWebUi.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Login(string UserName,string Password) 
        {
            
            var ItemJson = new StringContent(
                JsonSerializer.Serialize(new {username = UserName,password = Password }),
                Encoding.UTF8,
                "application/json");

            using(var client = new HttpClient()) 
            {
                using (var response = await client.PostAsync($"http://localhost:59169/api/Auth/Login",ItemJson ))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK) 
                    {
                        var token = await response.Content.ReadAsStringAsync();
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

                        CookieOptions option = new CookieOptions();
                        option.Expires = DateTime.Now.AddHours(1);
                        Response.Cookies.Append("token",token, option);

                        /*var response1 = await client.GetAsync("http://localhost:59169/api/Auth/GetAllUsers");


                        if (response1.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            return Json(response1.Content.ReadAsStringAsync());
                        }*/

                    }
                }
                
            }

            return RedirectToAction("Index","Home");
        }

        public IActionResult Register() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string Username,string Password)
        {
            var ItemJson = new StringContent(
                 JsonSerializer.Serialize(new { username = Username, password = Password }),
                 Encoding.UTF8,
                 "application/json");

            using (var client = new HttpClient())
            {
                using (var response = await client.PostAsync($"http://localhost:59169/api/Auth/Register", ItemJson))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("Login");
                    }
                    else return View();
                }

            }
            
        }

        public async Task<IActionResult> GetAllUser() 
        {
            var client = new HttpClient();
            var token = Request.Cookies["token"];
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = await client.GetAsync("http://localhost:59169/api/Auth/GetAllUsers");
            if (response.StatusCode == System.Net.HttpStatusCode.OK) 
            {
                return Json(response.Content.ReadAsStringAsync());
            }

            return View("GetAllUser","Lütfen oturum açın");
            
        }
    }
}
