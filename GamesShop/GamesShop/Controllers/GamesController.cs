using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GamesShop.Controllers
{
    public class GamesController : Controller
    {
        GamesShopDB_Context db;

        UserManager<User> _userManager;
       
        public GamesController(GamesShopDB_Context context, UserManager<User> _userManager)
        {
            db = context;
            this._userManager = _userManager;
        }

        [HttpGet]
        public IActionResult AddGames()
        {
            var model = new SomeModels()
            {
                Developer = db.Developer.AsEnumerable(),
                Publisher = db.Publisher.AsEnumerable(),
            };
            return View(model);
        }
            
        
        [HttpPost]
        public IActionResult AddGames(string NameOfGame, string Image, DateTime DateOfRelease,string Description,  int Cost, int CountOfKeys, int IdDeveloper, int Id_publisher)
        {
            int IdGame = 0;
            using (GamesShopDB_Context db = new GamesShopDB_Context())
            {
                if (db.Games.Count() != 0)
                {
                    IdGame = db.Games.Max(p => p.IdGame + 1);
                }
                
                Games game = new Games { IdGame = IdGame, NameOfGame = NameOfGame, Image = Image, DateOfRelease = DateOfRelease.Date, Cost = Cost, CountOfKeys = CountOfKeys, IdDeveloper = IdDeveloper, IdPublisher = Id_publisher, Description=Description };
                // Добавление
               
                db.Games.Add(game);
                db.SaveChanges();
            }

            var model = new SomeModels()
            {
                Developer = db.Developer.AsEnumerable(),
                Publisher = db.Publisher.AsEnumerable(),
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
        public IActionResult AddGenresForGame(int id)
        {
            var model = new SomeModelsGenreGame()
            {
                Game = db.Games.AsEnumerable().Where(x=> x.IdGame==id),
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
                GenresGame genregame = new GenresGame { id_recording = Id_recording, IdGame = Id_game, IdGenre= Id_genre };
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

        [HttpGet]
        public IActionResult DeleteGenresForGame(int id)
        {
            var model = db.GenresGames.ToList().Where(x => x.IdGame == id);

            return View(model);
        }

        [HttpPost]
        [ActionName("DeleteGenresForGame")]
        public IActionResult PostDeleteGenresForGame(int id)
        {
            var model = db.GenresGames.Find(id);
            int idgame = model.IdGame;
           
            if (model != null)
            {
                db.GenresGames.Remove(model);
                db.SaveChanges();
               
                ViewData["MessageDeleteGenreGame"] = "Запись '" + model.IdGame + " " + model.IdGenre +  "' была успешно удалена!";
            }
            var modelgame = db.GenresGames.ToList().Where(x => x.IdGame == idgame);

            return View(modelgame);
        }


        [HttpGet]
       
        public async Task<IActionResult> EditGames(int? id)
        {
          
            Games game = await db.Games.FirstOrDefaultAsync(x=>x.IdGame==id);

            if (game == null)
            {
                return NotFound();
            }
            var model = new EditGameModel()
            { IdGame = game.IdGame, Image = game.Image, NameOfGame = game.NameOfGame, Cost = game.Cost, CountOfKeys = game.CountOfKeys, DateOfRelease = game.DateOfRelease, Description = game.Description, Developers = game.IdDeveloper, Publishers = game.IdPublisher, Developer=db.Developer.AsEnumerable(),Publisher=db.Publisher.AsEnumerable() };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditGames(EditGameModel gamemod)
        {
            Games game = await db.Games.FirstOrDefaultAsync(x => x.IdGame == gamemod.IdGame);
            game.IdGame = gamemod.IdGame;
            game.IdPublisher = gamemod.Publishers;
            game.IdDeveloper = gamemod.Developers;
            game.Image = gamemod.Image;
            game.Cost = gamemod.Cost;
            game.CountOfKeys = game.CountOfKeys;
            game.DateOfRelease = gamemod.DateOfRelease;
            game.Description = gamemod.Description;
            game.NameOfGame = gamemod.NameOfGame;

            Console.WriteLine("EditGame: " +gamemod.IdGame + gamemod.Publishers);
            db.Games.Update(game);
            await db.SaveChangesAsync();
            ViewData["MessageEditGame"] = "Запись '" + game.IdGame + " " + game.NameOfGame +  "' была успешно отредактирована!";
            return RedirectToAction("ListGames");
        }

        [HttpPost]
        //[ActionName("DeleteGame")]
        public IActionResult DeleteGame(int id)
        {
            var game = db.Games.Find(id);

            if (game != null)
            {
                db.Games.Remove(game);
                db.SaveChanges();

                ViewData["MessageDeleteGame"] = "Игра '" + game.NameOfGame + "' была успешно удалена!";
            }
            return RedirectToAction("ListGames", db.Games.ToList());
        }

        [HttpGet]
        public IActionResult GameView(int id)
        {
            var game =  db.Games.Include(x=> x.Feedbacks).ThenInclude(u=>u.IdUserNavigation).Include(x=>x.IdDeveloperNavigation).FirstOrDefault(x => x.IdGame == id);

            if (game == null)
            {
                return NotFound();
            }
            return View(game);
        }

        [HttpPost]
        public IActionResult ListGames(string SearchString)
        {
            //var games = from m in db.Games
            //             select m;
           
            var games = db.Games.Where(s => s.NameOfGame.StartsWith(SearchString));

            if (games == null)
            {

            }
            return View(games.ToList());
            

        }

        public async Task<IActionResult> AddFeedback(int id, string textFeedback)
        {
            int idFb = 0;

            var user = await _userManager.FindByNameAsync(User.Identity.Name);


            using (GamesShopDB_Context db = new GamesShopDB_Context())
            {
                if (db.Feedback.Count() != 0)
                {
                    idFb = db.Feedback.Max(p => p.IdFeedback + 1);
                }

                Feedbacks fb = new Feedbacks { IdPokupatel = user.Id, IdGame = id, IdFeedback = idFb, TextOfFeedback = textFeedback, DateOfFeedback = DateTime.Now };
                // Добавление

                db.Feedback.Add(fb);
                db.SaveChanges();
            }

            return RedirectToAction("ListGames");

        }
    }
    }
 
