using GeniusChuck.NewsletterExample.Data;
using GeniusChuck.NewsletterExample.Interfaces;
using GeniusChuck.NewsletterExample.Models;

namespace GeniusChuck.NewsletterExample.Services
{
    public class NewsletterService(ApplicationDbContext context) : INewsletterService
    {
        private readonly ApplicationDbContext _context = context;

        public List<Subscriber> GetSubscribers() => _context.Subscribers.ToList();

        public void Subscribe(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();
        }

        public void Unsubscribe(string email)
        {
            var subscriber = _context.Subscribers.FirstOrDefault(s => s.Email == email);
            if (subscriber != null)
            {
                _context.Subscribers.Remove(subscriber);
                _context.SaveChanges();
            }
        }
    }
}
