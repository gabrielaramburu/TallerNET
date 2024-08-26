using _01_04_2_SignalREjemploVotacion.Hubs;
using _01_04_2_SignalREjemploVotacion.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//lo necesito singleton para que guarde los votos
builder.Services.AddSingleton<Encuesta>();
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
app.MapHub<RealTimeEncuestaHub>("/RealTimeEncuestaHub");

app.Run();
