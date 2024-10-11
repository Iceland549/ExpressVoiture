using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Vérifie si la base de données a été migrée
            context.Database.EnsureCreated();

            // Vérifie si des données existent déjà
            if (!context.Voitures.Any())
            {
                var voitures = new List<Voiture>
                {
                    new Voiture
                    {
                        CodeVIN = "",
                        Annee = 2019,
                        Marque = "Mazda",
                        Modele = "Miata",
                        Finition = "LE",
                        DateAchat = new DateTime(2022, 1, 7),
                        PrixAchat = 1800.00m,
                        Reparations = "Restauration complète",
                        CoutsReparations = 7600.00m,
                        DateDisponibilite = new DateTime(2022, 4, 7),
                        PrixVente = 9900.00m,
                        DateVente = new DateTime(2022, 4, 8)
                    },
                    new Voiture
                    {
                        CodeVIN = "",
                        Annee = 2007,
                        Marque = "Jeep",
                        Modele = "Liberty",
                        Finition = "Sport",
                        DateAchat = new DateTime(2022, 4, 2),
                        PrixAchat = 4500.00m,
                        Reparations = "Roulements des roues avant",
                        CoutsReparations = 350.00m,
                        DateDisponibilite = new DateTime(2022, 4, 7),
                        PrixVente = 5350.00m,
                        DateVente = new DateTime(2022, 4, 9)
                    },
                    new Voiture
                    {
                        CodeVIN = "",
                        Annee = 2007,
                        Marque = "Renault",
                        Modele = "Scenic",
                        Finition = "TCe",
                        DateAchat = new DateTime(2022, 4, 4),
                        PrixAchat = 1800.00m,
                        Reparations = "Radiateur, freins",
                        CoutsReparations = 690.00m,
                        DateDisponibilite = new DateTime(2022, 4, 8),
                        PrixVente = 2990.00m,
                        DateVente = null // Si la date de vente n'est pas spécifiée
                    },
                    new Voiture
                    {
                        CodeVIN = "",
                        Annee = 2017,
                        Marque = "Ford",
                        Modele = "Explorer",
                        Finition = "XLT",
                        DateAchat = new DateTime(2022, 4, 5),
                        PrixAchat = 24350.00m,
                        Reparations = "Pneus, freins",
                        CoutsReparations = 1100.00m,
                        DateDisponibilite = new DateTime(2022, 4, 9),
                        PrixVente = 25950.00m,
                        DateVente = null
                    },
                    new Voiture
                    {
                        CodeVIN = "",
                        Annee = 2008,
                        Marque = "Honda",
                        Modele = "Civic",
                        Finition = "LX",
                        DateAchat = new DateTime(2022, 4, 6),
                        PrixAchat = 4000.00m,
                        Reparations = "Climatisation, freins",
                        CoutsReparations = 475.00m,
                        DateDisponibilite = new DateTime(2022, 4, 9),
                        PrixVente = 4975.00m,
                        DateVente = new DateTime(2022, 4, 9)
                    },
                    new Voiture
                    {
                        CodeVIN = "",
                        Annee = 2016,
                        Marque = "Volkswagen",
                        Modele = "GTI",
                        Finition = "S",
                        DateAchat = new DateTime(2022, 4, 6),
                        PrixAchat = 15250.00m,
                        Reparations = "Pneus",
                        CoutsReparations = 440.00m,
                        DateDisponibilite = new DateTime(2022, 4, 10),
                        PrixVente = 16190.00m,
                        DateVente = new DateTime(2022, 4, 12)
                    },
                    new Voiture
                    {
                        CodeVIN = "",
                        Annee = 2013,
                        Marque = "Ford",
                        Modele = "Edge",
                        Finition = "SEL",
                        DateAchat = new DateTime(2022, 4, 7),
                        PrixAchat = 10990.00m,
                        Reparations = "Pneus, freins, climatisation",
                        CoutsReparations = 950.00m,
                        DateDisponibilite = new DateTime(2022, 4, 11),
                        PrixVente = 12440.00m,
                        DateVente = new DateTime(2022, 4, 12)
                    }
                };

                // Ajout des voitures à la base de données
                context.Voitures.AddRange(voitures);
                context.SaveChanges(); // Sauvegarde les changements
            }
        }
    }
}
