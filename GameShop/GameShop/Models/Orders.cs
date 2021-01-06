using System;
using System.Collections.Generic;

namespace GameShop.Models
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public DateTime? DateOfZakaz { get; set; }
        public decimal? Price { get; set; }
        public int IdPokupatel { get; set; }

        public virtual Pokupatel IdPokupatelNavigation { get; set; }
    }
}
