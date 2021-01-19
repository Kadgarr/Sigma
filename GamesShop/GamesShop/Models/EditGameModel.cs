using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesShop.Models
{
    public class EditGameModel
    {
        public int IdGame { get; set; }
        public string NameOfGame { get; set; }
        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfRelease { get; set; }
        public int Cost { get; set; }
        public int? CountOfKeys { get; set; }
        public string Description { get; set; }
        public int Developers { get; set; }
        public int Publishers { get; set; }
        public IEnumerable<Developer> Developer { get; set; }
        public IEnumerable<Publisher> Publisher { get; set; }
    }
}
