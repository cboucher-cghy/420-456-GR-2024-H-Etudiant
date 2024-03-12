using System.ComponentModel.DataAnnotations;

namespace GeniusChuck.Newsletter.Web.Validations
{
    public class CourrielDuCegepSeulementAttribute : ValidationAttribute
    {
        public CourrielDuCegepSeulementAttribute()
        {

        }
        private readonly string? _nomDomaineCourriel = "cegepgranby.qc.ca";

        public string NomDomaineCourriel
        {
            get
            {
                return $"@" + _nomDomaineCourriel;
            }

            init // Permet l'initialisation seulement depuis le constructeur.
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _nomDomaineCourriel = value;
                }
            }
        }

        /// <summary>
        /// Indique le nom de domaine à utiliser (sans le "@")
        /// </summary>
        /// <param name="nomDomaineCourriel">Nom de domaine du courriel</param>
        /// <example>cepepgranby.qc.ca</example>
        public CourrielDuCegepSeulementAttribute(string nomDomaineCourriel)
        {
            _nomDomaineCourriel = nomDomaineCourriel;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            //Mon code de validation ici!!!
            if (value == null)
            {
                return new ValidationResult("L'objet ne doit pas être null");
            }

            if (value!.GetType() != typeof(string))
            {
                return new ValidationResult("Ne s'applique que sur un type String");
            }

            var courriel = (string)value;
            if (!courriel.EndsWith(NomDomaineCourriel))
            {
                return new ValidationResult("Le courriel n'est pas celui-du cégep.");
            }

            return ValidationResult.Success!;
        }
    }
}
