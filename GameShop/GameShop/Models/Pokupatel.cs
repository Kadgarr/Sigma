using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace GameShop.Models
{
    public partial class Pokupatel:IdentityUser
    {
        public Pokupatel()
        {
            Feedbacks = new HashSet<Feedbacks>();
            Orders = new HashSet<Orders>();
        }

        public int ID_Pokupatel { get; set; }
        public string Fio { get; set; }
        public int? IdCard { get; set; }
   
        public string Email { get; set; }

        public virtual ICollection<Feedbacks> Feedbacks { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
