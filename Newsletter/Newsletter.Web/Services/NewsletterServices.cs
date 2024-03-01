using GeniusChuck.Newsletter.Web.Data;
using GeniusChuck.Newsletter.Web.Interfaces;
using GeniusChuck.Newsletter.Web.Models;

namespace GeniusChuck.Newsletter.Web.Services
{
    public class NewsletterService(ApplicationDbContext context) : INewsletterService
    {
        private readonly ApplicationDbContext _context = context;

        public List<Subscriber> GetSubscribers() => _context.Subscribers.Take(5000).ToList(); // Limit the number to avoid OOM

        public int Subscribe(Subscriber subscriber)
        {
            _context.Subscribers.Add(subscriber);
            return _context.SaveChanges();
        }

        public int Unsubscribe(string email)
        {
            var subscriber = _context.Subscribers.FirstOrDefault(s => s.Email == email);
            if (subscriber != null)
            {
                _context.Subscribers.Remove(subscriber);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
