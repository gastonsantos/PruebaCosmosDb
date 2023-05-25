using PruebaMongo.Repository;
using PruebaMongo.Services;
using PruebaMongo.Services.Agents;
using PruebaMongo.Services.Properties;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IAgentRepository, AgentRepository>();
builder.Services.AddSingleton<IPropertyRepository, PropertyRepository>();

builder.Services.AddSingleton<IPropertyService, PropertyService>();
builder.Services.AddSingleton<IAgentService, AgentService>();

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
