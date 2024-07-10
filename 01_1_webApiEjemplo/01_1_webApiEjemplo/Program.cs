using _01_1_webApiEjemplo.Controllers;

var builder = WebApplication.CreateBuilder(args);

//Agrego logger
builder.Logging.AddConsole();

// Add services to the container.

//builder.Services.AddControllers();

// por defecto los controladores no son singleton (ApplicationScope si hacemos un paralelismo con Jakarta)
// por ese motivo y solo para los efectos de este demo, se regigstra el controlador como Singleton
builder.Services.AddSingleton<VehiculoController>();
builder.Services.AddMvc().AddControllersAsServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
