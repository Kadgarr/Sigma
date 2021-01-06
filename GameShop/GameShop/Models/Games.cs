using System;
using System.Collections.Generic;

namespace GameShop.Models
{
    public partial class Games
    {
        public int IdGame { get; set; }
        public string NameOfGame { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public decimal? Cost { get; set; }
        public int? CountOfKeys { get; set; }
        public int IdDeveloper { get; set; }
        public int IdPublisher { get; set; }
        public int IdGenre { get; set; }

        public virtual Developer IdDeveloperNavigation { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
        public virtual Publisher IdPublisherNavigation { get; set; }
    }
}
