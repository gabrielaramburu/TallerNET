using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// tambien tengo que agregar el servicio al client
builder.Services.AddRadzenComponents();


await builder.Build().RunAsync();
