using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoiture.Data
{
    public class Marque
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = null!;

        public virtual ICollection<Modele> Modeles { get; set; } = new List<Modele>();

        public virtual ICollection<Voiture> Voitures { get; set; } = null!;

    }
}
