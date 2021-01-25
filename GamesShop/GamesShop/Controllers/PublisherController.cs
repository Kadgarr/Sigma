using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesShop.Controllers
{
    public class PublisherController : Controller
    {
        GamesShopDB_Context db;
        public PublisherController(GamesShopDB_Context context)
        {
            db = context;
        }

        public IActionResult PublisherList()
        {
            return View(db.Publisher.ToList());
        }

        [HttpGet]
        public IActionResult PublisherViewGames(int id)
        {
            var listGames = db.Games.Include(v => v.IdPublisherNavigation).Where(x => x.IdPublisher == id);

            Console.WriteLine("ID DEVELOPER: " + id);
            return View(listGames.ToList());
        }

        [HttpGet]
        public IActionResult AddPublisher()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult AddPublisher( string NameOfPublisher, string linkToTheWebSute)
        {
            int IdPublisher = 0;
            using (GamesShopDB_Context db = new GamesShopDB_Context())
            {

                if (db.Publisher.Count() != 0)
                {
                    IdPublisher = db.Publisher.Max(p => p.IdPublisher + 1);
                }

                Publisher pub = new Publisher { IdPublisher= IdPublisher, NameOfIzdatel=NameOfPublisher, LinkToTheWebSite=linkToTheWebSute  };
                // Добавление
                db.Publisher.Add(pub);
                db.SaveChanges();
            }

             
            ViewData["Message"] = "Запись "+NameOfPublisher + " была успешно добавлена!";

            return View();
        }

        public IActionResult EditPublisher(int? id)
        {
            if (id != null)
            {
                Publisher pub =  db.Publisher.FirstOrDefault(p => p.IdPublisher == id);
                if (pub != null)
                    return View(pub);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditPublisher(Publisher pub)
        {
            db.Attach(pub).State = EntityState.Modified;
            db.SaveChanges();
            ViewData["MessageEdit"] = "Запись была успешно отредактирована!";
            return View();
        }

        [HttpPost]
        [ActionName("PublisherList")]
        public IActionResult DeletePublisher(int id)
        {
            var pub = db.Publisher.Find(id);
            if (pub != null)
            {
                db.Publisher.Remove(pub);
             
                db.SaveChanges();
                ViewData["MessageDeletePublisher"] = "Запись была успешно удалена!";
            }

            return View("PublisherList", db.Publisher.ToList());
        }
    }
}
