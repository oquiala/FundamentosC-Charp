using System;
using System.Collections.Generic;
using System.Text;


namespace Herencia.Animales
{
    public class Animal
    {
        public string Nombre { get; set; }

        //Cuando pongo un atributo private, nadie tiene acceso a el, ni siquiera las clases hijas
        //Esto se llama ENCAPSULAMIENTO
        private string tipo { get; set; }

        //Cuando pongo un protected, solo lo pueden ver las clases hijas inmediatas
        //Esto se llama ENCAPSULAMIENTO
        protected string forma { get; set; }

        //virtual es para permitir que las clases hijas puedan sobreescribir este método
        //Esto se llama SOBREESCRITURA
        public virtual string GetNombre()
        {
            return Nombre;

        }


    }


}