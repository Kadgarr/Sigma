using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesShop.Controllers
{
    public class GenreController : Controller
    {
        GamesShopDB_Context db;
        public GenreController(GamesShopDB_Context context)
        {
            db = context;
        }

        public IActionResult GenreList()
        {
            return View(db.Genre.ToList());
        }

        [HttpGet]
        public IActionResult AddGenre()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGenre( string NameOfGenre, string Description)
        {
            int IdGenre = 0;
            using (GamesShopDB_Context db = new GamesShopDB_Context())
            {

                if (db.Genre.Count() != 0)
                {
                    IdGenre = db.Genre.Max(p => p.IdGenre + 1);
                }
                 
                Genre genre = new Genre { IdGenre = IdGenre, DescriptionOfGenre= Description, NameOfGenre=NameOfGenre  };
                // Добавление
                if(NameOfGenre==null || Description == null)
                {
                    ViewData["Message"] = "Заполните оба поля ввода!";
                    return View();
                }
                else
                {
                    db.Genre.Add(genre);
                    db.SaveChanges();
                }
                
            }

             
            ViewData["Message"] = "Запись "+NameOfGenre + " была успешно добавлена!";

            return View();
        }

        public IActionResult EditGenre(int? id)
        {
            if (id != null)
            {
                Genre genre =  db.Genre.FirstOrDefault(p => p.IdGenre == id);
                if (genre != null)
                    return View(genre);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditGenre(Genre genre)
        {
            db.Attach(genre).State = EntityState.Modified;
            db.SaveChanges();
            ViewData["MessageEdit"] = "Запись была успешно отредактирована!";
            return View();
        }

        [HttpPost]
        [ActionName("GenreList")]
        public IActionResult DeleteGenre(int id)
        {
            var genr = db.Genre.Find(id);
            if (genr != null)
            {
                db.Genre.Remove(genr);
             
                db.SaveChanges();
                ViewData["MessageDeleteGenre"] = "Запись была успешно удалена!";
            }

            return View("GenreList", db.Genre.ToList());
        }

        [HttpGet]
        public IActionResult GenreViewGames(int id)
        {
            var listGames = db.GenresGames.Include(v => v.IdGameNavigation).Include(b=>b.IdGenreNavigation).Where(x => x.IdGenre == id);
            
            return View(listGames.ToList());
        }
    }
}
