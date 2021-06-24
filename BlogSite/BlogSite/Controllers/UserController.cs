using BlogSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Controllers
{
    public class UserController : Controller
    {
        private readonly TextContext _context;

        public UserController(TextContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User model) 
        {
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();

            return View("Index", "Kullanıcı oluşturuldu");
        }

        public IActionResult YaziOlustur() 
        {
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult YaziOlustur(YaziViewModel model,int[] Kategoriler) 
        {
            List<Kategori> kategori = new List<Kategori>(); // _context.Kategoriler.Where(k => k.Id == Kategoriler).ToList();
            foreach (var item in Kategoriler)
            {
                if(_context.Kategoriler.Any(k => k.Id == item)) 
                {
                    var kat = _context.Kategoriler.FirstOrDefault(k => k.Id == item);
                    kategori.Add(kat); 
                }
                 
            }

           // var kategori = _context.Kategoriler.Where(k=>k.Id == Kategoriler).ToList();   

            var user = _context.Users.Include(i=>i.Yazilar).ThenInclude(y=>y.Kategoriler).FirstOrDefault(u => u.UserName == model.UserName);
            user.Yazilar.Add(new Yazi { YaziMetni = model.YaziAlanı ,Kategoriler = kategori });
            _context.SaveChanges();
            return RedirectToAction("YaziListele");
        }

        public IActionResult YaziListele() 
        {
            var yazilar = _context.Yazilar.Include(y=>y.User).ToList();
            return View(yazilar);
        }

        public IActionResult YaziyaGit(int id) 
        {
            var yazi = _context.Yazilar.Include(y=>y.Yorumlar).ThenInclude(y=>y.User).FirstOrDefault(y => y.Id == id);
            return View("Detail",yazi);
        }

        public IActionResult YorumEkle(int id) 
        {
            ViewBag.YaziId = id;
            return View();
        }

        [HttpPost]
        public IActionResult YorumEkle(YorumViewModel model) 
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == model.UserName);
            var yazi = _context.Yazilar.FirstOrDefault(y => y.Id == model.YaziId);

            _context.Yorumlar.Add(new Yorum { User = user, Yazi = yazi, YorumMetni = model.YorumMetni });
            _context.SaveChanges();

            return RedirectToAction("YaziListele");
        }

        public IActionResult KategoriEkle() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(string KategoriName)
        {
            _context.Kategoriler.Add(new Kategori { Adi = KategoriName });
            _context.SaveChanges();
            return View("Index","Kategori Eklendi");
        }


    }
}
