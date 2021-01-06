using System;
using System.Collections.Generic;

namespace GameShop.Models
{
    public partial class Feedbacks
    {
        public int IdFeedback { get; set; }
        public string TextOfFeedback { get; set; }
        public DateTime? DateOfFeedback { get; set; }
        public int IdPokupatel { get; set; }
        public int IdGame { get; set; }

        public virtual Pokupatel IdPokupatelNavigation { get; set; }
    }
}
