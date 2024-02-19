// See https://aka.ms/new-console-template for more information
using Bogus;
using EFCore_Seeder;
using GeniusChuck.Newsletter.Web.Models;

Console.WriteLine("Hello, World!");

var context = DbContextFactory.CreateDbContext();

context.Subscribers.RemoveRange();
context.CategorySubscriber.RemoveRange();

context.SaveChanges();

var categories = context.Categories.ToList();

var subscribersFaker = new Faker<Subscriber>();
subscribersFaker
    .RuleFor(s => s.Email, f => f.Internet.Email())
    .RuleFor(s => s.IsConfirmed, f => f.Random.Bool(0.8f))
    .FinishWith((f, s) =>
    {
        s.Categories = f.PickRandom(categories, f.Random.Number(1, 3)).ToList();
        //s.Id = 0;
    });

var subcribers = subscribersFaker.Generate(5_000);

context.Subscribers.AddRange(subcribers);
context.SaveChanges();


// NE FONCTIONNE PAS - NOT WORKING - NE PAS FAIRE
//var catSubFaker = new Faker<CategorySubscriber>();
//catSubFaker
//    .RuleFor(x => x.CategoryId, f => f.PickRandom(categories).Id)
//    .RuleFor(x => x.SubscriberId, f => f.PickRandom(subcribers).Id);

//var catSub = catSubFaker.Generate(subcribers.Count);
//context.CategorySubscriber.AddRange(catSub);
//context.SaveChanges();

Console.WriteLine("Terminé");
