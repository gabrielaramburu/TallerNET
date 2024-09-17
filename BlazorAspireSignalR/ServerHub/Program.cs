using Radzen;
using ServerHub.Components;
using ServerHub.Components.Pages;
using ServerHub.Hubs;
using ServerHub.Messaging;
using ServerHub.Models;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPanelControl, Panel>();

builder.Services.AddTransient<ColaRabbitMQ>();

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRadzenComponents();

// esto es ya que el cliente signalR pertenece a otro proyecto diferente al ServerHub
//por lo tanto hay que habilitar CORS (intercambio de recursos de origen cruzado)
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.SetIsOriginAllowed(_ => true)
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                         
                      });
});

builder.Services.AddSignalR();

builder.AddRabbitMQClient("messaging");

var app = builder.Build();

app.MapDefaultEndpoints();

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

app.UseCors(MyAllowSpecificOrigins);

app.MapHub<PanelControlHub>("/panelControl");

app.Run();
