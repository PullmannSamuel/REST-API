﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240907213531_addZamestnanci0")]
    partial class addZamestnanci0
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Divizia", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("firmaId")
                        .HasColumnType("int");

                    b.Property<string>("kod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("projektyId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("veduciDivizieId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("veduciDivizieId");

                    b.ToTable("divizie");
                });

            modelBuilder.Entity("api.Models.Firma", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("divizieId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("riaditelId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("riaditelId");

                    b.ToTable("firmy");
                });

            modelBuilder.Entity("api.Models.Oddelenie", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("kod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("projektId")
                        .HasColumnType("int");

                    b.Property<int>("veduciOddeleniaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("veduciOddeleniaId");

                    b.ToTable("oddelenia");
                });

            modelBuilder.Entity("api.Models.Projekt", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("diviziaId")
                        .HasColumnType("int");

                    b.Property<string>("kod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nazov")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("oddeleniaId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("veduciProjektuId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("veduciProjektuId");

                    b.ToTable("projekty");
                });

            modelBuilder.Entity("api.Models.Zamestnanec", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("meno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("priezvisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("titul")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("zamestnanci");
                });

            modelBuilder.Entity("api.Models.Divizia", b =>
                {
                    b.HasOne("api.Models.Zamestnanec", "veduciDivizie")
                        .WithMany()
                        .HasForeignKey("veduciDivizieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("veduciDivizie");
                });

            modelBuilder.Entity("api.Models.Firma", b =>
                {
                    b.HasOne("api.Models.Zamestnanec", "riaditel")
                        .WithMany()
                        .HasForeignKey("riaditelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("riaditel");
                });

            modelBuilder.Entity("api.Models.Oddelenie", b =>
                {
                    b.HasOne("api.Models.Zamestnanec", "veduciOddelenia")
                        .WithMany()
                        .HasForeignKey("veduciOddeleniaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("veduciOddelenia");
                });

            modelBuilder.Entity("api.Models.Projekt", b =>
                {
                    b.HasOne("api.Models.Zamestnanec", "veduciProjektu")
                        .WithMany()
                        .HasForeignKey("veduciProjektuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("veduciProjektu");
                });
#pragma warning restore 612, 618
        }
    }
}
