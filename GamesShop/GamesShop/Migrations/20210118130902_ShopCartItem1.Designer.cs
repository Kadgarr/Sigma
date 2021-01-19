﻿// <auto-generated />
using System;
using GamesShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GamesShop.Migrations
{
    [DbContext(typeof(GamesShopDB_Context))]
    [Migration("20210118130902_ShopCartItem1")]
    partial class ShopCartItem1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("GamesShop.Models.ContentOfOrder", b =>
                {
                    b.Property<int>("id_recording")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CountOfCopies")
                        .HasColumnType("int")
                        .HasColumnName("Count_of_copies");

                    b.Property<int>("IdGame")
                        .HasColumnType("int")
                        .HasColumnName("Id_game");

                    b.Property<int>("IdOrder")
                        .HasColumnType("int")
                        .HasColumnName("IdOrder");

                    b.HasKey("id_recording")
                        .HasName("[PK_Content_of_order]");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdOrder");

                    b.ToTable("Content_of_order");
                });

            modelBuilder.Entity("GamesShop.Models.Developer", b =>
                {
                    b.Property<int>("IdDeveloper")
                        .HasColumnType("int")
                        .HasColumnName("ID_Developer");

                    b.Property<string>("LinkToTheWebSite")
                        .HasColumnType("ntext")
                        .HasColumnName("Link_to_the_Web_Site");

                    b.Property<string>("NameOfDeveloper")
                        .HasColumnType("ntext")
                        .HasColumnName("Name_of_Developer");

                    b.HasKey("IdDeveloper")
                        .HasName("PK__Develope__3214EC07E50996FA");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("GamesShop.Models.Feedbacks", b =>
                {
                    b.Property<int>("IdFeedback")
                        .HasColumnType("int")
                        .HasColumnName("ID_Feedback");

                    b.Property<DateTime?>("DateOfFeedback")
                        .HasColumnType("date")
                        .HasColumnName("Date_of_feedback");

                    b.Property<int>("IdGame")
                        .HasColumnType("int")
                        .HasColumnName("Id_game");

                    b.Property<string>("IdPokupatel")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id_pokupatel");

                    b.Property<string>("TextOfFeedback")
                        .HasColumnType("text")
                        .HasColumnName("Text_of_feedback");

                    b.HasKey("IdFeedback")
                        .HasName("PK__Feedback__7CA05C3F161C990D");

                    b.HasIndex("IdPokupatel");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("GamesShop.Models.Games", b =>
                {
                    b.Property<int>("IdGame")
                        .HasColumnType("int")
                        .HasColumnName("ID_Game");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("money");

                    b.Property<int?>("CountOfKeys")
                        .HasColumnType("int")
                        .HasColumnName("Count_of_keys");

                    b.Property<DateTime?>("DateOfRelease")
                        .HasColumnType("date")
                        .HasColumnName("Date_of_release");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("Description_of_Game");

                    b.Property<int>("IdDeveloper")
                        .HasColumnType("int")
                        .HasColumnName("Id_developer");

                    b.Property<int>("IdPublisher")
                        .HasColumnType("int")
                        .HasColumnName("Id_publisher");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfGame")
                        .HasColumnType("ntext")
                        .HasColumnName("Name_of_Game");

                    b.HasKey("IdGame")
                        .HasName("PK__Games__03D8BB888F69FEE8");

                    b.HasIndex("IdDeveloper");

                    b.HasIndex("IdPublisher");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GamesShop.Models.Genre", b =>
                {
                    b.Property<int>("IdGenre")
                        .HasColumnType("int")
                        .HasColumnName("ID_Genre");

                    b.Property<string>("DescriptionOfGenre")
                        .HasColumnType("text")
                        .HasColumnName("Description_of_Genre");

                    b.Property<string>("NameOfGenre")
                        .HasColumnType("ntext")
                        .HasColumnName("Name_of_Genre");

                    b.HasKey("IdGenre")
                        .HasName("PK__Table__7B31A83B60B8E574");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("GamesShop.Models.GenresGame", b =>
                {
                    b.Property<int>("id_recording")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("IdGame")
                        .HasColumnType("int")
                        .HasColumnName("Id_game");

                    b.Property<int>("IdGenre")
                        .HasColumnType("int")
                        .HasColumnName("Id_genre");

                    b.HasKey("id_recording")
                        .HasName("[PK_GenresGames]");

                    b.HasIndex("IdGame");

                    b.HasIndex("IdGenre");

                    b.ToTable("GenresGames");
                });

            modelBuilder.Entity("GamesShop.Models.Orders", b =>
                {
                    b.Property<int>("IdOrder")
                        .HasColumnType("int")
                        .HasColumnName("ID_Order");

                    b.Property<DateTime?>("DateOfZakaz")
                        .HasColumnType("date")
                        .HasColumnName("Date_of_zakaz");

                    b.Property<string>("IdUser")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.HasKey("IdOrder")
                        .HasName("PK__Zakazi__CCA650A0618FFDCA");

                    b.HasIndex("IdUser");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GamesShop.Models.Publisher", b =>
                {
                    b.Property<int>("IdPublisher")
                        .HasColumnType("int")
                        .HasColumnName("ID_Publisher");

                    b.Property<string>("LinkToTheWebSite")
                        .HasColumnType("ntext")
                        .HasColumnName("Link_to_the_Web_Site");

                    b.Property<string>("NameOfIzdatel")
                        .HasColumnType("ntext")
                        .HasColumnName("Name_of_izdatel");

                    b.HasKey("IdPublisher")
                        .HasName("PK__Izdatel__A19FC79764CD432E");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("GamesShop.Models.ShopCartItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ShopCartId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("gameIdGame")
                        .HasColumnType("int");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("gameIdGame");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("GamesShop.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ID_Pokupatel");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("ntext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("ID_Card")
                        .HasColumnType("int")
                        .HasColumnName("ID_Card");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nchar(256)")
                        .HasColumnName("FIO")
                        .IsFixedLength(true);

                    b.Property<DateTime>("Year")
                        .HasColumnType("datetime2");

                    b.HasKey("Id")
                        .HasName("PK__Pokupate__D1376FD923B9C259");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("GamesShop.Models.ContentOfOrder", b =>
                {
                    b.HasOne("GamesShop.Models.Games", "IdGameNavigation")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .HasConstraintName("FK_Content_of_order_ToTable_1")
                        .IsRequired();

                    b.HasOne("GamesShop.Models.Orders", "IdOrderNavigation")
                        .WithMany()
                        .HasForeignKey("IdOrder")
                        .HasConstraintName("FK_Content_of_order_ToTable")
                        .IsRequired();

                    b.Navigation("IdGameNavigation");

                    b.Navigation("IdOrderNavigation");
                });

            modelBuilder.Entity("GamesShop.Models.Feedbacks", b =>
                {
                    b.HasOne("GamesShop.Models.User", "IdUserNavigation")
                        .WithMany("Feedbacks")
                        .HasForeignKey("IdPokupatel")
                        .HasConstraintName("FK_Feedbacks_ToTable");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("GamesShop.Models.Games", b =>
                {
                    b.HasOne("GamesShop.Models.Developer", "IdDeveloperNavigation")
                        .WithMany("Games")
                        .HasForeignKey("IdDeveloper")
                        .HasConstraintName("FK_Games_ToTable")
                        .IsRequired();

                    b.HasOne("GamesShop.Models.Publisher", "IdPublisherNavigation")
                        .WithMany("Games")
                        .HasForeignKey("IdPublisher")
                        .HasConstraintName("FK_Games_ToTable_1")
                        .IsRequired();

                    b.Navigation("IdDeveloperNavigation");

                    b.Navigation("IdPublisherNavigation");
                });

            modelBuilder.Entity("GamesShop.Models.GenresGame", b =>
                {
                    b.HasOne("GamesShop.Models.Games", "IdGameNavigation")
                        .WithMany()
                        .HasForeignKey("IdGame")
                        .HasConstraintName("FK_GenresGames_ToTable_1")
                        .IsRequired();

                    b.HasOne("GamesShop.Models.Genre", "IdGenreNavigation")
                        .WithMany()
                        .HasForeignKey("IdGenre")
                        .HasConstraintName("FK_GenresGames_ToTable")
                        .IsRequired();

                    b.Navigation("IdGameNavigation");

                    b.Navigation("IdGenreNavigation");
                });

            modelBuilder.Entity("GamesShop.Models.Orders", b =>
                {
                    b.HasOne("GamesShop.Models.User", "IdUserNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_Zakazi_ToTable");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("GamesShop.Models.ShopCartItem", b =>
                {
                    b.HasOne("GamesShop.Models.Games", "game")
                        .WithMany()
                        .HasForeignKey("gameIdGame");

                    b.Navigation("game");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("GamesShop.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("GamesShop.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesShop.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("GamesShop.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesShop.Models.Developer", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GamesShop.Models.Publisher", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GamesShop.Models.User", b =>
                {
                    b.Navigation("Feedbacks");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
