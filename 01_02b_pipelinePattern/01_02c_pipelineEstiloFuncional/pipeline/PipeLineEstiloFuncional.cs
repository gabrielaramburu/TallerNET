using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02c_pipelineEstiloFuncional.pipeline
{

    internal class PipeLineEstiloFuncional
    {
        //notese que por simplicidad aqui no estoy utilizando una interface
        private IList<Endpoint> _endpoints;

        public PipeLineEstiloFuncional()
        {
            _endpoints = new List<Endpoint>();
        }

        public void AgregarEndPoint(Endpoint nuevoEndpoint)
        {
            _endpoints.Add(nuevoEndpoint);
        }

        public void ProcesarRequestEntrante(string urlRequestEntrate)
        {
            foreach (Endpoint nuevoEndpoint in _endpoints)
            {
                nuevoEndpoint.Evaluar(urlRequestEntrate);
            }
        }
    }
}
