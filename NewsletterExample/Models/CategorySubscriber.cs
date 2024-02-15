namespace GeniusChuck.NewsletterExample.Models
{
    public class CategorySubscriber
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;

        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; } = default!;

        public DateTime SubscriptionDate { get; set; }
    }
}
