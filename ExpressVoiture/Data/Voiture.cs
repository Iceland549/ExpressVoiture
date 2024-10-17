using System;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoiture.Data
{
    public class Voiture
    {
        public int Id { get; set; }

        [Required]
        public string? CodeVIN { get; set; }

        [Range(1990, 2100, ErrorMessage = "L'année doit être entre 1990 et l'année actuelle.")]
        public int Annee { get; set; }

        [Required]
        public string? Marque { get; set; }

        [Required]
        public string? Modele { get; set; }

        [Required]
        public string? Finition { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateAchat { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix d'achat doit être positif.")]
        public decimal PrixAchat { get; set; }

        public string? Reparations { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le coût des réparations doit être positif.")]
        public decimal CoutsReparations { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateDisponibilite { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix de vente doit être positif.")]
        public decimal PrixVente { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateVente { get; set; }
        public string? ImageUrl { get; set; }
    }
}
