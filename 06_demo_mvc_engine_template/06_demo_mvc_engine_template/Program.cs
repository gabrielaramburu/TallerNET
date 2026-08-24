using _06_demo_mvc_engine_template.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar Pajaro como un servicio
// Scope signigica que el Modelo va a durar lo que dura el request
builder.Services.AddScoped<Pajaro>(provider =>
{
   
    return new Pajaro();
});

var app = builder.Build();

//sin necesidad de profundizar,
//Estas líneas configuran el pipeline de la aplicación para seguridad (HTTPS),
//servir archivos estáticos, enrutar solicitudes y aplicar reglas de autorización.
//Es una secuencia estándar en aplicaciones ASP.NET Core.

app.UseHttpsRedirection(); 
app.UseStaticFiles(); 
app.UseRouting(); 
app.UseAuthorization();

//comportamiento por defecto, si no se especifica un controlador o acción en la URL,
//se dirigirá a la acción Index del controlador Pajaros.
//Ejemplo: https://localhost:5223/ es lo mismo que 
// https://localhost:5223/Pajaros/Index
app.MapControllerRoute(
    name: "version1",
    pattern: "{controller=Pajaros}/{action=Index}");

app.Run();
