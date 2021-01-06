using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameShop.Models;

namespace GameShop.Controllers
{
    public class HomeController : Controller
    {
      
        ShopGamesDBContext db;
        public HomeController(ShopGamesDBContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View(db.Developer.ToList());
        }


        [HttpGet]
        public IActionResult AddDeveloper(int? id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDeveloper(int IdDeveloper, string NameOfDeveloper, string LinkToTheWebSite)
        {
            using (ShopGamesDBContext db = new ShopGamesDBContext())
            {
                Developer dev = new Developer { IdDeveloper = IdDeveloper, NameOfDeveloper = NameOfDeveloper, LinkToTheWebSite = LinkToTheWebSite };
                // Добавление
                db.Developer.Add(dev);
                db.SaveChanges();
            }


            TempData["msg"] = "<script>alert('Запись была успешно добавлена!');</script>";

            return Content(IdDeveloper + " "+ NameOfDeveloper + " "+ LinkToTheWebSite);
        }



    }
}
