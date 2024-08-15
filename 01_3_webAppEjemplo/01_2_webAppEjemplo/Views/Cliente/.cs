using _01_3_webAppEjemplo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _01_3_webAppEjemplo.Views.Cliente
{
    public class PersonasModel: PageModel
    {
        public PersonasModel() { }

        public void OnGet()
        {
        }
        public PartialViewResult OnGetPersonasPartial()
        {
            Console.WriteLine("Estoy pasando por aca");
            return Partial("_Personas", new Persona(1,34343,"wewew","sdsd","ewewe"));
        }
    }
}
