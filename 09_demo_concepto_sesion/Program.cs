using DemoSesion.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Configuración de caché en memoria y servicio de Sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Registro del servicio Contador como Singleton (usado en V2)
builder.Services.AddSingleton<IServicioContador, ServicioContador>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// Middleware de sesión activado antes de los endpoints
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
