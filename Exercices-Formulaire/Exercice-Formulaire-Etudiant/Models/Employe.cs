using System.ComponentModel.DataAnnotations;

namespace Exercice_Formulaire_Etudiant.Models
{
    public class Employe
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; } = default!;

        [Range(18, 75)]
        public int Age { get; set; }

        public DateTime DateEmbauche { get; set; }

        public double SalaireAnnuel { get; set; }

        public bool EstEnEmploi { get; set; }

        public int PaysId { get; set; }
        public Pays? PaysOrigine { get; set; } = default!;

        public int DepartementId { get; set; }
        public Departement? Departement { get; set; } = default!;
    }
}