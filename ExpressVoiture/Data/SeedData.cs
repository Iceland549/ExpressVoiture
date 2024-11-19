using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ExpressVoiture.Data
{
    public class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context, UserManager<Utilisateur> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Vérifie si la base de données a été migrée
            context.Database.EnsureCreated();

            // Création du rôle Admin s'il n'existe pas
            var roleExists = await roleManager.RoleExistsAsync("Admin");
            if (!roleExists)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Création de l'utilisateur admin s'il n'existe pas
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new Utilisateur
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };
                await userManager.CreateAsync(adminUser, "AdminPassword123!"); // Mot de passe pour l'admin
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }


            if (!context.Marques.Any())
            {
                var marques = new List<Marque>
                {
                    new() {
                        Nom = "Mazda"
                    },
                    new() {
                        Nom = "Jeep"
                    },
                    new() {
                        Nom = "Renault"
                    },
                    new() {
                        Nom = "Ford"
                    },
                    new() {
                        Nom = "Honda"
                    },                       
                    new() {
                        Nom = "Volkswagen"
                    },
                };

                await context.Marques.AddRangeAsync(marques);
                await context.SaveChangesAsync();
            }

            if (!context.Modeles.Any())
            {
                var modeles = new List<Modele>();

                var mazdaId = context.Marques.Where(m => m.Nom == "Mazda").Select(m => m.Id).First();
                modeles.Add(new Modele { Nom = "Miata", MarqueId = mazdaId });
                modeles.Add(new Modele { Nom = "CX-5", MarqueId = mazdaId });

                var jeepId = context.Marques.Where(m => m.Nom == "Jeep").Select(m => m.Id).First();
                modeles.Add(new Modele { Nom = "Liberty", MarqueId = jeepId });
                modeles.Add(new Modele { Nom = "Wrangler", MarqueId = jeepId });

                var renaultId = context.Marques.Where(m => m.Nom == "Renault").Select(m => m.Id).First();
                modeles.Add(new Modele { Nom = "Scenic", MarqueId = renaultId });
                modeles.Add(new Modele { Nom = "Clio", MarqueId = renaultId });

                modeles.Add(new Modele { Nom = "Explorer", MarqueId = 4 });
                modeles.Add(new Modele { Nom = "Edge", MarqueId = 4 });

                var hondaId = context.Marques.Where(m => m.Nom == "Honda").Select(m => m.Id).First();
                modeles.Add(new Modele { Nom = "Civic", MarqueId = hondaId });
                modeles.Add(new Modele { Nom = "Accord", MarqueId = hondaId });

                var volkswagenId = context.Marques.Where(m => m.Nom == "Volkswagen").Select(m => m.Id).First();
                modeles.Add(new Modele { Nom = "GTI", MarqueId = volkswagenId });
                modeles.Add(new Modele { Nom = "Passat", MarqueId = volkswagenId });

                await context.Modeles.AddRangeAsync(modeles);
                await context.SaveChangesAsync();
            }

            // Vérifie si des données existent déjà
            if (!context.Voitures.Any())
            {
                var voitures = new List<Voiture>
                {
                    new() {
                        CodeVIN = "Mazda001",
                        Annee = 2019,
                        MarqueId = 1,
                        ModeleId = 1,
                        Finition = "LE",
                        DateAchat = new DateTime(2022, 1, 7),
                        PrixAchat = 1800.00m,
                        Reparations = "Restauration complète",
                        CoutsReparations = 7600.00m,
                        DateDisponibilite = new DateTime(2022, 4, 7),
                        PrixVente = 9900.00m,
                        DateVente = new DateTime(2022, 4, 8),
                        ImageUrl = "/images/Mazda001.jpg",
                    },
                    new() {
                        CodeVIN = "Jeep001",
                        Annee = 2007,
                        MarqueId = 2,
                        ModeleId = 3,
                        Finition = "Sport",
                        DateAchat = new DateTime(2022, 4, 2),
                        PrixAchat = 4500.00m,
                        Reparations = "Roulements des roues avant",
                        CoutsReparations = 350.00m,
                        DateDisponibilite = new DateTime(2022, 4, 7),
                        PrixVente = 5350.00m,
                        DateVente = new DateTime(2022, 4, 9),
                        ImageUrl = "Jeep001.jpg",
                    },
                    new() {
                        CodeVIN = "Renault001",
                        Annee = 2007,
                        MarqueId = 3,
                        ModeleId = 6,
                        Finition = "TCe",
                        DateAchat = new DateTime(2022, 4, 4),
                        PrixAchat = 1800.00m,
                        Reparations = "Radiateur, freins",
                        CoutsReparations = 690.00m,
                        DateDisponibilite = new DateTime(2022, 4, 8),
                        PrixVente = 2990.00m,
                        DateVente = null, // Si la date de vente n'est pas spécifiée
                        ImageUrl = "/images/Renault001.jpg",
                    },
                    new() {
                        CodeVIN = "Ford001",
                        Annee = 2017,
                        MarqueId = 4,
                        ModeleId = 7,
                        Finition = "XLT",
                        DateAchat = new DateTime(2022, 4, 5),
                        PrixAchat = 24350.00m,
                        Reparations = "Pneus, freins",
                        CoutsReparations = 1100.00m,
                        DateDisponibilite = new DateTime(2022, 4, 9),
                        PrixVente = 25950.00m,
                        DateVente = null,
                        ImageUrl = "/images/Ford001.jpg",
                    },
                    new() {
                        CodeVIN = "Honda001",
                        Annee = 2008,
                        MarqueId = 5,
                        ModeleId = 9,
                        Finition = "LX",
                        DateAchat = new DateTime(2022, 4, 6),
                        PrixAchat = 4000.00m,
                        Reparations = "Climatisation, freins",
                        CoutsReparations = 475.00m,
                        DateDisponibilite = new DateTime(2022, 4, 9),
                        PrixVente = 4975.00m,
                        DateVente = new DateTime(2022, 4, 9),
                        ImageUrl = "/images/Honda001.jpg",
                    },
                    new() {
                        CodeVIN = "Volks001",
                        Annee = 2016,
                        MarqueId = 6,
                        ModeleId = 12,
                        Finition = "S",
                        DateAchat = new DateTime(2022, 4, 6),
                        PrixAchat = 15250.00m,
                        Reparations = "Pneus",
                        CoutsReparations = 440.00m,
                        DateDisponibilite = new DateTime(2022, 4, 10),
                        PrixVente = 16190.00m,
                        DateVente = new DateTime(2022, 4, 12),
                        ImageUrl = "/images/Volks001.jpg",
                    },
                    new() {
                        CodeVIN = "Ford002",
                        Annee = 2013,
                        MarqueId = 4,
                        ModeleId = 8,
                        Finition = "SEL",
                        DateAchat = new DateTime(2022, 4, 7),
                        PrixAchat = 10990.00m,
                        Reparations = "Pneus, freins, climatisation",
                        CoutsReparations = 950.00m,
                        DateDisponibilite = new DateTime(2022, 4, 11),
                        PrixVente = 12440.00m,
                        DateVente = new DateTime(2022, 4, 12),
                        ImageUrl = "/images/Ford002.jpg",
                    }
                };

                // Ajout des voitures à la base de données
                await context.Voitures.AddRangeAsync(voitures);
                await context.SaveChangesAsync(); // Sauvegarde les changements
            }

        }
    }
}
