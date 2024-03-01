using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class CategoryDetailsVM
    {
        [DisplayName("Identifiant")]
        public int Id { get; set; }

        [DisplayName("Nom de la catégorie")]
        public string Name { get; set; } = default!;

        [MinLength(3)]
        public string Description { get; set; } = default!;

        [DisplayName("Ajouté le")]
        public DateTime CreatedAt { get; set; }
    }
}
