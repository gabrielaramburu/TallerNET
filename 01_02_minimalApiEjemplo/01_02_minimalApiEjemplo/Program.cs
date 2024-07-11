using _01_02_minimalApiEjemplo.Infraestructure.Data;
using _01_02_minimalApiEjemplo.Models;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

//Configuro el contenedor de dependencias para que cree injecte la misma instancia (Singleton) cada vez que
//lo requiera.
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();

var app = builder.Build();

//MapGet agrega un endpoint de tipo GET con un respectivo patron de ruteo
app.MapGet("/", () => "Hello World!");

app.MapGet("/saludar", () => "Hola, como estás?");

app.MapGet("/clientes", (IClienteRepository cliRepo) => 
{
    //Observar como estoy utilizando una instancia inyectada por el contenedor
    return Results.Ok(cliRepo.GetClientes());
});

app.MapGet("/clientes/{id}", (int id, IClienteRepository cliRepo) => 
{
    //Ejemplo con parseo de parámetros en url
    return Results.Ok(cliRepo.Get(id));
});


// curl  -Method DELETE https://localhost:7286/clientes/1
app.MapDelete("/clientes/{id}", (int id, IClienteRepository cliRepo) =>
{
    cliRepo.Delete(id);
    return Results.Ok();
});

// obtener parametros desde body
// curl  -Method POST -ContentType  'application/json' -Body '{"id":222, "nombre":"pepe", "ci":"33333"}' -Uri https://localhost:7286/clientes
app.MapPost("/clientes", ([FromBody]ClienteDTO cliDTO, IClienteRepository cliRepo) => 
{
    Cliente newCli = new(cliDTO.Id, cliDTO.Nombre, cliDTO.Ci); //observar nomenclatura del new()
    cliRepo.Add(newCli);
    return Results.Ok();
});

app.Run();
