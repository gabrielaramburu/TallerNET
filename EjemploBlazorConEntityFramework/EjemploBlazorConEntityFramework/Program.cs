using EjemploBlazorConEntityFramework.Components;
using EjemploBlazorConEntityFramework.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EjemploBlazorConEntityFramework.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<EjemploBlazorConEntityFrameworkContext>(options =>
    options.UseSqlServer(builder
    .Configuration.GetConnectionString("EjemploBlazorConEntityFrameworkContext") 
    ?? throw new InvalidOperationException("Connection string 'EjemploBlazorConEntityFrameworkContext' not found.")));

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<SensorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
