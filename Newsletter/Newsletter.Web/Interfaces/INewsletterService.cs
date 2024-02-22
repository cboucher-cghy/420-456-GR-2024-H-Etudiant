using GeniusChuck.Newsletter.Web.Models;

namespace GeniusChuck.Newsletter.Web.Interfaces
{
    public interface INewsletterService
    {
        List<Subscriber> GetSubscribers();
        int Subscribe(Subscriber subscriber);
        int Unsubscribe(string email);
    }
}
