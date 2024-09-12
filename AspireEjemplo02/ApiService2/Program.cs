var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Soleado", "Nublado", "Lluvioso", "Frio", "Tormentoso", "Alerta Amarilla", "Alerta Naranja", "Lindo para la siesta"
};

app.MapGet("/pronosticoUruguay", () =>
{

    Console.WriteLine("Estoy en la APIservicios2");
    //genero un rango de números del 1 al 5, para cada número creo un objeto con 
    //datos randomicos
    //finalmente devuelvo un array.
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new TiempoUruguay
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

//notar que acá se usa un registro en lugar de una clase
//los registros están pensados para solo contener datos, mientras que las clases
//tienen dato y comportamiento
//En este ejemplo el registo tiene 4 campos: Date, TemperaturaC, Summary y TemperaturF
record TiempoUruguay(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
