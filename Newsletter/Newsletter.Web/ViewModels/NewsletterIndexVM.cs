namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class NewsletterIndexVM
    {
        public IEnumerable<NewsletterSubscriberVM> Subscribers { get; set; } = new List<NewsletterSubscriberVM>();

        public NewsletterRegisterVM Register { get; set; } = new NewsletterRegisterVM();
    }
}
