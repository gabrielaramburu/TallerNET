using DemoPartialPages.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Registro de servicios en el contenedor de Inyección de Dependencias
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IVehiculoRepository, VehiculoEnMemoriaRepository>();

var app = builder.Build();

// En entorno de desarrollo mostramos la página detallada de excepciones
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
