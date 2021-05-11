﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAppMVCbasics2app.Database;

namespace WebAppMVCbasics2app.Migrations
{
    [DbContext(typeof(PeopleDbContext))]
    [Migration("20210511160631_AddedLanguage")]
    partial class AddedLanguage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAppMVCbasics2app.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("LiveInCityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(59)
                        .HasColumnType("nvarchar(59)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("LiveInCityId");

                    b.ToTable("People");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.City", b =>
                {
                    b.HasOne("WebAppMVCbasics2app.Models.Country", "Country")
                        .WithMany("CityInCountry")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.Person", b =>
                {
                    b.HasOne("WebAppMVCbasics2app.Models.City", "LiveInCity")
                        .WithMany("PersonInCity")
                        .HasForeignKey("LiveInCityId");

                    b.Navigation("LiveInCity");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.PersonLanguage", b =>
                {
                    b.HasOne("WebAppMVCbasics2app.Models.Language", "Language")
                        .WithMany("PersonLanguage")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebAppMVCbasics2app.Models.Person", "Person")
                        .WithMany("PersonLanguage")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.City", b =>
                {
                    b.Navigation("PersonInCity");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.Country", b =>
                {
                    b.Navigation("CityInCountry");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.Language", b =>
                {
                    b.Navigation("PersonLanguage");
                });

            modelBuilder.Entity("WebAppMVCbasics2app.Models.Person", b =>
                {
                    b.Navigation("PersonLanguage");
                });
#pragma warning restore 612, 618
        }
    }
}
