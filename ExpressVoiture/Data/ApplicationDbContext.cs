using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoiture.Data
{
    public class ApplicationDbContext : IdentityDbContext<Utilisateur>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Voiture> Voitures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des propriétés de la classe Voiture
            modelBuilder.Entity<Voiture>()
                .Property(v => v.CoutsReparation)
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
