using System;
using System.Collections.Generic;

namespace GamesShop.Models
{
    public partial class Feedbacks
    {
        public int IdFeedback { get; set; }
        public string TextOfFeedback { get; set; }
        public DateTime? DateOfFeedback { get; set; }
        public string IdPokupatel { get; set; }
        public int IdGame { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
