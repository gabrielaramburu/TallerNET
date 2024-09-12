namespace AspireEjemplo02.Web;

public class PronosticoUruguayApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> ObtenerPronosticoUruguay(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Invoco API que obtiene pronosticos de uruguay");
        List<WeatherForecast>? forecasts = null;


        //Hago una pausa intencional
        Thread.Sleep(3000);

        await foreach (var forecast in httpClient
            .GetFromJsonAsAsyncEnumerable<WeatherForecast>("/pronosticoUruguay", cancellationToken))
        {
            if (forecast is not null)
            {
                forecasts ??= []; //si forecast es nulo le asigno un array vació
                forecasts.Add(forecast);
            }
        }
        Console.WriteLine("Pronosticos uruguayos: " + String.Join(",", forecasts?? []));
        // si es nulo devuelvo un array vacío
        return forecasts?.ToArray() ?? []; 
       
    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
