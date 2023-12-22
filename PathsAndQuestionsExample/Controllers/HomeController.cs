using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UploadExample.Models;
using UploadExample.ViewModels;

namespace UploadExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        public IActionResult Upload(UploadVM vm)
        {
            string folder = Path.Combine(Directory.GetCurrentDirectory(), "Upload");
            //string folder = Path.Combine(HttpContext.Request.Host.Value, "Upload");
            string uniqueFileName = vm.FileName;
            string filePath = Path.Combine(folder, uniqueFileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            vm.CustomFile.CopyTo(fileStream);

            return Ok();
        }
    }
}