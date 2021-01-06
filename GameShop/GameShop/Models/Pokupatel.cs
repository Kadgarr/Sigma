using System;
using System.Collections.Generic;

namespace GameShop.Models
{
    public partial class Pokupatel
    {
        public Pokupatel()
        {
            Feedbacks = new HashSet<Feedbacks>();
            Orders = new HashSet<Orders>();
        }

        public int IdPokupatel { get; set; }
        public string Fio { get; set; }
        public int? IdCard { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Feedbacks> Feedbacks { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
