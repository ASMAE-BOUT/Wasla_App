using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // N'oubliez pas d'ajouter cette directive using
using Wasla_App.Data;
using Wasla_App.Models;
using System.Linq;

namespace Wasla_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContexteBaseDonnees _context;

        public HomeController(ContexteBaseDonnees context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Récupérer toutes les villes
            var villes = _context.Villes.ToList();

            // Vérifier si les villes existent
            if (villes == null || !villes.Any())
            {
                ViewBag.ErrorMessage = "Aucune ville disponible actuellement.";
                return View("~/Views/Error.cshtml");
            }

            // Passer les villes dans le ViewBag
            ViewBag.Villes = villes;

            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Error(string message)
        {
            ViewBag.ErrorMessage = message ?? "Une erreur inattendue s'est produite.";
            return View();
        }
    }
}
