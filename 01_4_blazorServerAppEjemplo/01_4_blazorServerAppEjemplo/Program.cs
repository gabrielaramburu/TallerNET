using _01_4_blazorServerAppEjemplo.Components;
using _01_4_blazorServerAppEjemplo.Infraestructure.Data;
using _01_4_blazorServerAppEjemplo.Models;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Para que funcionen los componentes
builder.Services.AddRadzenComponents();

builder.Services.AddSingleton<IVehiculoRepository, VehiculoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.Run();
