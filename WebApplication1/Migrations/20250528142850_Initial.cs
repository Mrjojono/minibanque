using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minibanque.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    NumClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodePostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.NumClient);
                });

            migrationBuilder.CreateTable(
                name: "Clomptes",
                columns: table => new
                {
                    NumCompte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOuverture = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Solde = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AutorisationDecouvert = table.Column<bool>(type: "bit", nullable: false),
                    MontantDecouvert = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    TauxRemuneration = table.Column<double>(type: "float", nullable: true),
                    PEL_TauxRemuneration = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clomptes", x => x.NumCompte);
                    table.ForeignKey(
                        name: "FK_Clomptes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "NumClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clomptes_ClientId",
                table: "Clomptes",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clomptes");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
