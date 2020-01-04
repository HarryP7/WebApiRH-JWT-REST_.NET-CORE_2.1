﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiRH.Models;

namespace WebApiRH.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200103124655_renameFields")]
    partial class renameFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiRH.Models.Advert", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EditedAt");

                    b.Property<string>("Fk_Author");

                    b.Property<int>("Fk_Category");

                    b.Property<string>("Fk_Image");

                    b.Property<string>("Fk_LocalGroup");

                    b.Property<bool>("Removed");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Uid");

                    b.HasIndex("Fk_Author");

                    b.HasIndex("Fk_Image");

                    b.HasIndex("Fk_LocalGroup");

                    b.ToTable("Advert");
                });

            modelBuilder.Entity("WebApiRH.Models.AdvertsReview", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EditedAt");

                    b.Property<string>("Fk_Advert");

                    b.Property<string>("Fk_Author");

                    b.Property<bool>("Removed");

                    b.Property<string>("Reviews")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.HasKey("Uid");

                    b.HasIndex("Fk_Advert");

                    b.HasIndex("Fk_Author");

                    b.ToTable("AdvertsReview");
                });

            modelBuilder.Entity("WebApiRH.Models.Answer", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<string>("Fk_Voting");

                    b.Property<string>("Option")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Uid");

                    b.HasIndex("Fk_Voting");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("WebApiRH.Models.GroupChat", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EditedAt");

                    b.Property<string>("FK_Author");

                    b.Property<string>("Fk_LocalGroup");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<bool>("Removed");

                    b.HasKey("Uid");

                    b.HasIndex("FK_Author");

                    b.HasIndex("Fk_LocalGroup");

                    b.ToTable("GroupChat");
                });

            modelBuilder.Entity("WebApiRH.Models.Home", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Appartaments");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EditedAt");

                    b.Property<string>("Fk_ImageUrl");

                    b.Property<string>("Fk_Manager");

                    b.Property<int>("Fk_Status");

                    b.Property<int>("Floors");

                    b.Property<string>("HomeNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("Porches");

                    b.Property<bool>("Removed");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("YearCommissioning");

                    b.HasKey("Uid");

                    b.HasIndex("Fk_ImageUrl");

                    b.HasIndex("Fk_Manager");

                    b.ToTable("Home");
                });

            modelBuilder.Entity("WebApiRH.Models.Images", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<bool>("Removed");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Uid");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("WebApiRH.Models.LocalGroup", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EditedAt");

                    b.Property<string>("Fk_Home");

                    b.Property<string>("Fk_Image");

                    b.Property<int>("Fk_Status");

                    b.Property<string>("Fk_Supervisor")
                        .IsRequired();

                    b.Property<bool>("Removed");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Uid");

                    b.HasIndex("Fk_Home");

                    b.HasIndex("Fk_Image");

                    b.HasIndex("Fk_Supervisor");

                    b.ToTable("LocalGroup");
                });

            modelBuilder.Entity("WebApiRH.Models.Participant", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fk_LocalGroup");

                    b.Property<string>("Fk_User");

                    b.HasKey("Uid");

                    b.HasIndex("Fk_LocalGroup");

                    b.HasIndex("Fk_User");

                    b.ToTable("Participant");
                });

            modelBuilder.Entity("WebApiRH.Models.User", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .HasColumnType("Nvarchar(MAX)");

                    b.Property<int>("Appartament");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EditedAt");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Fk_Avatar");

                    b.Property<int?>("Fk_Gender");

                    b.Property<string>("Fk_Home");

                    b.Property<int>("Fk_Role");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("Nvarchar(100)");

                    b.Property<bool>("IsApprovedHome");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(15)");

                    b.Property<bool>("Removed");

                    b.HasKey("Uid");

                    b.HasIndex("Fk_Avatar");

                    b.HasIndex("Fk_Home");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApiRH.Models.Voting", b =>
                {
                    b.Property<string>("Uid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Fk_Advert");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("TotalVotes");

                    b.Property<bool>("isMulti");

                    b.Property<string>("yourOption")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Uid");

                    b.HasIndex("Fk_Advert");

                    b.ToTable("Voting");
                });

            modelBuilder.Entity("WebApiRH.Models.Advert", b =>
                {
                    b.HasOne("WebApiRH.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("Fk_Author");

                    b.HasOne("WebApiRH.Models.Images", "Image")
                        .WithMany()
                        .HasForeignKey("Fk_Image");

                    b.HasOne("WebApiRH.Models.LocalGroup", "LocalGroup")
                        .WithMany("Adverts")
                        .HasForeignKey("Fk_LocalGroup");
                });

            modelBuilder.Entity("WebApiRH.Models.AdvertsReview", b =>
                {
                    b.HasOne("WebApiRH.Models.Advert", "Advert")
                        .WithMany("Reviews")
                        .HasForeignKey("Fk_Advert");

                    b.HasOne("WebApiRH.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("Fk_Author");
                });

            modelBuilder.Entity("WebApiRH.Models.Answer", b =>
                {
                    b.HasOne("WebApiRH.Models.Voting", "Voting")
                        .WithMany("Options")
                        .HasForeignKey("Fk_Voting");
                });

            modelBuilder.Entity("WebApiRH.Models.GroupChat", b =>
                {
                    b.HasOne("WebApiRH.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("FK_Author");

                    b.HasOne("WebApiRH.Models.LocalGroup", "LocalGroup")
                        .WithMany("Messages")
                        .HasForeignKey("Fk_LocalGroup");
                });

            modelBuilder.Entity("WebApiRH.Models.Home", b =>
                {
                    b.HasOne("WebApiRH.Models.Images", "ImageUrl")
                        .WithMany()
                        .HasForeignKey("Fk_ImageUrl");

                    b.HasOne("WebApiRH.Models.User", "Manager")
                        .WithMany()
                        .HasForeignKey("Fk_Manager");
                });

            modelBuilder.Entity("WebApiRH.Models.LocalGroup", b =>
                {
                    b.HasOne("WebApiRH.Models.Home", "Home")
                        .WithMany("LocalGroups")
                        .HasForeignKey("Fk_Home");

                    b.HasOne("WebApiRH.Models.Images", "Image")
                        .WithMany()
                        .HasForeignKey("Fk_Image");

                    b.HasOne("WebApiRH.Models.User", "Supervisor")
                        .WithMany("ManagedGroups")
                        .HasForeignKey("Fk_Supervisor")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApiRH.Models.Participant", b =>
                {
                    b.HasOne("WebApiRH.Models.LocalGroup", "LocalGroup")
                        .WithMany("Users")
                        .HasForeignKey("Fk_LocalGroup");

                    b.HasOne("WebApiRH.Models.User", "User")
                        .WithMany("MyGroups")
                        .HasForeignKey("Fk_User");
                });

            modelBuilder.Entity("WebApiRH.Models.User", b =>
                {
                    b.HasOne("WebApiRH.Models.Images", "Avatar")
                        .WithMany()
                        .HasForeignKey("Fk_Avatar");

                    b.HasOne("WebApiRH.Models.Home", "Home")
                        .WithMany("Tenants")
                        .HasForeignKey("Fk_Home");
                });

            modelBuilder.Entity("WebApiRH.Models.Voting", b =>
                {
                    b.HasOne("WebApiRH.Models.Advert", "Advert")
                        .WithMany("Votings")
                        .HasForeignKey("Fk_Advert");
                });
#pragma warning restore 612, 618
        }
    }
}
