using Microsoft.AspNetCore.Identity;
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
            modelBuilder.Entity<Marque>().HasData(
                new Marque
                {
                    Id = 1,
                    Nom = "Mazda"
                },
                new Marque
                {
                    Id = 2,
                    Nom = "Jeep"
                },
                new Marque
                {
                    Id = 3,
                    Nom = "Renault"
                },
                new Marque
                {
                    Id = 4,
                    Nom = "Ford"
                },
                new Marque
                {
                    Id = 5,
                    Nom = "Honda"
                },
                new Marque
                {
                    Id = 6,
                    Nom = "Volkswagen"
                }
            );
            modelBuilder.Entity<Modele>().HasData(
                new Modele { Id = 1, MarqueId = 1, Nom = "Miata" },
                new Modele { Id = 2, MarqueId = 1, Nom = "CX-5" },                
                new Modele { Id = 3, MarqueId = 2, Nom = "Liberty" },
                new Modele { Id = 4, MarqueId = 2, Nom = "Wrangler" },                
                new Modele { Id = 5, MarqueId = 3, Nom = "Scenic" },
                new Modele { Id = 6, MarqueId = 3, Nom = "Clio" },                
                new Modele { Id = 7, MarqueId = 4, Nom = "Explorer" },
                new Modele { Id = 8, MarqueId = 4, Nom = "Edge" },                
                new Modele { Id = 9, MarqueId = 5, Nom = "Civic" },
                new Modele { Id = 10, MarqueId = 5, Nom = "Accord" },                
                new Modele { Id = 11, MarqueId = 6, Nom = "GTI" },
                new Modele { Id = 12, MarqueId = 6, Nom = "Passat" }               
            );

            //modelBuilder.Entity<Voiture>()
            //    .HasOne(v => v.Marque)
            //    .WithMany(m => m.Voitures)
            //    .HasForeignKey(v => v.MarqueId);

            //modelBuilder.Entity<Voiture>()
            //    .HasOne(v => v.Modele)
            //    .WithMany(m => m.Voitures)
            //    .HasForeignKey(v => v.ModeleId);

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

            ////IMPORTANT pour éviter les erreurs de Clé étrangère
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            //{
            //    // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //    entityType.SetTableName(entityType.DisplayName());

            //    // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //    entityType.GetForeignKeys()
            //        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
            //        .ToList()
            //        .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            //}
            modelBuilder.Entity<IdentityRole>().ToTable("IdentityRole");
            modelBuilder.Entity<Utilisateur>().ToTable("Utilisateur");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("IdentityUserRole<string>");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaim<string>");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("IdentityUserLogin<string>");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("IdentityRoleClaim<string>");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("IdentityUserToken<string>");
        }
    }
}
