using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameShop.Controllers
{
    public class GamesController : Controller
    {
        ShopGamesDBContext db;
        public GamesController(ShopGamesDBContext context)
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
        public IActionResult AddGames(string NameOfGame, string Image, DateTime DateOfRelease,  decimal Cost, int CountOfKeys, int IdDeveloper, int IdPublusher, int IdGenre )
        {
            int IdGame = 0;
            using (ShopGamesDBContext db = new ShopGamesDBContext())
            {
                if (db.Games.Count() != 0)
                {
                    IdGame = db.Games.Max(p => p.IdGame + 1);
                }
                
                Games game = new Games { IdGame = IdGame, NameOfGame = NameOfGame, Image = Image, DateOfRelease = DateOfRelease, Cost = Cost, CountOfKeys = CountOfKeys, IdDeveloper = IdDeveloper, IdPublisher = 0, IdGenre=0 };
                // Добавление
                Console.WriteLine("Запись '" + IdGame + " " + NameOfGame + " " + Image + " " + DateOfRelease + " " + Cost + " " + CountOfKeys + " " + IdDeveloper + "' была успешно добавлена!");
                db.Games.Add(game);
                db.SaveChanges();
            }


            ViewData["MessageAddGames"] = "Запись '" + IdGame + " " + NameOfGame + " " + Image + " "+DateOfRelease+" "+Cost+" "+ CountOfKeys +" " + IdDeveloper+"' была успешно добавлена!";

            return View(db.Developer.ToList());
        }
    }
}
