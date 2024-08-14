using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _01_02c_pipelineEstiloFuncional
{
    //<modificador de acceso> delegate <tipo de retorno> <nombre>(<parametros>[]);
    public delegate String HacerAlgoConUnTexto(String texto);
    //lo podemos entender como que estamos definiendo un puntero a una función que
    //recibe un parámetro de tipo string y devuelve un string

    internal class EjemploEstiloFuncional
    {

        public String PasarAMayusculas(String texto)
        {
            return texto.ToUpper();
        }

        public String PasarAMinusculas(String texto)
        {
            return texto.ToLower();
        }

        public void probar()
        {
            //hago que ese "puntero" apunte a una función concreta
            //la función tiene que tener la misma firma
            HacerAlgoConUnTexto hacerAlgo = new HacerAlgoConUnTexto(PasarAMayusculas);

            //finalmente invoco a la función a la cual "apunto"
            Console.WriteLine(hacerAlgo("aaaaa"));

            HacerAlgoConUnTexto hacerAlgo2 = new HacerAlgoConUnTexto(PasarAMinusculas);
            Console.WriteLine(hacerAlgo2("AAAAAA"));

            //eventualmente puedo hacer que el delegado, apunte a una función 
            //anónima que también respete la firma (tome un parámetro de tipo string 
            //y retorne un string)
            HacerAlgoConUnTexto hacerAlgo3 = new HacerAlgoConUnTexto(
                (string texto) => { return texto + " *** "; });


            Console.WriteLine(hacerAlgo3("eeeee "));
        }
    }
}
