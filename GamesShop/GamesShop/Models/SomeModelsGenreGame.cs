using GamesShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesShop.Models
{
    public class SomeModelsGenreGame
    {
        public IEnumerable<Games> Game { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}
