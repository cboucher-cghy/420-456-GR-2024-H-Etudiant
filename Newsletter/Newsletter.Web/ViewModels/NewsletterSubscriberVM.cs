using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class NewsletterSubscriberVM : IValidatableObject
    {
        public int Id { get; set; }
        public string Email { get; set; } = default!;
        public bool IsConfirmed { get; set; }

        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateFin.CompareTo(DateDebut) <= 0)
            {
                yield return new ValidationResult($"La date de début ({DateDebut:yyyy-MM-dd}) doit être avant la date de fin({DateFin:yyyy-MM-dd}).");
            }

            if (DateFin.AddMonths(1).CompareTo(DateDebut) <= 0)
            {
                yield return new ValidationResult($"La date de fin ({DateFin:yyyy-MM-dd}) doit être au moins un mois après la date de début({DateDebut:yyyy-MM-dd}).");
            }

        }
    }
}
