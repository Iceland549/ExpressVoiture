using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpressVoiture.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "IdentityRoleClaim<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserClaim<string>_Utilisateur_UserId",
                table: "IdentityUserClaim<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogin<string>_Utilisateur_UserId",
                table: "IdentityUserLogin<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "IdentityUserRole<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<string>_Utilisateur_UserId",
                table: "IdentityUserRole<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserToken<string>_Utilisateur_UserId",
                table: "IdentityUserToken<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_Modele_Marque_MarqueId",
                table: "Modele");

            migrationBuilder.DropForeignKey(
                name: "FK_Voiture_Marque_MarqueId",
                table: "Voiture");

            migrationBuilder.DropForeignKey(
                name: "FK_Voiture_Modele_ModeleId",
                table: "Voiture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture");

            migrationBuilder.DropIndex(
                name: "IX_Voiture_ModeleId",
                table: "Voiture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modele",
                table: "Modele");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marque",
                table: "Marque");

            migrationBuilder.RenameTable(
                name: "Voiture",
                newName: "Voitures");

            migrationBuilder.RenameTable(
                name: "Modele",
                newName: "Modeles");

            migrationBuilder.RenameTable(
                name: "Marque",
                newName: "Marques");

            migrationBuilder.RenameIndex(
                name: "IX_Voiture_MarqueId",
                table: "Voitures",
                newName: "IX_Voitures_MarqueId");

            migrationBuilder.RenameIndex(
                name: "IX_Modele_MarqueId",
                table: "Modeles",
                newName: "IX_Modeles_MarqueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modeles",
                table: "Modeles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marques",
                table: "Marques",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "IdentityRoleClaim<string>",
                column: "RoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_Utilisateur_UserId",
                table: "IdentityUserClaim<string>",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_Utilisateur_UserId",
                table: "IdentityUserLogin<string>",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "IdentityUserRole<string>",
                column: "RoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_Utilisateur_UserId",
                table: "IdentityUserRole<string>",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserToken<string>_Utilisateur_UserId",
                table: "IdentityUserToken<string>",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Modeles_Marques_MarqueId",
                table: "Modeles",
                column: "MarqueId",
                principalTable: "Marques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Voitures_Marques_MarqueId",
                table: "Voitures",
                column: "MarqueId",
                principalTable: "Marques",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "IdentityRoleClaim<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserClaim<string>_Utilisateur_UserId",
                table: "IdentityUserClaim<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogin<string>_Utilisateur_UserId",
                table: "IdentityUserLogin<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "IdentityUserRole<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<string>_Utilisateur_UserId",
                table: "IdentityUserRole<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserToken<string>_Utilisateur_UserId",
                table: "IdentityUserToken<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_Modeles_Marques_MarqueId",
                table: "Modeles");

            migrationBuilder.DropForeignKey(
                name: "FK_Voitures_Marques_MarqueId",
                table: "Voitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voitures",
                table: "Voitures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Modeles",
                table: "Modeles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marques",
                table: "Marques");

            migrationBuilder.RenameTable(
                name: "Voitures",
                newName: "Voiture");

            migrationBuilder.RenameTable(
                name: "Modeles",
                newName: "Modele");

            migrationBuilder.RenameTable(
                name: "Marques",
                newName: "Marque");

            migrationBuilder.RenameIndex(
                name: "IX_Voitures_MarqueId",
                table: "Voiture",
                newName: "IX_Voiture_MarqueId");

            migrationBuilder.RenameIndex(
                name: "IX_Modeles_MarqueId",
                table: "Modele",
                newName: "IX_Modele_MarqueId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voiture",
                table: "Voiture",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Modele",
                table: "Modele",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marque",
                table: "Marque",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Voiture_ModeleId",
                table: "Voiture",
                column: "ModeleId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "IdentityRoleClaim<string>",
                column: "RoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_Utilisateur_UserId",
                table: "IdentityUserClaim<string>",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_Utilisateur_UserId",
                table: "IdentityUserLogin<string>",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "IdentityUserRole<string>",
                column: "RoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_Utilisateur_UserId",
                table: "IdentityUserRole<string>",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserToken<string>_Utilisateur_UserId",
                table: "IdentityUserToken<string>",
                column: "UserId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Modele_Marque_MarqueId",
                table: "Modele",
                column: "MarqueId",
                principalTable: "Marque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voiture_Marque_MarqueId",
                table: "Voiture",
                column: "MarqueId",
                principalTable: "Marque",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Voiture_Modele_ModeleId",
                table: "Voiture",
                column: "ModeleId",
                principalTable: "Modele",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
