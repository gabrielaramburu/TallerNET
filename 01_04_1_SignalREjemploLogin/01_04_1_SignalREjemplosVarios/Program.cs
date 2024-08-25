using _01_04_1_SignalREjemplosVarios.Hubs;
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
app.MapHub<LoginConVerificacionHub>("/login");

app.MapGet("/verificar/usuario/{userId}", (string userId, 
    ILogger < LoginConVerificacionHub > logger, 
    IHubContext < LoginConVerificacionHub> hubContext) => {

        logger.LogInformation($"Se notificara al cliente con id {userId}");
    // Esta url la expongo para recibir los request que se disparan cuando el usuario hace click en el 
    //link que se envía por mail
    hubContext.Clients.Client(userId).SendAsync("VerificacionOk", userId);
});

app.Run();
