using System.ComponentModel.DataAnnotations;

namespace Exercice_Formulaire_Etudiant.Models
{
    public class Departement
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nom { get; set; } = default!;

        public double Budget { get; set; }

        public List<Employe> Employes { get; set; } = default!;
    }
}