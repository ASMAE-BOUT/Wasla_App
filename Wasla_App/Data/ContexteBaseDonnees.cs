using Microsoft.EntityFrameworkCore;
using Wasla_App.Models;
using Microsoft.Extensions.Logging;

namespace Wasla_App.Data
{
    public class ContexteBaseDonnees : DbContext
    {
        public ContexteBaseDonnees(DbContextOptions<ContexteBaseDonnees> options) : base(options)
        {
            // Activer la journalisation des requêtes SQL
            this.Database.GetDbConnection().StateChange += (sender, e) =>
            {
                if (e.CurrentState == System.Data.ConnectionState.Open)
                {
                    var command = ((System.Data.Common.DbConnection)sender).CreateCommand();
                    command.CommandText = "SET STATISTICS TIME ON;";
                    command.ExecuteNonQuery();
                }
            };

            // Vous pouvez aussi utiliser un logger pour afficher les logs SQL
            // Utilisation du niveau de journalisation Debug
            var loggerFactory = new LoggerFactory();
            var logger = loggerFactory.CreateLogger<ContexteBaseDonnees>();
            logger.LogInformation("ContexteBaseDonnees initialized");
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<LigneBus> LignesBus { get; set; }
        public DbSet<Billet> Billets { get; set; }
        public DbSet<Compagnie> Compagnies { get; set; }  // Assuming you have a Compagnie model

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Billet>()
                .HasKey(b => b.NewBilletID);

            modelBuilder.Entity<LigneBus>()
                .HasKey(l => l.LigneID);

            modelBuilder.Entity<Ville>()
                .HasKey(v => v.VilleID);

            modelBuilder.Entity<Compagnie>()
                .HasKey(c => c.CompagnieID);

            modelBuilder.Entity<LigneBus>()
                .HasOne(l => l.VilleDepart)
                .WithMany()
                .HasForeignKey(l => l.VilleDepartID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LigneBus>()
                .HasOne(l => l.VilleArrivee)
                .WithMany()
                .HasForeignKey(l => l.VilleArriveeID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LigneBus>()
                .HasOne(l => l.Compagnie)
                .WithMany()
                .HasForeignKey(l => l.CompagnieID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Billet>()
                .HasOne(b => b.LigneBus)
                .WithMany()
                .HasForeignKey(b => b.LigneID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Billet>()
                .HasOne(b => b.Compagnie)
                .WithMany()
                .HasForeignKey(b => b.CompagnieID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
