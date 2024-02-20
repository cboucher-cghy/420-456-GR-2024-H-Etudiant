namespace GeniusChuck.Newsletter.Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public ICollection<Subscriber> Subscribers { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
