using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace GamesShop.Models
{
    public class GamesShopDB_Context: IdentityDbContext<User>
    {
        public GamesShopDB_Context()
        {

        }

        public GamesShopDB_Context(DbContextOptions<GamesShopDB_Context> options)
            : base(options)
        {
           
            Database.EnsureCreated();
        }

        public virtual DbSet<ContentOfOrder> ContentOfOrders { get; set; }
        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<Feedbacks> Feedback { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<GenresGame> GenresGames { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<ShopCartItem> ShopCartItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DBGamesShop;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentOfOrder>(entity =>
            {
                entity.HasKey(e => e.id_recording)
                   .HasName("[PK_Content_of_order]");

                entity.ToTable("Content_of_order");

                entity.Property(e => e.CountOfCopies).HasColumnName("Count_of_copies");

                entity.Property(e => e.IdGame).HasColumnName("Id_game");

                entity.Property(e => e.IdOrder).HasColumnName("IdOrder");


                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_of_order_ToTable_1");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Content_of_order_ToTable");
            });
            modelBuilder.Entity<GenresGame>(entity =>
            {
                entity.HasKey(e => e.id_recording)
                   .HasName("[PK_GenresGames]");
              

                entity.ToTable("GenresGames");


                entity.Property(e => e.IdGame).HasColumnName("Id_game");

                entity.Property(e => e.IdGenre).HasColumnName("Id_genre");

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GenresGames_ToTable_");

                entity.HasOne(d => d.IdGenreNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdGenre)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GenresGames_ToTable");
            });

            modelBuilder.Entity<Developer>(entity =>
            {
                entity.HasKey(e => e.IdDeveloper)
                    .HasName("PK__Develope__3214EC07E50996FA");

                entity.Property(e => e.IdDeveloper)
                    .HasColumnName("ID_Developer")
                    .ValueGeneratedNever();

                entity.Property(e => e.LinkToTheWebSite)
                    .HasColumnName("Link_to_the_Web_Site")
                    .HasColumnType("ntext");

                entity.Property(e => e.NameOfDeveloper)
                    .HasColumnName("Name_of_Developer")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Feedbacks>(entity =>
            {
                entity.HasKey(e => e.IdFeedback)
                    .HasName("PK__Feedback__7CA05C3F161C990D");

                entity.Property(e => e.IdFeedback)
                    .HasColumnName("ID_Feedback")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfFeedback)
                    .HasColumnName("Date_of_feedback")
                    .HasColumnType("date");

                entity.Property(e => e.IdGame).HasColumnName("Id_game");

                entity.Property(e => e.IdPokupatel).HasColumnName("Id_pokupatel");

                entity.Property(e => e.TextOfFeedback)
                    .HasColumnName("Text_of_feedback")
                    .HasColumnType("text");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdPokupatel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedbacks_ToTable");

                entity.HasOne(d => d.IdGameNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdGame)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Feedbacks_ToTable_1");
            });

            modelBuilder.Entity<Games>(entity =>
            {
                entity.HasKey(e => e.IdGame)
                    .HasName("PK__Games__03D8BB888F69FEE8");

                entity.Property(e => e.IdGame)
                    .HasColumnName("ID_Game")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.CountOfKeys).HasColumnName("Count_of_keys");

                entity.Property(e => e.DateOfRelease)
                    .HasColumnName("Date_of_release")
                    .HasColumnType("date");

                entity.Property(e => e.IdDeveloper).HasColumnName("Id_developer");

                entity.Property(e => e.IdPublisher).HasColumnName("Id_publisher");

                entity.Property(e => e.NameOfGame)
                    .HasColumnName("Name_of_Game")
                    .HasColumnType("ntext");

                entity.Property(e => e.Description)
                    .HasColumnName("Description_of_Game")
                    .HasColumnType("text");


                entity.HasOne(d => d.IdDeveloperNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.IdDeveloper)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Games_ToTable");

                entity.HasOne(d => d.IdPublisherNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.IdPublisher)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Games_ToTable_1");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("PK__Table__7B31A83B60B8E574");

                entity.Property(e => e.IdGenre)
                    .HasColumnName("ID_Genre")
                    .ValueGeneratedNever();

                entity.Property(e => e.DescriptionOfGenre)
                    .HasColumnName("Description_of_Genre")
                    .HasColumnType("text");

                entity.Property(e => e.NameOfGenre)
                    .HasColumnName("Name_of_Genre")
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Zakazi__CCA650A0618FFDCA");

                entity.Property(e => e.IdOrder)
                    .HasColumnName("ID_Order")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfZakaz)
                    .HasColumnName("Date_of_zakaz")
                    .HasColumnType("date");

                entity.Property(e => e.IdUser).HasColumnName("Id");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zakazi_ToTable");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__Pokupate__D1376FD923B9C259");

                entity.Property(e => e.Id)
                    .HasColumnName("ID_Pokupatel")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email).HasColumnType("ntext");

                entity.Property(e => e.UserName)
                    .HasColumnName("FIO")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ID_Card).HasColumnName("ID_Card");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.IdPublisher)
                    .HasName("PK__Izdatel__A19FC79764CD432E");

                entity.Property(e => e.IdPublisher)
                    .HasColumnName("ID_Publisher")
                    .ValueGeneratedNever();

                entity.Property(e => e.LinkToTheWebSite)
                    .HasColumnName("Link_to_the_Web_Site")
                    .HasColumnType("ntext");

                entity.Property(e => e.NameOfIzdatel)
                    .HasColumnName("Name_of_izdatel")
                    .HasColumnType("ntext");
            });

            base.OnModelCreating(modelBuilder);


        }

        
    }
}
