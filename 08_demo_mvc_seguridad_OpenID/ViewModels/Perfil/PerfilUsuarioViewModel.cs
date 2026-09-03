namespace _08_demo_mvc_seguridad_OpenID.ViewModels.Perfil;

/// <summary>
/// Representa un claim individual para inspección didáctica en la vista.
/// </summary>
public class ItemClaimViewModel
{
    public string Tipo { get; set; } = string.Empty;
    public string Valor { get; set; } = string.Empty;
    public string Emisor { get; set; } = string.Empty;
    public string ExplicacionDidactica { get; set; } = string.Empty;
}

/// <summary>
/// ViewModel para la pantalla de Perfil y visor de Claims OpenID.
/// </summary>
public class PerfilUsuarioViewModel
{
    public bool EstaAutenticado { get; set; }
    public string? Nombre { get; set; }
    public string? Email { get; set; }
    public string? Sub { get; set; }
    public string? FotoUrl { get; set; }
    public List<ItemClaimViewModel> Claims { get; set; } = new();
}
