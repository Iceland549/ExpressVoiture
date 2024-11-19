using System;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoiture.Data
{
    public class Voiture : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le Code VIN est requis.")]
        public string? CodeVIN { get; set; }

        [CustomRange(1990, ErrorMessage = "L'année doit être entre 1990 et l'année actuelle.")]
        public int Annee { get; set; }

        [Required(ErrorMessage = "La marque est requise.")]
        public int MarqueId { get; set; }
        public  Marque? Marque { get; set; }

        [Required(ErrorMessage = "Le modèle est requis.")]
        public int ModeleId { get; set; }
        public  Modele? Modele { get; set; }

        [Required(ErrorMessage = "La finition est requise.")]
        public string? Finition { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date d'achat est requise.")]
        public DateTime DateAchat { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix d'achat doit être positif.")]
        public decimal PrixAchat { get; set; }

        public string? Reparations { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le coût des réparations doit être positif.")]
        public decimal CoutsReparations { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La date de disponibilité est requise.")]
        public DateTime DateDisponibilite { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Le prix de vente doit être positif.")]
        public decimal PrixVente { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateVente { get; set; }

        public string? ImageUrl { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Marque != null && Modele != null &&
                Marque.Nom.Equals(Modele.Nom, StringComparison.OrdinalIgnoreCase))
            {
                yield return new ValidationResult(
                    "La marque et le modèle ne peuvent pas être identiques.",
                    new[] { nameof(Marque), nameof(Modele) });
            }
        }
    }

    public class CustomRangeAttribute(int minimum) : RangeAttribute(minimum, DateTime.Now.Year)
    {
    }
}
