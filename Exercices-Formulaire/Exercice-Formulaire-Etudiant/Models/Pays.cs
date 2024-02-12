namespace Exercice_Formulaire_Etudiant.Models
{
    public class Pays
    {
        public int Id { get; set; }
        public string Nom { get; set; } = default!;
        public int Superficie { get; set; }
        public List<Employe> Employes { get; set; } = default!;
    }
}