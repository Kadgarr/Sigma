using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesShop.Models
{
    public class ShopCartItem
    {
        public int id  { get; set; }// это gameid

        public Games game { get; set; }

        public int price { get; set; }

        public string ShopCartId { get; set; }
    }
}
