using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02b_pipelinePattern.pipelinepattern.pipelineImpl
{
    internal class PasoConvertirMayuscula : IPipellinePaso
    {
        public void hacerAglo(IContexto contexto)
        {
            String textoNuevo = ((InfoTexto)contexto).Texto.ToUpper();
            ((InfoTexto)contexto).Texto = textoNuevo;
            Console.WriteLine("El contenido se pasó a mayúsculas");
        }
    }
}
