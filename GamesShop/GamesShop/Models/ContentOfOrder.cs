using System;
using System.Collections.Generic;

namespace GamesShop.Models
{
    public partial class ContentOfOrder
    {
        public int IdGame { get; set; }
        public int IdOrder { get; set; }
        public int? CountOfCopies { get; set; }

        public virtual Games IdGameNavigation { get; set; }
        public virtual Orders IdOrderNavigation { get; set; }
    }
}
