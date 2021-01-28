using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly Cart shopCart;
        GamesShopDB_Context db;
        private readonly UserManager<User> _userManager;

        public OrderController(GamesShopDB_Context db, Cart shopCart, UserManager<User> userManager)
        {
            this.db = db;
            this.shopCart = shopCart;
            this._userManager = userManager;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListOrdersOfAdmin()
        {
            var orders = db.Orders.ToList();
            return View(orders);
        }

        [HttpPost]
        public IActionResult ListOrdersOfAdmin(string SearchString)
        {
            //var games = from m in db.Games
            //             select m;
            var orders = db.Orders.Where(s => s.email.StartsWith(SearchString));

            if (orders == null)
            {

            }
            return View(orders.ToList());


        }

        [HttpGet]
        public IActionResult CheckoutAutorize(string name)
        {
            var model = new SomeRoleOrders()
            {
                Users = db.Users.FirstOrDefault(x=>x.UserName==name)
            };
            Console.WriteLine("UserId: " +model.Users.Id);

            return View(model);
        }

        [HttpPost]
        public IActionResult Checkout(Orders order)
        {
           
            shopCart.listShopItems = shopCart.getShopItems();


            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }

            if (ModelState.IsValid)
            {
                int id_recording_content = 1;
                int id_recording_order = 0;

               
                if (db.Orders.Count() != 0)
                {
                    id_recording_order = db.Orders.Max(p => p.IdOrder + 1);
                }

                int summ = 0;
                foreach (var item in shopCart.listShopItems)
                {
                    summ += item.game.Cost;
                }

                Orders orders = new Orders()
                {
                    name = order.name,
                    IdOrder = id_recording_order,
                    DateOfZakaz = DateTime.Now,
                    email = order.email,
                    IdUser = order.IdUser,
                    Price = summ

                };
                db.Orders.Add(orders);
                db.SaveChanges();

                var items = shopCart.listShopItems;

                foreach (var el in items)
                {
                    if (db.ContentOfOrders.Count() != 0)
                    {
                        id_recording_content = db.ContentOfOrders.Max(p => p.id_recording + 1);
                    }
                    var content_of_order = new ContentOfOrder()
                    {
                        IdGame = el.game.IdGame,
                        id_recording = id_recording_content,
                        IdOrder = orders.IdOrder

                    };

                    //вычисляем количество проданных копий
                    int count_cop = 0;
                    foreach (var idgame in items)
                    {
                        if (el.game.IdGame == idgame.game.IdGame)
                            count_cop++;
                    }
                    content_of_order.CountOfCopies = count_cop;

                    var game = db.Games.Find(el.game.IdGame);
                    game.CountOfKeys = game.CountOfKeys - count_cop;

                    db.Games.Update(game);
                    db.ContentOfOrders.Add(content_of_order);
                    db.SaveChanges();
                }

                foreach (var sh in shopCart.listShopItems)
                {
                    var shcart = db.ShopCartItem.FirstOrDefault(x => x.ShopCartId == sh.ShopCartId);
                    shopCart.RemoveFromCart(shcart);
                }

                return RedirectToAction("Complete");
            }
            return View(order);

        }


        [HttpPost]
        public async Task<IActionResult> CheckoutAutorize(SomeRoleOrders order)
        {

            shopCart.listShopItems = shopCart.getShopItems();

            User user = await _userManager.FindByEmailAsync(order.Users.Email);

            if (shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары");
            }

            if (ModelState.IsValid)
            {
                //поля для значений ключей
                int id_recording_content = 1;
                int id_recording_order = 0;


                if (db.Orders.Count() != 0)
                {
                    id_recording_order = db.Orders.Max(p => p.IdOrder + 1);
                }
                //вычисляем общую стоимость заказа
                int summ = 0;
                foreach (var item in shopCart.listShopItems)
                {
                    summ += item.game.Cost;
                }
            
                Orders orders = new Orders()
                {
                    name = order.Users.UserName,
                    IdOrder = id_recording_order,
                    DateOfZakaz = DateTime.Now,
                    email = order.Users.Email,
                    IdUser = user.Id,
                    Price = summ
                };
                
                db.Orders.Add(orders);
                db.SaveChanges();

                var items = shopCart.listShopItems;

                foreach (var el in items)
                {
                    if (db.ContentOfOrders.Count() != 0)
                    {
                        id_recording_content = db.ContentOfOrders.Max(p => p.id_recording + 1);
                    }

                    var content_of_order = new ContentOfOrder()
                    {
                        IdOrder = id_recording_order,
                        IdGame = el.game.IdGame,
                        id_recording = id_recording_content,
                        
                    };

                    //вычисляем количество проданных копий
                    int count_cop = 0;
                    foreach(var idgame in items)
                    {
                        if (el.game.IdGame == idgame.game.IdGame)
                            count_cop++;
                    }
                    content_of_order.CountOfCopies = count_cop;

                    var game = db.Games.Find(el.game.IdGame);
                    game.CountOfKeys = game.CountOfKeys - count_cop;

                    db.Games.Update(game);
                    
                    db.ContentOfOrders.Add(content_of_order);
                    db.SaveChanges();
                } 
                foreach(var sh in shopCart.listShopItems)
                {
                    var shcart = db.ShopCartItem.FirstOrDefault(x => x.ShopCartId == sh.ShopCartId);
                    shopCart.RemoveFromCart(shcart);
                }
              

                return RedirectToAction("Complete");
            }
            return View(order);

        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ListOrdersOfUser(string name)
        {
            User user = await _userManager.FindByNameAsync(name);
            var listOrders = db.Orders.Where(x => x.IdUser == user.Id);

            Console.WriteLine("UserId: " + user.Id);
            return View(listOrders.ToList());
        }
        [HttpGet]
        public IActionResult DetailOrderOfUser(int id)
        {
            var listDetailOrder = db.ContentOfOrders.Where(x => x.IdOrder == id).Include(s=> s.IdGameNavigation);

            return View(listDetailOrder.ToList());
        }
    }
}
