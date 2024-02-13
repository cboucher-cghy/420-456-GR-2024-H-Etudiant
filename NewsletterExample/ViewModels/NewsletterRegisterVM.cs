using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.NewsletterExample.ViewModels
{
    public class NewsletterRegisterVM
    {
        [Required]
        public string Email { get; set; } = default!;
    }
}
