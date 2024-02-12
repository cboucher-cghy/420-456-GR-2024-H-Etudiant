using GeniusChuck.NewsletterExample.Interfaces;
using GeniusChuck.NewsletterExample.Models;

namespace GeniusChuck.NewsletterExample.Services
{
    public class NewsletterInMemoryService() : INewsletterService
    {
        private readonly HashSet<Subscriber> _context = new();

        public List<Subscriber> GetSubscribers() => new();

        public void Subscribe(Subscriber subscriber)
        {
            _context.Add(subscriber);
        }

        public void Unsubscribe(string email)
        {
            var subscriber = _context.FirstOrDefault(s => s.Email == email);
            if (subscriber != null)
            {
                _context.Remove(subscriber);
            }
        }
    }
}
