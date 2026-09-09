using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _01_04_2_SignalREjemploVotacion.Pages
{
    public class VotacionModel : PageModel
    {
        public void OnGet()
           
        {
            //este método se ejecuta cuando se hace un GET a la página, es decir cuando se carga la página por primera vez
            //en este caso no necesito hacer nada, ya que la funcionalidad no lo requiere
            //en este metodo se puede hacer la inicialización de datos
            //por ejemplo ir a la base de datos y traer los datos iniciales para mostrarlos en la página
        }
    }
}
