using System;
using System.Collections.Generic;

namespace GamesShop.Models
{
    public partial class Developer
    {
        public Developer()
        {
            Games = new HashSet<Games>();
        }

        public int IdDeveloper { get; set; }
        public string NameOfDeveloper { get; set; }
        public string LinkToTheWebSite { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}
