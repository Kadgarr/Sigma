using System;
using System.Collections.Generic;

namespace GamesShop.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Games = new HashSet<Games>();
        }

        public int IdPublisher { get; set; }
        public string NameOfIzdatel { get; set; }
        public string LinkToTheWebSite { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}
