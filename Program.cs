using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Fixtures;
using WebApplication.services.Impl;
using WebApplication.services;


var builder = WebApplication.CreateBuilder(args);

// Configure the database connection string
string connectionString = builder.Configuration.GetConnectionString("MysqlConnection")!;

builder.Services.AddDbContext<ApplicationDbContext>(options =>

            options.UseMySql(connectionString,

            new MySqlServerVersion(new Version(8, 0, 40))));


// Configure the services for the application.
/* 
    AddTransient => Cr�er � chaque fois
    AddScoped => Cr�er une instance unique pour la dur�e de la requ�te
    AddSingleton => Cr�er une instance unique pour toute la dur�e de l'application
 */
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IDetteService, DetteService>();
builder.Services.AddScoped<IPaiementService, PaiementService>();
builder.Services.AddScoped<ClientFixtures>();




// Add services to the container.
builder.Services.AddControllersWithViews();


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

// Called Before Routing

app.UseRouting();

// Called After Routing

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}"
);

// Load Fixtures
using (var scope = app.Services.CreateScope())

{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<ClientFixtures>();
    seeder.Load();
}
// Un Provider est quelqu'un ou quelque chose qui fournit quelque chose
app.Run();
