using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia.Personas
{
    public class Persona
    {
        public string Nombre { get; set; }

        public Persona(string Nombre)
        {
            this.Nombre = Nombre;
        }

        //virtual es para permitir que las clases hijas puedan sobreescribir este método
        //Esto se llama SOBREESCRITURA
        public virtual void Accion() { }



    }
}
