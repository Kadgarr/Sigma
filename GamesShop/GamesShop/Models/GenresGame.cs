using System;
using System.Collections.Generic;

namespace GamesShop.Models
{
    public partial class GenresGame
    {
        public int id_recording { get; set; }
        public int IdGame { get; set; }
        public int IdGenre { get; set; }

        public virtual Games IdGameNavigation { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
    }
}
