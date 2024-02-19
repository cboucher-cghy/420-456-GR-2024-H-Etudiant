using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class NewsletterRegisterVM
    {
        [Required]
        public string Email { get; set; } = default!;
    }
}
