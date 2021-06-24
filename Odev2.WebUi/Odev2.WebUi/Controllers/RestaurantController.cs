using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odev2.Business.Abstract;
using Odev2.WebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Odev2.WebUi.Controllers
{    
    [Authorize]
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var restaurants = _restaurantService.GetAll();
            return View(restaurants);
        }

        public IActionResult RestaurantCreate() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult RestaurantCreate(RestaurantViewModel model) 
        {
            _restaurantService.Create(new Entity.Restaurant() { RestaurantName = model.Name, Address = model.Address });
            return RedirectToAction("Index");
        }

        public IActionResult AddFood(int id) 
        {
            ViewBag.RestaurantId = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddFood(string foodname,int id) 
        {
            _restaurantService.AddFood(foodname, id);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Detail(int id) 
        {
            var restaurant = _restaurantService.GetById(id);
            return View(restaurant);
        }


    }
}
