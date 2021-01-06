using System;
using System.Collections.Generic;

namespace GameShop.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Games = new HashSet<Games>();
        }

        public int IdGenre { get; set; }
        public string NameOfGenre { get; set; }
        public string DescriptionOfGenre { get; set; }

        public virtual ICollection<Games> Games { get; set; }
    }
}
