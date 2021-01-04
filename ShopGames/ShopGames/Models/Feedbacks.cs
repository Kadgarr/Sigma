namespace ShopGames.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feedbacks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Feedback { get; set; }

        [Column(TypeName = "text")]
        public string Text_of_feedback { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_of_feedback { get; set; }

        public int Id_pokupatel { get; set; }

        public int Id_game { get; set; }

        public virtual Pokupatel Pokupatel { get; set; }
    }
}
