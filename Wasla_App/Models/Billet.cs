namespace Wasla_App.Models
{
    public class Billet
    {
        public int NewBilletID { get; set; }
        public int LigneID { get; set; }
        public int CompagnieID { get; set; }
        public string NomUtilisateur { get; set; } = string.Empty;
        public DateTime DateVoyage { get; set; }
        public int NumeroSiege { get; set; }
        public string StatutPaiement { get; set; } = string.Empty;

        public LigneBus LigneBus { get; set; }
        public Compagnie Compagnie { get; set; } 
    }
}
