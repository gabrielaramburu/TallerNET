using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02c_pipelineEstiloFuncional.pipeline
{
    internal class Endpoint
    {
        private string _uri;

        //
        //Action es un tipo predefinido de delegate
        //que no retorna un valor
        //en este caso recibe un String 
        //otros tipos predefinidos de delegates son: Func, Predicate

        //Elijo un Action y no un Func (que tendría más sentido) por un tema de 
        //simplicidad
        private Action<string> _accion;

        public Endpoint(string uri, Action<string> accionAEjecutar)
        {
            _uri = uri;
            _accion = accionAEjecutar;
        }


        public void Evaluar(string urlEntrante)
        {
            if (urlEntrante == _uri)
            {
                //aca podría parsear el parámetro de la url y dejarlo
                //para que quede disponible al momento de ejecutar la acción
                //a mode de ejemplo dejo el valor hardcoded
                string param1 = "valorParam1";
                _accion(param1);
            }

        }
    }
}
