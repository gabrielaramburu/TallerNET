//https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-8.0&tabs=visual-studio

using _01_04_0_SignalREjemplo.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//agrego servicio 
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
//Hub de Chat
//observar que en chat.js que se descarga en el cliente, se apunta a dicho endpoint
//Las clases Hub son de tipo transient, es decir, se crea una nueva instancia cada vez
//que un cliente realice un invocación al servidor.
//Por ese motivo no se puede gurdar estado en las mismas
app.MapHub<ChatHub>("/miChat");

//puedo tener tantos hub como quiera
//Hub de grafico.
app.MapHub<GraficaHub>("/ejemploGrafica");

//Por cuestiones de simplicidad implemento una Minimal Api
//curl https://localhost:7159/lanzarEvento
app.MapGet("/lanzarEvento", (IHubContext<GraficaHub> hubContext) =>
{
    //Para poder enviar mensajes desde el servidor a los clientes necesita acceder al hub
    //En este caso, le pido al contenedor que me inyecte la instancia del Hub
    int valor = new Random().Next(100);
    int valor2 = new Random().Next(100);
    int valor3 = new Random().Next(100);

    
    //envio un mensaje a todos los clientes que esten conectados al Hub
    //Del lado del cliente, tengo que tener un js con la librería SignlR 
    //configurada para que escuche un mensaje con el nombre CambioValorGrafica
    hubContext.Clients.All.SendAsync("CambioValorGrafica",valor, valor2, valor3);
    return Results.Ok("Mensaje procesado, valor obtenido: " + valor);
});

app.Run();
