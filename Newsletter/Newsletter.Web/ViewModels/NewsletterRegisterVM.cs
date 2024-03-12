using GeniusChuck.Newsletter.Web.Validations;
using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class NewsletterRegisterVM
    {
        [Required]
        [CourrielDuCegepSeulement]
        public string Email { get; set; } = default!;
    }
}
