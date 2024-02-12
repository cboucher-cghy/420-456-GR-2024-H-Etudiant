using GeniusChuck.NewsletterExample.Data;
using GeniusChuck.NewsletterExample.Interfaces;
using GeniusChuck.NewsletterExample.Models;

namespace GeniusChuck.NewsletterExample.Services
{
    public class NewsletterService(ApplicationDbContext context) : INewsletterService
    {
        public List<Subscriber> GetSubscribers() => context.Subscribers.ToList();

        public void Subscribe(Subscriber subscriber)
        {
            context.Subscribers.Add(subscriber);
            context.SaveChanges();
        }

        public void Unsubscribe(string email)
        {
            var subscriber = context.Subscribers.FirstOrDefault(s => s.Email == email);
            if (subscriber != null)
            {
                context.Subscribers.Remove(subscriber);
                context.SaveChanges();
            }
        }
    }
}
