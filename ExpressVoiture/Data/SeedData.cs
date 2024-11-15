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
                    new Marque
                    {
                        Nom = "Mazda",
                        Modeles = new List<Modele>
                        {
                            new Modele { Nom = "Miata" },
                            new Modele { Nom = "CX-5" }
                        }
                    },
                    new Marque
                    {
                        Nom = "Jeep",
                        Modeles = new List<Modele>
                        {
                            new Modele { Nom = "Liberty" },
                            new Modele { Nom = "Wrangler" }
                        }
                    },
                    new Marque
                    {
                        Nom = "Renault",
                        Modeles = new List<Modele>
                        {
                            new Modele { Nom = "Scenic" },
                            new Modele { Nom = "Clio" }
                        }
                    },
                    new Marque
                    {
                        Nom = "Ford",
                        Modeles = new List<Modele>
                        {
                            new Modele { Nom = "Explorer" },
                            new Modele { Nom = "Edge" }
                        }
                    },
                    new Marque
                    {
                        Nom = "Honda",
                        Modeles = new List<Modele>
                        {
                            new Modele { Nom = "Civic" },
                            new Modele { Nom = "Accord" }
                        }
                    },
                    new Marque
                    {
                        Nom = "Volkswagen",
                        Modeles = new List<Modele>
                        {
                            new Modele { Nom = "GTI" },
                            new Modele { Nom = "Passat" }
                        }
                    },
                    // Ajoutez d'autres marques et modèles si nécessaire
                };

                await context.Marques.AddRangeAsync(marques);
                await context.SaveChangesAsync();
            }
            // Vérifie si des données existent déjà
            if (!context.Voitures.Any())
            {
                var voitures = new List<Voiture>
                {
                    new Voiture
                    {
                        CodeVIN = "Mazda001",
                        Annee = 2019,
                        MarqueId = context.Marques.First(m => m.Nom == "Mazda").Id,
                        ModeleId = context.Modeles.First(m => m.Nom == "Miata").Id,
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
                    new Voiture
                    {
                        CodeVIN = "Jeep001",
                        Annee = 2007,
                        MarqueId = context.Marques.First(m => m.Nom == "Jeep").Id,
                        ModeleId = context.Modeles.First(m => m.Nom == "Liberty").Id,
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
                    new Voiture
                    {
                        CodeVIN = "Renault001",
                        Annee = 2007,
                        MarqueId = context.Marques.First(m => m.Nom == "Renault").Id,
                        ModeleId = context.Modeles.First(m => m.Nom == "Scenic").Id,
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
                    new Voiture
                    {
                        CodeVIN = "Ford001",
                        Annee = 2017,
                        MarqueId = context.Marques.First(m => m.Nom == "Ford").Id,
                        ModeleId = context.Modeles.First(m => m.Nom == "Explorer").Id,
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
                    new Voiture
                    {
                        CodeVIN = "Honda001",
                        Annee = 2008,
                        MarqueId = context.Marques.First(m => m.Nom == "Honda").Id,
                        ModeleId = context.Modeles.First(m => m.Nom == "Civic").Id,
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
                    new Voiture
                    {
                        CodeVIN = "Volks001",
                        Annee = 2016,
                        MarqueId = context.Marques.First(m => m.Nom == "Volkswagen").Id,
                        ModeleId = context.Modeles.First(m => m.Nom == "GTI").Id,
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
                    new Voiture
                    {
                        CodeVIN = "Ford002",
                        Annee = 2013,
                        MarqueId = context.Marques.First(m => m.Nom == "Ford").Id,
                        ModeleId = context.Modeles.First(m => m.Nom == "Edge").Id,
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
