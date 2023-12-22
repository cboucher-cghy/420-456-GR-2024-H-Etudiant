namespace GeniusChuck.NewsletterExample.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public bool IsSubscribed { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
