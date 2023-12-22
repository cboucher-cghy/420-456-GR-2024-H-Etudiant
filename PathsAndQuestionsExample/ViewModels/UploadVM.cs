using System.ComponentModel.DataAnnotations;

namespace UploadExample.ViewModels
{
    public class UploadVM
    {
        [Required(ErrorMessage = "Veuillez entrer un nom de fichier")]
        [Display(Name = "Nom du fichier")]
        [StringLength(100)]
        public string FileName { get; set; } = default!;

        [Required(ErrorMessage = "Veuillez choisir un fichier")]
        [Display(Name = "Fichier à téléverser")]
        public IFormFile CustomFile { get; set; } = default!;
    }
}
