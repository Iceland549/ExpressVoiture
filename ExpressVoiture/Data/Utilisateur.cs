using Microsoft.AspNetCore.Identity;


namespace ExpressVoiture.Data
{
    public class Utilisateur : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public string? Nom { get; set; }
        public string? Prenom { get; set; }
    }
}
