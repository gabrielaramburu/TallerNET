using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02b_pipelinePattern.pipelinepattern.pipelineImpl
{
    internal class PasoCargarArchivo : IPipellinePaso
    {
        public void hacerAlgo(IContexto contexto)
        {
            
            String camino = @"C:\workspace\tallerNET\01_02b_pipelinePattern\01_02b_pipelinePattern\pipelinepattern\pipelineImpl\PruebaPipeLine.txt";
            //el uso del @ le indica al compilador que la siguiente cadena se interpreta literalmente
            //es decir ingnorando los caracteres especiales
            //en este caso la \

            //lo anterior se puede escribir como:
            //String camino = "C:\\workspace\\tallerNET\\01_02b_pipelinePattern\\01_02b_pipelinePattern\\pipelinepattern\\pipelineImpl\\PruebaPipeLine.txt";
            //notese que si a la sentencia anterior solo la escribimos con una barra
            //la misma no compila ya que después de la \ el compilador espera una caracter de escape

            ((InfoTexto)contexto).Texto = File.ReadAllText(camino);
            Console.WriteLine("Se cargo información desde archivo");
        }
    }
}
