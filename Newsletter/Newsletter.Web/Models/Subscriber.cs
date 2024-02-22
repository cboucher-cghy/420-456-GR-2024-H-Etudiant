namespace GeniusChuck.Newsletter.Web.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public bool IsConfirmed { get; set; } = false;
        public DateTime RegistrationDate { get; }
        public ICollection<Category> Categories { get; set; } = default!;
        public int CategoryId { get; set; }

    }
}
