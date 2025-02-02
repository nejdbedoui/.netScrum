﻿// <auto-generated />
using System;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20240515183907_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AM.ApplicationCore.Domain.Membre", b =>
                {
                    b.Property<string>("Matricule")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Matricule");

                    b.ToTable("Membres");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Projet", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SprintFk")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Code");

                    b.HasIndex("SprintFk");

                    b.ToTable("Projets");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Sprint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Sprints");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Tache", b =>
                {
                    b.Property<string>("MembreKey")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("SprintKey")
                        .HasColumnType("int");

                    b.Property<string>("Titre")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("Etat")
                        .HasColumnType("int");

                    b.HasKey("MembreKey", "SprintKey", "Titre");

                    b.HasIndex("SprintKey");

                    b.ToTable("Taches");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Projet", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Sprint", "Sprint")
                        .WithMany("Projet")
                        .HasForeignKey("SprintFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sprint");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Tache", b =>
                {
                    b.HasOne("AM.ApplicationCore.Domain.Membre", "Membre")
                        .WithMany("Taches")
                        .HasForeignKey("MembreKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AM.ApplicationCore.Domain.Sprint", "Sprint")
                        .WithMany("Taches")
                        .HasForeignKey("SprintKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Membre");

                    b.Navigation("Sprint");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Membre", b =>
                {
                    b.Navigation("Taches");
                });

            modelBuilder.Entity("AM.ApplicationCore.Domain.Sprint", b =>
                {
                    b.Navigation("Projet");

                    b.Navigation("Taches");
                });
#pragma warning restore 612, 618
        }
    }
}
