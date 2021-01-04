namespace ShopGames.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            Content_of_order = new HashSet<Content_of_order>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Order { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_of_zakaz { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public int Id_pokupatel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Content_of_order> Content_of_order { get; set; }

        public virtual Pokupatel Pokupatel { get; set; }
    }
}
