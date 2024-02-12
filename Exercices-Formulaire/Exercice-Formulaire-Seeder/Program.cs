using Bogus;
using Exercice_Formulaire_Etudiant.Models;
using Exercice_Formulaire_Seeder;

// https://github.com/bchavez/Bogus/tree/master/Examples/EFCoreSeedDb

Console.WriteLine("Début du seed!");
using var context = DbContextFactory.CreateDbContext();

// Vidange de la table
context.Departements.RemoveRange(context.Departements);
context.Employes.RemoveRange(context.Employes);
context.SaveChanges();

//Création des départements
var budgetFaker = new Faker();
List<Departement> departements =
            [
                new Departement() { Nom = "Finance", Budget = double.Round(budgetFaker.Random.Double(20000, 65000), 2) },
                new Departement() { Nom = "Informatique", Budget = double.Round(budgetFaker.Random.Double(20000, 65000), 2) },
                new Departement() { Nom = "Ressources humaines", Budget = double.Round(budgetFaker.Random.Double(20000, 65000), 2) },
                new Departement() { Nom = "Développement", Budget = double.Round(budgetFaker.Random.Double(20000, 65000), 2) },
            ];

context.Departements.AddRange(departements);
context.SaveChanges();

List<Pays> pays = [.. context.Pays];

//Création des employés
var generator = new Faker();

var employesFaker = new Faker<Employe>()
    .RuleFor(e => e.Id, 0) // Nécessaire à cause de IDENTITY dans la BD
    .RuleFor(e => e.Nom, f => f.Person.FullName)
    .RuleFor(e => e.Age, f => f.Random.Int(22, 55))
    .RuleFor(e => e.DateEmbauche, f => f.Date.Between(new DateTime(2017, 01, 01), new DateTime(2022, 02, 02)))
    .RuleFor(e => e.SalaireAnnuel, f => double.Round(f.Random.Double(38000, 95000), 2))
    .RuleFor(e => e.PaysOrigine, f => f.PickRandom(pays))
    .RuleFor(e => e.DepartementId, f => f.PickRandom(departements).Id)
    .FinishWith((f, e) =>
    {
        e.EstEnEmploi = f.PickRandom(true, false);
    });

var employes = employesFaker.Generate(500);

context.Employes.AddRange(employes);
Console.WriteLine($"Sauvegarde des entités {nameof(Employe)} dans la BD");
context.SaveChanges();
