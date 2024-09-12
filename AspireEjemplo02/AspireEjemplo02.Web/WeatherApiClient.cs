namespace AspireEjemplo02.Web;

public class WeatherApiClient(HttpClient httpClient)
{
    public async Task<WeatherForecast[]> GetWeatherAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<WeatherForecast>? forecasts = null;

        await foreach (var forecast in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/weatherforecast", cancellationToken))
        {
            if (forecasts?.Count >= maxItems)
            {
                break;
            }
            if (forecast is not null)
            {
                forecasts ??= []; //si forecast es nulo le asigno un array vació
                forecasts.Add(forecast);
            }
        }

        // https://stackoverflow.com/questions/446835/what-do-two-question-marks-together-mean-in-c

        return forecasts?.ToArray() ?? []; 
        //devuelvo un array con los elementos de forecatst o un arrya vacío si forecast es nulo

    }
}

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
