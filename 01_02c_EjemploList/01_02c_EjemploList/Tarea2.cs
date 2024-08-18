using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_02c_EjemploList
{
    internal class Tarea2
    {
        public int Id { set; get; }
        public string Nombre { set; get; }

        public Tarea2(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return "id:"+this.Id+", nom.:"+this.Nombre;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            //por regla de negocio,
            //considero que una tarea es igual a otra si tiene le mismo id
            if (((Tarea2)obj).Id == this.Id) return true;
            else return false;
      
        }
    }
}
