using GeniusChuck.NewsletterExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeniusChuck.NewsletterExample.Controllers
{
    public class HomeController() : Controller
    {
        //[Route("yoyoyo")]
        //[Route("admin")]
        //[Route("{controller}/{action}/{name:minlength(2)}")]
        public IActionResult Index(/*string? name = "Chuck", [FromQuery] string? lastname = "Norris"*/)
        {
            return View();
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
