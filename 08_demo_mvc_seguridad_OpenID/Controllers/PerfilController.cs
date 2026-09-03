using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _08_demo_mvc_seguridad_OpenID.ViewModels.Perfil;

namespace _08_demo_mvc_seguridad_OpenID.Controllers;

/// <summary>
/// Controlador para visualizar la identidad y los Claims emitidos por OpenID Connect.
/// </summary>
public class PerfilController : Controller
{
    [Authorize] // Requiere estar autenticado
    public IActionResult Index()
    {
        var estaAutenticado = User.Identity?.IsAuthenticated ?? false;

        var modelo = new PerfilUsuarioViewModel
        {
            EstaAutenticado = estaAutenticado,
            Nombre = User.FindFirst("name")?.Value 
                     ?? User.FindFirst(ClaimTypes.Name)?.Value 
                     ?? User.FindFirst("nickname")?.Value 
                     ?? User.Identity?.Name,
            Email = User.FindFirst(ClaimTypes.Email)?.Value 
                    ?? User.FindFirst("email")?.Value,
            Sub = User.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                  ?? User.FindFirst("sub")?.Value,
            FotoUrl = User.FindFirst("picture")?.Value,
            Claims = new List<ItemClaimViewModel>()
        };

        if (estaAutenticado && User.Claims.Any())
        {
            foreach (var claim in User.Claims)
            {
                modelo.Claims.Add(new ItemClaimViewModel
                {
                    Tipo = claim.Type,
                    Valor = claim.Value,
                    Emisor = claim.Issuer,
                    ExplicacionDidactica = ObtenerExplicacionClaim(claim.Type)
                });
            }
        }

        return View(modelo);
    }

    private static string ObtenerExplicacionClaim(string claimType)
    {
        if (claimType.Contains("roles", StringComparison.OrdinalIgnoreCase))
        {
            return "Rol(es) del usuario inyectados por Auth0 Action (RBAC). Permite usar [Authorize(Roles = \"...\")].";
        }

        var tipoLimpio = claimType.Split('/').Last().ToLowerInvariant();

        return tipoLimpio switch
        {
            "nameidentifier" or "sub" => "Subject: Identificador único e inmutable del usuario en el Proveedor de Identidad (Auth0).",
            "name" => "Nombre completo o apodo público del usuario.",
            "nickname" => "Apodo o nombre de usuario en Auth0.",
            "email" => "Correo electrónico del usuario proveniente del ID Token.",
            "email_verified" => "Booleano que indica si el usuario validó su casilla de correo.",
            "picture" => "URL de la fotografía o avatar de perfil del usuario.",
            "iss" => "Issuer: URL del Proveedor de Identidad OpenID que emitió y firmó el token.",
            "aud" => "Audience: Identificador (Client ID) de la aplicación destinataria del token.",
            "iat" => "Issued At: Timestamp Unix de cuándo fue creado el token.",
            "exp" => "Expiration Time: Timestamp Unix de vencimiento del token.",
            "sid" => "Session ID: Identificador de la sesión en el Proveedor OpenID.",
            "auth_time" => "Momento exacto en que ocurrió la autenticación del usuario.",
            _ => "Claim estándar o personalizado recibido en el ID Token."
        };
    }
}
