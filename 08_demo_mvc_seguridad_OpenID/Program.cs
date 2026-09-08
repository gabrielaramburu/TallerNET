using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using _08_demo_mvc_seguridad_OpenID.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// 1. Registro de Servicios MVC al contenedor de Inyección de Dependencias
builder.Services.AddControllersWithViews();

// 2. Registro del Repositorio en Memoria como Singleton
builder.Services.AddSingleton<ICursoRepositorio, CursoRepositorioEnMemoria>();

// 3. Lectura de parámetros de configuración del Proveedor de Identidad (Auth0)
//ver appsetting.json. Los valors que están en el archivo se sacan de la aplicación Auth0 creada en el portal de Auth0.
var auth0Domain = builder.Configuration["Auth0:Domain"] ?? throw new InvalidOperationException("Falta configurar Auth0:Domain");
var auth0ClientId = builder.Configuration["Auth0:ClientId"] ?? throw new InvalidOperationException("Falta configurar Auth0:ClientId");

//OJO CON ESTO: el clienteSecret es un valor sensible que no debe estar en el appsettings.json, sino en un Secret Manager
//o en variables de entorno. En este ejemplo se lee desde la configuración por simplicidad

var auth0ClientSecret = builder.Configuration["Auth0:ClientSecret"] ?? throw new InvalidOperationException("Falta configurar Auth0:ClientSecret");

// 4. Configuración del Middleware de Seguridad: Autenticación por Cookies + OpenID Connect
builder.Services.AddAuthentication(opciones =>
{
    // Una vez autenticado, la sesión del usuario se mantiene mediante una Cookie local cifrada
    opciones.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    opciones.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    
    // Cuando se requiere autenticar a un usuario anónimo, se dispara el desafío OpenID Connect (Challenge)
    opciones.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opciones =>
{
    opciones.Cookie.Name = "PortalEducativo.AuthCookie";
    opciones.LoginPath = "/Cuenta/Login";
    opciones.LogoutPath = "/Cuenta/Logout";
    opciones.AccessDeniedPath = "/Cuenta/AccesoDenegado";
    opciones.ExpireTimeSpan = TimeSpan.FromHours(8);
})
.AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, opciones =>
{
    // URL del Proveedor de Identidad (IdP). El middleware consulta automáticamente:
    // https://{dominio}/.well-known/openid-configuration para descubrir endpoints y claves públicas
    opciones.Authority = $"https://{auth0Domain}";
    
    opciones.ClientId = auth0ClientId;
    opciones.ClientSecret = auth0ClientSecret;

    // Flujo estándar Authorization Code Flow
    opciones.ResponseType = OpenIdConnectResponseType.Code;

    // Almacenar los tokens (id_token, access_token) en la cookie de autenticación para su posterior inspección
    opciones.SaveTokens = true;

    // Scopes estándar solicitados a OpenID Connect
    opciones.Scope.Clear();
    opciones.Scope.Add("openid");   // Obligatorio: Emite el ID Token
    opciones.Scope.Add("profile");  // Información de perfil (nombre, foto, apodo)
    opciones.Scope.Add("email");    // Correo electrónico verificado

    // Endpoints estándar de retorno registrados en Auth0
    opciones.CallbackPath = new PathString("/signin-oidc");
    opciones.SignedOutCallbackPath = new PathString("/signout-callback-oidc");

    // Mapeo de Claims para que .NET reconozca el Nombre y los Roles (RBAC) inyectados por la Action de Auth0
    opciones.TokenValidationParameters = new TokenValidationParameters
    {
        NameClaimType = "name",
        RoleClaimType = "https://demo-mvc/roles" // Claim personalizado con los roles asignados
    };

    // Manejo de Cierre de Sesión Federado (Federated Logout en Auth0)
    opciones.Events = new OpenIdConnectEvents
    {
        OnRedirectToIdentityProviderForSignOut = contexto =>
        {
            var logoutUri = $"https://{auth0Domain}/v2/logout?client_id={auth0ClientId}";
            var postLogoutUri = contexto.Properties.RedirectUri;

            if (!string.IsNullOrEmpty(postLogoutUri))
            {
                if (postLogoutUri.StartsWith("/"))
                {
                    var peticion = contexto.Request;
                    postLogoutUri = $"{peticion.Scheme}://{peticion.Host}{peticion.PathBase}{postLogoutUri}";
                }
                logoutUri += $"&returnTo={Uri.EscapeDataString(postLogoutUri)}";
            }

            contexto.Response.Redirect(logoutUri);
            contexto.HandleResponse();
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

// 5. Configuración del pipeline de peticiones HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 6. Middleware de Seguridad (IMPORTANTE: Authentication debe ir antes de Authorization)
//por cada request leo la cookie de autenticación, si existe, y reconstruyo el User con sus Claims
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
