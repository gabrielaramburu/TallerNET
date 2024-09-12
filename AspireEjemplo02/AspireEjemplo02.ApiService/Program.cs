using AspireEjemplo02.Web;
using System.Linq;
using System.Net.Http;
using System.Threading;


var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Observar como para poder invocar a la segunda API, tenemos que declarar un servicio
//de tipo HttpClient
builder.Services.AddHttpClient<PronosticoUruguayApiClient>(client =>
{
    // https://aka.ms/dotnet/sdschemes.
    //Acá se ve como trabaja el service discovery (no uso ip o nombre del host)
    client.BaseAddress = new("https+http://apiservice2");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (PronosticoUruguayApiClient pronosticoUru) =>
{
    IEnumerable<WeatherForecast> forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
    )).ToArray();

    Console.WriteLine("Obteniendo pronosticos de Uruguay");
    WeatherForecast[] pUruguay = pronosticoUru.ObtenerPronosticoUruguay().Result;

    forecast = forecast.Concat(pUruguay ?? []);
    
    return forecast;
});

app.MapDefaultEndpoints();

app.Run();





