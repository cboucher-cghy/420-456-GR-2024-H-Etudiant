using GeniusChuck.NewsletterExample.Models;

namespace GeniusChuck.NewsletterExample.Interfaces
{
    public interface INewsletterService
    {
        List<Subscriber> GetSubscribers();
        void Subscribe(Subscriber subscriber);
        void Unsubscribe(string email);
    }
}
