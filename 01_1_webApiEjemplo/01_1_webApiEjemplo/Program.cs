using _01_1_webApiEjemplo.Controllers;

// 1)  creo un builder de la aplicación, el cual me sirve para configurar  
// dependencias, servicios, middlewares, etc. que va a utilizar la aplicación
var builder = WebApplication.CreateBuilder(args);

// documentación clase Builder
// https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplicationbuilder?view=aspnetcore-8.0

//Agrego logger
//builder.Logging.AddConsole();

// Add services to the container.

//builder.Services.AddControllers();

// por defecto los controladores no son singleton (ApplicationScope si hacemos un paralelismo con Jakarta)
// por ese motivo y solo para los efectos de este demo, se regigstra el controlador como Singleton
builder.Services.AddSingleton<VehiculoController>();
builder.Services.AddMvc().AddControllersAsServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplication?view=aspnetcore-8.0
// 2) A partir del builder creo la aplicación. 
var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run(); //inicia el servidor y comienza a escuchar solicitudes HTTP
