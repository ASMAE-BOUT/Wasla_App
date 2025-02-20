using Microsoft.EntityFrameworkCore.Migrations;

namespace Wasla_App.Migrations
{
    public partial class AdjustInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Vérifier si la table 'Villes' existe déjà avant de la créer
            migrationBuilder.Sql(@"
                IF OBJECT_ID('dbo.Villes', 'U') IS NULL
                BEGIN
                    CREATE TABLE [dbo].[Villes] (
                        [Id] INT NOT NULL IDENTITY,
                        [Nom] NVARCHAR(MAX) NOT NULL,
                        CONSTRAINT [PK_Villes] PRIMARY KEY ([Id])
                    );
                END
            ");

            // Vérifier si la table 'LignesBus' existe déjà avant de la créer
            migrationBuilder.Sql(@"
                IF OBJECT_ID('dbo.LignesBus', 'U') IS NULL
                BEGIN
                    CREATE TABLE [dbo].[LignesBus] (
                        [Id] INT NOT NULL IDENTITY,
                        [Nom] NVARCHAR(MAX) NOT NULL,
                        [VilleDepartId] INT NOT NULL,
                        [VilleArriveeId] INT NOT NULL,
                        CONSTRAINT [PK_LignesBus] PRIMARY KEY ([Id]),
                        CONSTRAINT [FK_LignesBus_Villes_VilleArriveeId] FOREIGN KEY ([VilleArriveeId]) REFERENCES [Villes] ([Id]) ON DELETE CASCADE,
                        CONSTRAINT [FK_LignesBus_Villes_VilleDepartId] FOREIGN KEY ([VilleDepartId]) REFERENCES [Villes] ([Id]) ON DELETE CASCADE
                    );
                END
            ");

            // Vérifier si la table 'Utilisateurs' existe déjà avant de la créer
            migrationBuilder.Sql(@"
                IF OBJECT_ID('dbo.Utilisateurs', 'U') IS NULL
                BEGIN
                    CREATE TABLE [dbo].[Utilisateurs] (
                        [Id] INT NOT NULL IDENTITY,
                        [Nom] NVARCHAR(MAX) NOT NULL,
                        [Email] NVARCHAR(MAX) NOT NULL,
                        [MotDePasse] NVARCHAR(MAX) NOT NULL,
                        CONSTRAINT [PK_Utilisateurs] PRIMARY KEY ([Id])
                    );
                END
            ");

            // Continuez avec d'autres tables (Billets, Bus, etc.) en vérifiant leur existence avant de les créer
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Ici, vous pouvez choisir de ne pas supprimer les tables qui existent déjà
            migrationBuilder.DropTable(name: "Billets");
            migrationBuilder.DropTable(name: "Utilisateurs");
            migrationBuilder.DropTable(name: "Bus");
            migrationBuilder.DropTable(name: "LignesBus");
            // Ne pas supprimer la table 'Villes' si elle est utilisée par ailleurs
        }
    }
}
