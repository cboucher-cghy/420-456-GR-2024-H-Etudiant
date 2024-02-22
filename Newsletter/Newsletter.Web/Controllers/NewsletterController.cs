using GeniusChuck.Newsletter.Web.Data;
using GeniusChuck.Newsletter.Web.Interfaces;
using GeniusChuck.Newsletter.Web.Models;
using GeniusChuck.Newsletter.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeniusChuck.Newsletter.Web.Controllers
{
    public class NewsletterController(INewsletterService newsletterService, ApplicationDbContext context) : Controller
    {
        private readonly INewsletterService _newsletterService = newsletterService;
        private readonly ApplicationDbContext context = context;

        [HttpGet]
        public ActionResult<NewsletterIndexVM> Index()
        {
            var vm = new NewsletterIndexVM()
            {
                Subscribers = _newsletterService.GetSubscribers()
                    .Select(x => new NewsletterSubscriberVM()
                    {
                        Id = x.Id,
                        Email = x.Email,
                        IsConfirmed = x.IsConfirmed
                    }),
            };

            return View(vm);
        }

        [HttpPost]
        [HttpPut]
        //[AcceptVerbs(nameof(HttpMethods.Post), nameof(HttpMethods.Put))]
        [ActionName(nameof(Index))]
        public ActionResult<List<NewsletterSubscriberVM>> Index(NewsletterRegisterVM vm)
        {
            _newsletterService.Subscribe(new Subscriber() { Email = vm.Email });
            TempData["Message"] = "You have been subscribed to our newsletter!";
            return View(nameof(Index));
        }

        [HttpPost]
        public ActionResult Subscribe(NewsletterSubscriberVM vm)
        {
            _newsletterService.Subscribe(new Subscriber()
            {
                Email = vm.Email,
                Id = 0,
            });

            //_newsletterService.Subscribe(subscriber);
            TempData["Message"] = "You have been subscribed to our newsletter!";
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

        public ActionResult List()
        {
            return View("_SubscriberPartial", new NewsletterSubscriberVM());
        }

        public ActionResult ListPartial()
        {
            return PartialView("_SubscriberPartial", new NewsletterSubscriberVM());
        }
    }
}
