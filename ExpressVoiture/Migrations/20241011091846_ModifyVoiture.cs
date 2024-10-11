using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressVoiture.Migrations
{
    /// <inheritdoc />
    public partial class ModifyVoiture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modèle",
                table: "Voitures",
                newName: "Modele");

            migrationBuilder.RenameColumn(
                name: "CoutsReparation",
                table: "Voitures",
                newName: "CoutsReparations");

            migrationBuilder.RenameColumn(
                name: "Année",
                table: "Voitures",
                newName: "Annee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Modele",
                table: "Voitures",
                newName: "Modèle");

            migrationBuilder.RenameColumn(
                name: "CoutsReparations",
                table: "Voitures",
                newName: "CoutsReparation");

            migrationBuilder.RenameColumn(
                name: "Annee",
                table: "Voitures",
                newName: "Année");
        }
    }
}
