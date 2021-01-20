using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesShop.Controllers
{
    public class FeedBackController : Controller
    {
        UserManager<User> _userManager;
        GamesShopDB_Context db = new GamesShopDB_Context();
        public FeedBackController(UserManager<User> _userManager)
        {
            this._userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ViewFeedback(string name)
        {

            var user = await _userManager.FindByNameAsync(name);

            if (user != null)
            {
                using (GamesShopDB_Context db = new GamesShopDB_Context())
                {
                    var listDetailFeedback = db.Feedback.Where(x => x.IdPokupatel == user.Id).Include(x=>x.IdGameNavigation);
                    return View(listDetailFeedback.ToList());
                }
            }

            return RedirectToAction("Profile");
        }


        [HttpGet]
        public async Task<IActionResult> EditFeedback(int? id)
        {
            if (id != null)
            {
                Feedbacks fb = await db.Feedback.FirstOrDefaultAsync(p => p.IdFeedback == id);
                if (fb != null)
                    return View(fb);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> EditFeedback(Feedbacks fb)
        {
            Console.WriteLine("Feedback id:" + fb.TextOfFeedback);
            db.Attach(fb).State = EntityState.Modified;
            await db.SaveChangesAsync();
            ViewData["MessageEdit"] = "Отзыв был успешно отредактирован!";
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> ViewFeedback(int id)
        {
            var feedback =  db.Feedback.Find(id);
            Console.WriteLine("Id user: "+ feedback.IdPokupatel);
            if (feedback != null)
            {
                db.Feedback.Remove(feedback);
                db.SaveChanges();
                ViewData["MessageDeleteFeedback"] = "Отзыв " + feedback.IdFeedback + " был успешно удален!";
            }

            var user = await _userManager.FindByNameAsync(feedback.IdPokupatel);

           var listDetailFeedback = db.Feedback.Where(x => x.IdPokupatel == feedback.IdPokupatel);

            return View(listDetailFeedback.ToList());
                
        }
    }
}
