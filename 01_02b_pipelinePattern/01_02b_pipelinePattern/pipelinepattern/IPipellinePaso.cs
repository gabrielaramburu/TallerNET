using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02b_pipelinePattern.pipelinepattern
{
    //internal es un tipo de modificador de acceso
    //la clase estará visible solo dentro del mimso DLL (componente)
    internal interface IPipellinePaso
    {
        //cada paso del pipeLine se implementará como una clase concreta que
        //implemente esta interface.

        //el método hacer algo contedrá la implementación de la funcionalidad
        //que queremos que el paso concreto realice
        void hacerAlgo(IContexto contexto);
    }
}
