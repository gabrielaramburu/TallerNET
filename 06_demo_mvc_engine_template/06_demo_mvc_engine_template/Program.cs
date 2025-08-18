using _06_demo_mvc_engine_template.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar Pajaro como un servicio
// Scope signigica que el Modelo va a durar lo que dura el request
builder.Services.AddScoped<Pajaro>(provider =>
{
   
    return new Pajaro();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "version1",
    pattern: "{controller=Pajaros}/{action=Index}");

app.MapControllerRoute(
    name: "version2",
    pattern: "{controller=PajarosVersion2}/{action=Index}");


app.Run();
