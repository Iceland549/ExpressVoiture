using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressVoiture.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prenom",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Voitures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeVIN = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Année = table.Column<int>(type: "int", nullable: false),
                    Marque = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modèle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Finition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAchat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixAchat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reparations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoutsReparation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateDisponibilite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PrixVente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateVente = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voitures", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voitures");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prenom",
                table: "AspNetUsers");
        }
    }
}
