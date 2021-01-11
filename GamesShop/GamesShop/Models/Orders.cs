using System;
using System.Collections.Generic;

namespace GamesShop.Models
{
    public partial class Orders
    {
        public int IdOrder { get; set; }
        public DateTime? DateOfZakaz { get; set; }
        public decimal? Price { get; set; }
        public string IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
