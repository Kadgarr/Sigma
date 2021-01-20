using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesShop.Models
{
    public partial class Feedbacks
    {
        public int IdFeedback { get; set; }
        public string TextOfFeedback { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfFeedback { get; set; }
        public string IdPokupatel { get; set; }
        public int IdGame { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual Games IdGameNavigation { get; set; }
    }
}
