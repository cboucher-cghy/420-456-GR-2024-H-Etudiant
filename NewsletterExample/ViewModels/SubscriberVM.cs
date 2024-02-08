namespace GeniusChuck.NewsletterExample.ViewModels
{
    public class SubscriberVM
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public bool IsSubscribed { get; set; }
    }
}
