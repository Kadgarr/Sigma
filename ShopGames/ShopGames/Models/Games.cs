namespace ShopGames.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            Content_of_order = new HashSet<Content_of_order>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Game { get; set; }

        [Column(TypeName = "ntext")]
        public string Name_of_Game { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_of_release { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }

        public int? Count_of_keys { get; set; }

        public int Id_developer { get; set; }

        public int Id_publisher { get; set; }

        public int Id_genre { get; set; }

        public virtual Developer Developer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content_of_order> Content_of_order { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
