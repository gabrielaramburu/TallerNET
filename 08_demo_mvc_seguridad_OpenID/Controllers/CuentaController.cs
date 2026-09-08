using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System;

namespace _08_demo_mvc_seguridad_OpenID.Controllers;

/// <summary>
/// Controlador responsable de iniciar y cerrar el flujo de autenticación federada con OpenID Connect.
/// </summary>
public class CuentaController : Controller
{
   
    public IActionResult Login(string? returnUrl = null)
    {
        var propiedadesAutenticacion = new AuthenticationProperties
        {
            //URL a la que volver tras autenticarse con éxito
            RedirectUri = returnUrl ?? Url.Action("Index", "Home")
        };

        // Dispara el desafío OpenID Connect
        //Challenge() es un método de ASP.NET Core que inicia el proceso de autenticación.
        // Se envía una petición de redirección HTTP 302 hacia la pantalla de login del Proveedor de Identidad(Auth0)."*
        return Challenge(propiedadesAutenticacion, OpenIdConnectDefaults.AuthenticationScheme);
    }

    /// <summary>
    /// Cierra la sesión tanto localmente (destruyendo la cookie en el navegador)
    /// como en el Proveedor de Identidad remoto (Auth0 Federated Logout).
    /// </summary>
    public async Task<IActionResult> Logout()
    {
        var propiedadesAutenticacion = new AuthenticationProperties
        {
            RedirectUri = Url.Action("Index", "Home")
        };

        // 1. Limpia la cookie local
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        // 2. Notifica a OpenID Connect para redireccionar al logout de Auth0
        return SignOut(propiedadesAutenticacion, OpenIdConnectDefaults.AuthenticationScheme);
    }

    /// <summary>
    /// Vista didáctica mostrada cuando un usuario autenticado intenta acceder a un recurso sin tener el rol necesario.
    /// </summary>
    public IActionResult AccesoDenegado()
    {
        return View();
    }
}
