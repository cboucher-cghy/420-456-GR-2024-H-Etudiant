using GeniusChuck.NewsletterExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeniusChuck.NewsletterExample.Controllers
{
    public class HomeController : Controller
    {
        //[Route("yoyoyo")]
        //[Route("admin")]
        [Route("{controller}/{action}/{name:minlength(2)}")]
        public IActionResult Index(string name, [FromQuery] string? lastname)
        {
            var person = new Person();

            if (DateTime.Now.Second % 2 == 0)
            {
                person.Name = name;
            }
            else
            {
                person.Name = name;
            }

            return View(person);
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
