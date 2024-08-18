using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02c_EjemploList
{
    internal class Tarea
    {
        public int Id { set; get; }
        public string Nombre { set; get; }

        public Tarea(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return "id:"+this.Id+", nom.:"+this.Nombre;
        }
    }
}
