using GeniusChuck.Newsletter.Web.Data;
using GeniusChuck.Newsletter.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeniusChuck.Newsletter.Web.Controllers
{
    public class HomeController(ApplicationDbContext context) : Controller
    {
        public IActionResult Index()
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