using MongoFramework;
using PruebaMongo.Repository;
using PruebaMongo.Services;
using PruebaMongo.Services.Agents;
using PruebaMongo.Services.Properties;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configura Repositories and Services.
builder.Services.AddSingleton<IAgentRepository, AgentRepository>();
builder.Services.AddSingleton<IAgentService, AgentService>();
builder.Services.AddSingleton<IPropertyRepository, PropertyRepository>();
builder.Services.AddSingleton<IPropertyService, PropertyService>();

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
    pattern: "{controller=Property}/{action=Listar}/{id?}");

app.Run();
