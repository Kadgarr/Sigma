using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesShop.Controllers
{
    public class GamesController : Controller
    {
        GamesShopDB_Context db;
        public GamesController(GamesShopDB_Context context)
        {
            db = context; 
        }

        [HttpGet]
        public IActionResult AddGames()
        {
            var model = new SomeModels()
            {
                Developer = db.Developer.AsEnumerable(),
                Publisher = db.Publisher.AsEnumerable(),
                Genre = db.Genre.AsEnumerable()
            };
            return View(model);
        }
            
        
        [HttpPost]
        public IActionResult AddGames(string NameOfGame, string Image, DateTime DateOfRelease,  decimal Cost, int CountOfKeys, int IdDeveloper, int IdPublisher, int IdGenre )
        {
            int IdGame = 0;
            using (GamesShopDB_Context db = new GamesShopDB_Context())
            {
                if (db.Games.Count() != 0)
                {
                    IdGame = db.Games.Max(p => p.IdGame + 1);
                }
                
                Games game = new Games { IdGame = IdGame, NameOfGame = NameOfGame, Image = Image, DateOfRelease = DateOfRelease, Cost = Cost, CountOfKeys = CountOfKeys, IdDeveloper = IdDeveloper, IdPublisher = 0, IdGenre= 0 };
                // Добавление
                Console.WriteLine("Запись '" + IdGame + " " + NameOfGame + " " + Image + " " + DateOfRelease + " " + Cost + " " + CountOfKeys + " " + IdDeveloper + "' была успешно добавлена!");
                db.Games.Add(game);
                db.SaveChanges();
            }

            var model = new SomeModels()
            {
                Developer = db.Developer.AsEnumerable(),
                Publisher = db.Publisher.AsEnumerable(),
                Genre = db.Genre.AsEnumerable()
            };

            ViewData["MessageAddGames"] = "Запись '" + IdGame + " " + NameOfGame + " " + Image + " "+DateOfRelease+" "+Cost+" "+ CountOfKeys +" " + IdDeveloper+"' была успешно добавлена!";

            return View(model);
        }

        [HttpGet]
        public IActionResult ListGames()
        {
            
            return View(db.Games.ToList());
        }
    }
}
