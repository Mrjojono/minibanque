﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using minibanque.Models;

#nullable disable

namespace minibanque.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("minibanque.Models.Client", b =>
                {
                    b.Property<int>("NumClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumClient"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumClient");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("minibanque.Models.Compte", b =>
                {
                    b.Property<int>("NumCompte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumCompte"));

                    b.Property<bool>("AutorisationDecouvert")
                        .HasColumnType("bit");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOuverture")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MontantDecouvert")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Solde")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NumCompte");

                    b.HasIndex("ClientId");

                    b.ToTable("Clomptes");

                    b.HasDiscriminator().HasValue("Compte");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("minibanque.Models.CompteCourant", b =>
                {
                    b.HasBaseType("minibanque.Models.Compte");

                    b.HasDiscriminator().HasValue("CompteCourant");
                });

            modelBuilder.Entity("minibanque.Models.Livret", b =>
                {
                    b.HasBaseType("minibanque.Models.Compte");

                    b.Property<double>("TauxRemuneration")
                        .HasColumnType("float");

                    b.HasDiscriminator().HasValue("Livret");
                });

            modelBuilder.Entity("minibanque.Models.PEL", b =>
                {
                    b.HasBaseType("minibanque.Models.Compte");

                    b.Property<double>("TauxRemuneration")
                        .HasColumnType("float");

                    b.ToTable("Clomptes", t =>
                        {
                            t.Property("TauxRemuneration")
                                .HasColumnName("PEL_TauxRemuneration");
                        });

                    b.HasDiscriminator().HasValue("PEL");
                });

            modelBuilder.Entity("minibanque.Models.Compte", b =>
                {
                    b.HasOne("minibanque.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
