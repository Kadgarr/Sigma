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
        public IActionResult AddGames(string NameOfGame, string Image, DateTime DateOfRelease,  decimal Cost, int CountOfKeys, int IdDeveloper, int Id_publisher)
        {
            int IdGame = 0;
            using (GamesShopDB_Context db = new GamesShopDB_Context())
            {
                if (db.Games.Count() != 0)
                {
                    IdGame = db.Games.Max(p => p.IdGame + 1);
                }
                
                Games game = new Games { IdGame = IdGame, NameOfGame = NameOfGame, Image = Image, DateOfRelease = DateOfRelease.Date, Cost = Cost, CountOfKeys = CountOfKeys, IdDeveloper = IdDeveloper, IdPublisher = Id_publisher };
                // Добавление
               
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


        [HttpGet]
        public IActionResult AddGenresForGame()
        {
            var model = new SomeModelsGenreGame()
            {
                Game = db.Games.AsEnumerable(),
                Genre = db.Genre.AsEnumerable()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddGenresForGame(int Id_game, int Id_genre)
        {
            using (GamesShopDB_Context db = new GamesShopDB_Context())
            {
                int Id_recording = 1;
                if (db.GenresGames.Count() != 0)
                {
                    Id_recording = db.GenresGames.Max(p => p.id_recording + 1);
                }
                GenresGame genregame = new GenresGame {id_recording= Id_recording, IdGame= Id_game, IdGenre= Id_genre };
                // Добавление
                db.GenresGames.Add(genregame);
                db.SaveChanges();
            }


            
            var model = new SomeModelsGenreGame()
            {
                Game = db.Games.AsEnumerable(),
                Genre = db.Genre.AsEnumerable()
            };
            ViewData["MessageAddGenresGames"] = "Запись '" + Id_game + " " + Id_genre + "' была успешно добавлена!";
            return View(model);

        }
    }
}
