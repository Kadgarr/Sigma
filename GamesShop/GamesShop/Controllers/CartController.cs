using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamesShop.Models;
using GamesShop.Models.ViewModels;

namespace GamesShop.Controllers
{
    public class CartController : Controller
    {
        private readonly GamesShopDB_Context db;
        private readonly Cart cart;

        public CartController(GamesShopDB_Context game, Cart cart)
        {
            this.db = game;
            this.cart = cart;
        }

        public ViewResult CartView()
        {
            var items = cart.getShopItems();

            cart.listShopItems = items;

            var obj = new CartIndexViewModel
            {
                Cart = cart
            };
            
            
            return View(obj);
        }


        public RedirectToActionResult addToCart(int id)
        {

            var item = db.Games.FirstOrDefault(i=>i.IdGame==id);

            if (item != null)
            {
                cart.AddToCard(item);
            }

            return RedirectToAction("CartView");
        }

        public RedirectToActionResult removeFromCart(string id)
        {

            var item = db.ShopCartItem.FirstOrDefault(i => i.ShopCartId == id);

            if (item != null)
            {
                cart.RemoveFromCart(item);
            }

            return RedirectToAction("CartView");
        }


    }
}
