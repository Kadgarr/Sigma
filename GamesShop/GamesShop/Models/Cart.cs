using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesShop.Models
{
    public class Cart
    {
        GamesShopDB_Context db;
      
        public Cart(GamesShopDB_Context db)
        {
            this.db = db;
        }
        public string ShopCartId { get; set; }

        public List<ShopCartItem>listShopItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<GamesShopDB_Context>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);

            return new Cart(context) { ShopCartId = shopCartId };
        }
        public void AddToCard(Games game)
        {


            db.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                game = game,
                price = game.Cost
            }) ;

            db.SaveChanges();
        }

        public void RemoveFromCart(ShopCartItem game)
        {
            db.ShopCartItem.Remove(game);
            db.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {

            return db.ShopCartItem.Where(p => p.ShopCartId == ShopCartId).Include(x => x.game).ToList();


        }
    }


}
