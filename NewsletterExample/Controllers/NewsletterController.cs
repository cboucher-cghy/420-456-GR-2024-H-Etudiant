using GeniusChuck.NewsletterExample.Interfaces;
using GeniusChuck.NewsletterExample.Models;
using GeniusChuck.NewsletterExample.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeniusChuck.NewsletterExample.Controllers
{
    public class NewsletterController(INewsletterService newsletterService) : Controller
    {
        private readonly INewsletterService _newsletterService = newsletterService;

        [HttpGet]
        public ActionResult<List<SubscriberVM>> Index()
        {
            return View(_newsletterService.GetSubscribers()
                .Select(x =>
                        new SubscriberVM()
                        {
                            Id = x.Id,
                            Courriel = x.Email,
                            IsSubscribed = x.IsSubscribed
                        })
                );
        }

        [HttpPost]
        [HttpPut]
        //[AcceptVerbs(nameof(HttpMethods.Post), nameof(HttpMethods.Put))]
        [ActionName(nameof(Index))]
        public ActionResult<List<Subscriber>> Index(string email)
        {

            var subscribers = _newsletterService.GetSubscribers();
            return View(subscribers);
        }

        [HttpPost]
        public ActionResult Subscribe(Subscriber subscriber)
        {
            _newsletterService.Subscribe(subscriber);
            return RedirectToAction(nameof(Index));
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
