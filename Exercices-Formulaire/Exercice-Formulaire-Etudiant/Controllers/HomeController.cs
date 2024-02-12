using Exercice_Formulaire_Etudiant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exercice_Formulaire_Etudiant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(HomeVM vm)
        {
            vm.Price = 9.9;
            return View(vm);
        }

        [HttpPost]
        public IActionResult IndexPost(HomeVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            TempData["message"] = "Valeur bien reçue.";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}