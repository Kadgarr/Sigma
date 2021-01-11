using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesShop.Models
{
    public class User: IdentityUser
    {
        public User()
        {
            Feedbacks = new HashSet<Feedbacks>();
            Orders = new HashSet<Orders>();
        }
        public DateTime Year { get; set; }

        public int ID_Card { get; set; }

        public virtual ICollection<Feedbacks> Feedbacks { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
