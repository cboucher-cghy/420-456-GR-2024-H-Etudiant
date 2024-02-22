namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class NewsletterSubscriberVM
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public bool IsConfirmed { get; set; }
    }
}
