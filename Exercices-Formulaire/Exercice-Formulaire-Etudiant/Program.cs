using Exercice_Formulaire_Etudiant.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (builder.Environment.IsDevelopment())
{
    // Ajouter le RazorRuntimeCompilation seulement lorsqu'on est en mode développement
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
}
else
{
    builder.Services.AddControllersWithViews();
}

CultureInfo ci = new("fr-CA");
CultureInfo.DefaultThreadCurrentCulture = ci;

//string cultureName = Thread.CurrentThread.CurrentCulture.Name;
//CultureInfo ci = new(CultureName);
//CultureInfo.DefaultThreadCurrentUICulture = ci;
//Thread.CurrentThread.CurrentUICulture = ci;
//Thread.CurrentThread.CurrentCulture = ci;

builder.Services.AddDbContext<ApplicationDbContext>(x =>
{
    x.UseLoggerFactory(LoggerFactory.Create(builder => { builder.AddConsole(); }));
    x.EnableSensitiveDataLogging();
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
