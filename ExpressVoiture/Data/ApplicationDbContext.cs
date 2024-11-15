using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressVoiture.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utilisateur>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Voiture> Voitures { get; set; }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Modele> Modeles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Voiture>()
                .HasOne(v => v.Marque)
                .WithMany(m => m.Voitures)
                .HasForeignKey(v => v.MarqueId);

            modelBuilder.Entity<Voiture>()
                .HasOne(v => v.Modele)
                .WithMany(m => m.Voitures)
                .HasForeignKey(v => v.ModeleId);

            // Configuration des propriétés de la classe Voiture
            modelBuilder.Entity<Voiture>()
                .Property(v => v.CoutsReparations)
                .HasColumnType("decimal(18, 2)"); // 18 chiffres au total, 2 chiffres après la virgule

            modelBuilder.Entity<Voiture>()
                .Property(v => v.PrixAchat)
                .HasColumnType("decimal(18, 2)"); // 18 chiffres au total, 2 chiffres après la virgule

            modelBuilder.Entity<Voiture>()
                .Property(v => v.PrixVente)
                .HasColumnType("decimal(18, 2)"); // 18 chiffres au total, 2 chiffres après la virgule
        }
    }
}
