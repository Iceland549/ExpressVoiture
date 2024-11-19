using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpressVoiture.Data
{
    public class Modele
    {
        public int Id { get; set; }

        [Required]
        public string? Nom { get; set; } 

        [Required]

        public int MarqueId { get; set; }
        public virtual Marque? Marque { get; set; }

        //public virtual ICollection<Voiture> Voitures { get; set; } = null!;


    }
}
