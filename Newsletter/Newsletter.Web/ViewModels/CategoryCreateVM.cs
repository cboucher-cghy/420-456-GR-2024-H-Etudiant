using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.ViewModels
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage = "Le champ [{0}] est requis.")] // Utilisation du {0} pour référencer le nom d'affichage de la propriété.
        [DisplayName("Nom de la catégorie")]
        public string Name { get; set; } = default!;

        // Le champ est requis, car il est non-null. Avec la configuration dans "Program.cs", le message par défaut est changé par ce qui est dans le fichier ressources "MyAnnotations.resx"
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Le champ {0} doit être entre {2} et {1} caractères.")]

        public string Description { get; set; } = default!;
    }
}
