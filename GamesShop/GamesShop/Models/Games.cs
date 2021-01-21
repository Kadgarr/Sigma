using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesShop.Models
{
    public partial class Games
    {
        public int IdGame { get; set; }
        public string NameOfGame { get; set; }
        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfRelease { get; set; }
        public int Cost { get; set; }
        public int? CountOfKeys { get; set; }
        public int? IdDeveloper { get; set; }
        public int? IdPublisher { get; set; }
        public string Description { get; set; }

        public virtual Developer IdDeveloperNavigation { get; set; }
        public virtual Publisher IdPublisherNavigation { get; set; }
        public virtual ICollection<Feedbacks> Feedbacks { get; set; }
        public virtual ICollection<GenresGame> GenresGames { get; set; }
    }
}
