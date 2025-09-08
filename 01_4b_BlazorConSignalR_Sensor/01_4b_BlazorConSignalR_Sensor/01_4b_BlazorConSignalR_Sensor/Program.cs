using _01_4b_BlazorConSignalR_Sensor.Client.Pages;
using _01_4b_BlazorConSignalR_Sensor.Components;
using Radzen;
using Microsoft.AspNetCore.ResponseCompression;
using _01_4b_BlazorConSignalR_Sensor.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();



builder.Services.AddRadzenComponents();

// agrego el servicio de SignalR al servidor
builder.Services.AddSignalR();

// https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/blazor/tutorials/signalr-blazor.md
// esto no debería de necesitarse. Para mi gusto habla de que no está muy madura la librería
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        ["application/octet-stream"]);
});


var app = builder.Build();
// idem comentario anterior 
app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(_01_4b_BlazorConSignalR_Sensor.Client._Imports).Assembly);

app.MapHub<SensorHub>("/sensorTemperatura");

//  curl https://localhost:7236/cambiarTemperatura
app.MapGet("/cambiarTemperatura", (IHubContext<SensorHub> hubContext) =>
{
    //Para poder enviar mensajes desde el servidor a los clientes necesita acceder al hub
    //En este caso, le pido al contenedor que me inyecte la instancia del Hub.
    //Esto no cambia respecto a lo que veníamos usando.

    //envio un mensaje a todos los clientes que esten conectados al Hub

    int temp = new Random().Next(100);
    hubContext.Clients.All.SendAsync("cambioDeTemperatura", temp );
    return Results.Ok("Mensaje procesado: nueva temperatura = " + temp);
});

app.Run();
