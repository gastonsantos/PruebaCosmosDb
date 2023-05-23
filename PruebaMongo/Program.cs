using PruebaMongo.Repository;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IProductCollection, ProductRepository>();
builder.Services.AddSingleton<IPropiedadCollection, PropertyRepository>();

var configuration = builder.Configuration;



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
    pattern: "{controller=Propiedad}/{action=Listar}/{id?}");

app.Run();
