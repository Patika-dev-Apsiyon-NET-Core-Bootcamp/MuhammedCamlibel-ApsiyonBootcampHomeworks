using BookShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Controllers
{
    public class BookController : Controller
    {
        

        public IActionResult Index()
        {
            var books = HttpContext.Session.Get<List<BookViewModel>>("book");
            if(books == null) 
            {
                return RedirectToAction("Create"); 
            }
            return View(books);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (!ModelState.IsValid) 
            {
                return View(model);
            }

            var books = HttpContext.Session.Get<List<BookViewModel>>("book");

            if(books == null)
            {
                List<BookViewModel> books1 = new List<BookViewModel>();
                books1.Add(model);
                HttpContext.Session.Set<List<BookViewModel>>("book",books1);
            }
            else 
            {
                books.Add(model);
                HttpContext.Session.Set<List<BookViewModel>>("book", books);
            }

            
            var result = HttpContext.Session.Get<List<BookViewModel>>("book");
            return View("Index",result);
        }

        public IActionResult AddFavorite()
        {
            if (Request.Cookies.ContainsKey("bookName"))
            {
                var str = Request.Cookies["bookName"];
                return View("AddFavorite", str);
            }
            ViewBag.mesaj = "Favorilere bir kitap eklenmemiş";
            return View();
                
        }

        [HttpPost]
        public IActionResult AddFavorite(string Name) 
        {


            if (Request.Cookies.ContainsKey("bookName"))
            {
                /**/
                Response.Cookies.Delete("bookName");
                Response.Cookies.Append("bookName", Name);

            }
            else
            {
                Response.Cookies.Append("bookName", Name);
            }
            
            string str = Request.Cookies["bookName"];
            
            return View("AddFavorite",str);
        }

        public IActionResult BookSearch() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult BookSearch(SearchViewModel model) 
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var books = HttpContext.Session.Get<List<BookViewModel>>("book");
            if(books == null)
            {
                return RedirectToAction("Create"); 
            }
            else 
            {
                var book = books.FirstOrDefault(b => b.Name.Trim() == model.BookName.Trim() && b.Author == model.Author);
                if(book == null) 
                {
                    ViewBag.mesaj = "Böyle bir kitap arşivde yok";
                    return View("Detail2");
                }
                return View("Detail", book);
            }
              
        }



    }
}
