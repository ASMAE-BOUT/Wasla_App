namespace Wasla_App.Models
{
    public class LigneBus
    {
        public int LigneID { get; set; }
        public string NomLigne { get; set; } = string.Empty;
        public int VilleDepartID { get; set; }
        public int VilleArriveeID { get; set; }
        public int CompagnieID { get; set; }

        public Ville VilleDepart { get; set; }
        public Ville VilleArrivee { get; set; }
        public Compagnie Compagnie { get; set; }
    }
}
