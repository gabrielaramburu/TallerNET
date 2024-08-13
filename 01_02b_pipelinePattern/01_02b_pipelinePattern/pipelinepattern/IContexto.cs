using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02b_pipelinePattern.pipelinepattern
{
    //el contexto representa lo que voy a "modificar" a medida que ejecuto el pipeline
    //podría ser una clase que represente un archivo de texto, una imagen, 
    //o una clase que represente cualquier otro concepto.
    internal interface IContexto
    {
    }
}
