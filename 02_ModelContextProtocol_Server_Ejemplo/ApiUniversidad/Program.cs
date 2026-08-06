using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApiUniversidad.Servicios;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar soporte para Controladores
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Registrar la capa de servicio
builder.Services.AddSingleton<ServicioUniversidad>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// 2. Mapear los controladores
app.MapControllers();

app.Run();
