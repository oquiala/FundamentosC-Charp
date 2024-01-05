using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia.Personas
{
    public class Mesero : Persona
    {
        //Cuando se crea el CONSTRUCTOR este recibe el nombre y se lo manda al padre con la palabra base
        //de esta manera cuando se cree un objeto de la clase Mesero se le pasa el nombre que es un atributo de Persona
        public Mesero(string Nombre) : base(Nombre) { }


        //override es para sobreescribir un método virtual del padre, esto se llama SOBREESCRITURA
        public override void Accion()
        {
            Console.WriteLine(Nombre + " Sirve mesas");
        }

    }
}
