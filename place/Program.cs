using Microsoft.EntityFrameworkCore;
using place.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Ajout des services de contrôleurs avec vues
builder.Services.AddControllersWithViews();

// Inscription de place en tant que service de base de données
builder.Services.AddDbContext<PlaceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajout du filtre d'exception pour le développement de la base de données
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Ajout des services de contrôleurs avec vues
builder.Services.AddControllersWithViews();

var app = builder.Build();

// NEW Utiliser la page d'exception pour le développement
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles(); // NEW Pour servir les fichiers statiques (important pour les fichiers CSS, JS, images, etc.)

app.UseRouting(); // NEWActivation du routage

// Configuration des endpoints
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

// logique de vérification et d'initialisation de la base de données
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<PlaceContext>();
        DbInitializer.Initialize(context); // Initialiser la B.D,
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}
app.UseDeveloperExceptionPage();

app.Run();
