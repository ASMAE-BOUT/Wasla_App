using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wasla_App.Data;
using Wasla_App.Models;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Wasla_App.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ContexteBaseDonnees _context;

        public ReservationController(ContexteBaseDonnees context)
        {
            _context = context;
        }

        // GET: /Reservation/Reserver
        [HttpGet]
        public IActionResult Reserver()
        {
            var villes = _context.Villes.ToList();

            if (villes == null || !villes.Any())
            {
                return ShowError("Aucune donnée trouvée pour les villes.");
            }

            ViewBag.Villes = villes;
            return View();
        }

        // GET: /Reservation/RechercherBus
        [HttpGet]
        public IActionResult RechercherBus(int depart, int arrivee, DateTime dateVoyage, int voyageurs)
        {
            if (depart == 0)
            {
                Console.WriteLine("Erreur: Le champ 'depart' est vide.");
            }
            if (arrivee == 0)
            {
                Console.WriteLine("Erreur: Le champ 'arrivee' est vide.");
            }
            if (dateVoyage == default)
            {
                Console.WriteLine("Erreur: Le champ 'dateVoyage' est vide ou mal formaté.");
            }
            if (voyageurs == 0)
            {
                Console.WriteLine("Erreur: Le champ 'voyageurs' est vide.");
            }

            if (depart == 0 || arrivee == 0 || dateVoyage == default || voyageurs == 0)
            {
                ViewBag.ErrorMessage = "Veuillez remplir tous les champs.";
                return View("~/Views/Home/Index.cshtml");
            }

            var availableLignes = _context.LignesBus
                .Include(lb => lb.VilleDepart)
                .Include(lb => lb.VilleArrivee)
                .Include(lb => lb.Compagnie)
                .Where(lb => lb.VilleDepart.VilleID == depart && lb.VilleArrivee.VilleID == arrivee)
                .ToList();

            if (!availableLignes.Any())
            {
                ViewBag.ErrorMessage = "Aucune ligne de bus disponible pour les critères de recherche spécifiés.";
                return ShowError();
            }

            ViewBag.Voyageurs = voyageurs;
            ViewBag.DateVoyage = dateVoyage;

            return View("~/Views/Reservation/Resultats.cshtml", availableLignes);
        }

        // POST: /Reservation/ReserverBillet
        [HttpPost]
        public async Task<IActionResult> ReserverBillet(int ligneBusId, DateTime dateVoyage)
        {
            var ligneBus = await _context.LignesBus.FindAsync(ligneBusId);
            if (ligneBus == null)
            {
                return ShowError("Ligne de bus introuvable.");
            }

            var billet = new Billet
            {
                LigneID = ligneBusId,
                CompagnieID = ligneBus.CompagnieID,
                DateVoyage = dateVoyage,
                StatutPaiement = "Réservé"
            };

            _context.Billets.Add(billet);
            await _context.SaveChangesAsync();

            return RedirectToAction("Suivre", new { billetId = billet.NewBilletID });
        }

        // GET: /Reservation/Suivre
        [HttpGet]
        public IActionResult Suivre(int billetId)
        {
            var billet = _context.Billets
                .Include(b => b.LigneBus)
                    .ThenInclude(lb => lb.VilleDepart)
                .Include(b => b.LigneBus.VilleArrivee)
                .SingleOrDefault(b => b.NewBilletID == billetId);

            if (billet == null)
            {
                return ShowError("Billet introuvable.");
            }

            return View(billet);
        }

        // Helper method to display error view
        private IActionResult ShowError(string message = null)
        {
            var errorModel = new ErrorModel
            {
                RequestId = HttpContext.TraceIdentifier
            };

            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = message;
            }

            return View("~/Views/Error.cshtml", errorModel);
        }
    }
}