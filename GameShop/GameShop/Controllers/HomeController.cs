using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameShop.Models;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult AddDeveloper( string NameOfDeveloper, string LinkToTheWebSite)
        {
            int IdDeveloper = 0;
            using (ShopGamesDBContext db = new ShopGamesDBContext())
            {
                IdDeveloper = db.Developer.Max(p => p.IdDeveloper+1);
                Developer dev = new Developer { IdDeveloper = IdDeveloper, NameOfDeveloper = NameOfDeveloper, LinkToTheWebSite = LinkToTheWebSite };
                // Добавление
                db.Developer.Add(dev);
                db.SaveChanges();
            }


            ViewData["Message"] = "Запись '"+ IdDeveloper+" "+NameOfDeveloper+" "+LinkToTheWebSite+"' была успешно добавлена!";

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> EditDeveloper(int? id)
        {
            if (id != null)
            {
                Developer dev = await db.Developer.FirstOrDefaultAsync(p => p.IdDeveloper == id);
                if (dev != null)
                    return View(dev);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> EditDeveloper(Developer dev)
        {
            db.Attach(dev).State = EntityState.Modified;
            await db.SaveChangesAsync();
            ViewData["MessageEdit"] = "Запись '" + dev.IdDeveloper + " " + dev.NameOfDeveloper + " " + dev.LinkToTheWebSite + "' была успешно отредактирована!";
            return View();
        }


        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var dev = await db.Developer.FindAsync(id);

            if (dev != null)
            {
                db.Developer.Remove(dev);
                await db.SaveChangesAsync();
                ViewData["MessageEdit"] = "Запись '" + dev.IdDeveloper + " " + dev.NameOfDeveloper + " " + dev.LinkToTheWebSite + "' была успешно удалена!";
            }

            return View("Index", db.Developer.ToList());
        }


        
    }
}
