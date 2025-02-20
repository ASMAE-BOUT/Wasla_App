using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wasla_App.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billets_Bus_BusId",
                table: "Billets");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesBus_Villes_VilleArriveeId",
                table: "LignesBus");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesBus_Villes_VilleDepartId",
                table: "LignesBus");

            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LignesBus",
                table: "LignesBus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billets",
                table: "Billets");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "Villes",
                newName: "NomVille");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Villes",
                newName: "VilleID");

            migrationBuilder.RenameColumn(
                name: "VilleDepartId",
                table: "LignesBus",
                newName: "VilleDepartID");

            migrationBuilder.RenameColumn(
                name: "VilleArriveeId",
                table: "LignesBus",
                newName: "VilleArriveeID");

            migrationBuilder.RenameColumn(
                name: "Nom",
                table: "LignesBus",
                newName: "NomLigne");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LignesBus",
                newName: "CompagnieID");

            migrationBuilder.RenameIndex(
                name: "IX_LignesBus_VilleDepartId",
                table: "LignesBus",
                newName: "IX_LignesBus_VilleDepartID");

            migrationBuilder.RenameIndex(
                name: "IX_LignesBus_VilleArriveeId",
                table: "LignesBus",
                newName: "IX_LignesBus_VilleArriveeID");

            migrationBuilder.RenameColumn(
                name: "UtilisateurId",
                table: "Billets",
                newName: "NumeroSiege");

            migrationBuilder.RenameColumn(
                name: "Statut",
                table: "Billets",
                newName: "StatutPaiement");

            migrationBuilder.RenameColumn(
                name: "BusId",
                table: "Billets",
                newName: "LigneID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Billets",
                newName: "CompagnieID");

            migrationBuilder.RenameIndex(
                name: "IX_Billets_BusId",
                table: "Billets",
                newName: "IX_Billets_LigneID");

            migrationBuilder.AlterColumn<int>(
                name: "CompagnieID",
                table: "LignesBus",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LigneID",
                table: "LignesBus",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "CompagnieID",
                table: "Billets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "NewBilletID",
                table: "Billets",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateVoyage",
                table: "Billets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NomUtilisateur",
                table: "Billets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LignesBus",
                table: "LignesBus",
                column: "LigneID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billets",
                table: "Billets",
                column: "NewBilletID");

            migrationBuilder.CreateTable(
                name: "Compagnies",
                columns: table => new
                {
                    CompagnieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCompagnie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compagnies", x => x.CompagnieID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LignesBus_CompagnieID",
                table: "LignesBus",
                column: "CompagnieID");

            migrationBuilder.CreateIndex(
                name: "IX_Billets_CompagnieID",
                table: "Billets",
                column: "CompagnieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Billets_Compagnies_CompagnieID",
                table: "Billets",
                column: "CompagnieID",
                principalTable: "Compagnies",
                principalColumn: "CompagnieID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Billets_LignesBus_LigneID",
                table: "Billets",
                column: "LigneID",
                principalTable: "LignesBus",
                principalColumn: "LigneID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesBus_Compagnies_CompagnieID",
                table: "LignesBus",
                column: "CompagnieID",
                principalTable: "Compagnies",
                principalColumn: "CompagnieID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesBus_Villes_VilleArriveeID",
                table: "LignesBus",
                column: "VilleArriveeID",
                principalTable: "Villes",
                principalColumn: "VilleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesBus_Villes_VilleDepartID",
                table: "LignesBus",
                column: "VilleDepartID",
                principalTable: "Villes",
                principalColumn: "VilleID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Billets_Compagnies_CompagnieID",
                table: "Billets");

            migrationBuilder.DropForeignKey(
                name: "FK_Billets_LignesBus_LigneID",
                table: "Billets");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesBus_Compagnies_CompagnieID",
                table: "LignesBus");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesBus_Villes_VilleArriveeID",
                table: "LignesBus");

            migrationBuilder.DropForeignKey(
                name: "FK_LignesBus_Villes_VilleDepartID",
                table: "LignesBus");

            migrationBuilder.DropTable(
                name: "Compagnies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LignesBus",
                table: "LignesBus");

            migrationBuilder.DropIndex(
                name: "IX_LignesBus_CompagnieID",
                table: "LignesBus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Billets",
                table: "Billets");

            migrationBuilder.DropIndex(
                name: "IX_Billets_CompagnieID",
                table: "Billets");

            migrationBuilder.DropColumn(
                name: "LigneID",
                table: "LignesBus");

            migrationBuilder.DropColumn(
                name: "NewBilletID",
                table: "Billets");

            migrationBuilder.DropColumn(
                name: "DateVoyage",
                table: "Billets");

            migrationBuilder.DropColumn(
                name: "NomUtilisateur",
                table: "Billets");

            migrationBuilder.RenameColumn(
                name: "NomVille",
                table: "Villes",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "VilleID",
                table: "Villes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VilleDepartID",
                table: "LignesBus",
                newName: "VilleDepartId");

            migrationBuilder.RenameColumn(
                name: "VilleArriveeID",
                table: "LignesBus",
                newName: "VilleArriveeId");

            migrationBuilder.RenameColumn(
                name: "NomLigne",
                table: "LignesBus",
                newName: "Nom");

            migrationBuilder.RenameColumn(
                name: "CompagnieID",
                table: "LignesBus",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_LignesBus_VilleDepartID",
                table: "LignesBus",
                newName: "IX_LignesBus_VilleDepartId");

            migrationBuilder.RenameIndex(
                name: "IX_LignesBus_VilleArriveeID",
                table: "LignesBus",
                newName: "IX_LignesBus_VilleArriveeId");

            migrationBuilder.RenameColumn(
                name: "StatutPaiement",
                table: "Billets",
                newName: "Statut");

            migrationBuilder.RenameColumn(
                name: "NumeroSiege",
                table: "Billets",
                newName: "UtilisateurId");

            migrationBuilder.RenameColumn(
                name: "LigneID",
                table: "Billets",
                newName: "BusId");

            migrationBuilder.RenameColumn(
                name: "CompagnieID",
                table: "Billets",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Billets_LigneID",
                table: "Billets",
                newName: "IX_Billets_BusId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LignesBus",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Billets",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LignesBus",
                table: "LignesBus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Billets",
                table: "Billets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LigneBusId = table.Column<int>(type: "int", nullable: false),
                    DateDepart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bus_LignesBus_LigneBusId",
                        column: x => x.LigneBusId,
                        principalTable: "LignesBus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_LigneBusId",
                table: "Bus",
                column: "LigneBusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Billets_Bus_BusId",
                table: "Billets",
                column: "BusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesBus_Villes_VilleArriveeId",
                table: "LignesBus",
                column: "VilleArriveeId",
                principalTable: "Villes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LignesBus_Villes_VilleDepartId",
                table: "LignesBus",
                column: "VilleDepartId",
                principalTable: "Villes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
