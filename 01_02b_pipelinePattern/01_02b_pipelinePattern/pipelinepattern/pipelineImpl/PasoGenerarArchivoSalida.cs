using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02b_pipelinePattern.pipelinepattern.pipelineImpl
{
    internal class PasoGenerarArchivoSalida : IPipellinePaso
    {
        public void hacerAlgo(IContexto contexto)
        {
            
            String archivoSalida = @"c:\Users\Gabriel Aramburu\Salida.txt";
            File.WriteAllText(archivoSalida, ((InfoTexto)contexto).Texto);
            Console.WriteLine("Se generó archivo de salida");
        }
    }
}
