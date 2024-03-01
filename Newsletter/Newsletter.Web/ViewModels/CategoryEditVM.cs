using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class CategoryEditVM
    {
        [Required]
        [DisplayName("Identifiant")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nom de la catégorie")]
        public string Name { get; set; } = default!;

        [MinLength(3, ErrorMessage = "Description trop courte")]
        [MaxLength(50, ErrorMessage = "Description trop longue")]
        public string Description { get; set; } = default!;

    }
}
