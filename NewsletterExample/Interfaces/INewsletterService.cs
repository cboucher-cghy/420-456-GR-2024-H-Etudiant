using GeniusChuck.NewsletterExample.Models;

namespace GeniusChuck.NewsletterExample.Interfaces
{
    public interface INewsletterService
    {
        List<Subscriber> GetSubscribers();
        int Subscribe(Subscriber subscriber);
        int Unsubscribe(string email);
    }
}
