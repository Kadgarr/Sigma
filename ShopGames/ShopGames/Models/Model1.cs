namespace ShopGames.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<Feedbacks> Feedbacks { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pokupatel> Pokupatel { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Content_of_order> Content_of_order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Developer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Feedbacks>()
                .Property(e => e.Text_of_feedback)
                .IsUnicode(false);

            modelBuilder.Entity<Games>()
                .Property(e => e.Cost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Games>()
                .HasMany(e => e.Content_of_order)
                .WithRequired(e => e.Games)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.Description_of_Genre)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Orders>()
                .HasMany(e => e.Content_of_order)
                .WithRequired(e => e.Orders)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pokupatel>()
                .Property(e => e.FIO)
                .IsFixedLength();

            modelBuilder.Entity<Pokupatel>()
                .HasMany(e => e.Feedbacks)
                .WithRequired(e => e.Pokupatel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pokupatel>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Pokupatel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publisher>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Publisher)
                .WillCascadeOnDelete(false);
        }
    }
}
