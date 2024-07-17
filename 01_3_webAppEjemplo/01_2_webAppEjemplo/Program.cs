using _01_3_webAppEjemplo.Infraestructure.Data;
using _01_3_webAppEjemplo.Models;

var builder = WebApplication.CreateBuilder(args);

// registro repositorio de vehiculos como Singleton
builder.Services.AddSingleton<IVehiculoRepository, VehiculoRepository>();

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

app.UseRouting();

app.UseAuthorization();

// establece como es el formato de enrrutamiento (desde request hacia el action)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
