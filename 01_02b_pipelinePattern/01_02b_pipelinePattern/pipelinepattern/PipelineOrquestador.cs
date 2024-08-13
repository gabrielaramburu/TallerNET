using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02b_pipelinePattern.pipelinepattern
{
    internal class PipelineOrquestador
    {
        private IList<IPipellinePaso> _pasosAEjecutar;
        private IContexto _contexto;

        public PipelineOrquestador(IContexto contexto) {
            this._pasosAEjecutar = new List<IPipellinePaso>();
            this._contexto = contexto;
        }

        public void AgregarPaso(IPipellinePaso paso)
        {
            this._pasosAEjecutar.Add(paso);
        }

        public void Ejecutar()
        {
            Console.WriteLine("Inicio pipeline");
            foreach (IPipellinePaso paso in this._pasosAEjecutar)
            {
                //aca es donde se ve la "fuerza" de la interface
                Console.WriteLine("Ejecutando paso");
                paso.hacerAglo(this._contexto);
                
            }
            Console.WriteLine("Fin pipeline");
        }
        

        
    }
}
