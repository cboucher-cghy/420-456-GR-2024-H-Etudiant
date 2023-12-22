using GeniusChuck.NewsletterExample.Interfaces;
using GeniusChuck.NewsletterExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeniusChuck.NewsletterExample.Controllers
{
    public class NewsletterController(INewsletterService newsletterService) : Controller
    {
        private readonly INewsletterService _newsletterService = newsletterService;

        [HttpGet]
        public ActionResult<List<Subscriber>> Index()
        {
            return View(_newsletterService.GetSubscribers());
        }

        [HttpPost]
        public ActionResult<Subscriber> Subscribe(Subscriber subscriber)
        {
            _newsletterService.Subscribe(subscriber);
            return View();
        }

        [HttpGet]
        public ActionResult Unsubscribe()
        {
            return View();
        }

        [HttpPost]
        [ActionName(nameof(Unsubscribe))]
        public ActionResult UnsubscribePost(string email)
        {
            _newsletterService.Unsubscribe(email);
            return View();
        }
    }
}
