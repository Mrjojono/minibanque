using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
namespace minibanque.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Compte> Clomptes { get; set; }
        public DbSet<CompteCourant> ComptesCourants { get; set; }
        public DbSet<Livret> Livrets { get; set; }
        public DbSet<PEL> PELS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=minibanque;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compte>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<CompteCourant>("CompteCourant")
                .HasValue<Livret>("Livret")
                .HasValue<PEL>("PEL");

            base.OnModelCreating(modelBuilder);
        }


    }
}
