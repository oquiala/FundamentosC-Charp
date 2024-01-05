using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia.Animales
{
    public class Leon : Carnivoro
    {
        public string ColorCabello { get; set; }

        private int VelocidadDefecto = 20;

        private int CantidadPatasDefecto = 4;

        //MODIFICADOR DE ACCESO, es un atributo que se crea para darle algun acceso a otro atributo privado
        //En este caso se creó un modificador para el atributo VelocidadDefecto para que se pueda ver (get), pero NO se pueda modificar (set)
        public int Velocidad
        {
            get { return VelocidadDefecto; }
        }

        public int VelocidadMetros
        {
            get { return VelocidadDefecto * 1000; }
        }

        //MODIFICADOR DE ACCESO, En este caso se creó un modificador para Validar el set del atributo CantidadPatasDefecto
        //dentro de las definiciones de atributos tambien se puede escribir lógica para validar o lo que sea 
        public int CantidadPatas
        {
            get { return CantidadPatasDefecto; }
            set
            {
                if (value < 0)
                {
                    value = 1;
                }
                CantidadPatasDefecto = value;
            }
        }


        //CONSTRUCTOR se define cuando se desea que los objetos siempre se construyan da la forma en que se define el constructor
        //Si no se hace un constructor pues los objetos se crean llenando los atributos de la clase
        public Leon()
        {
            if (Nombre == null || !Nombre.Equals(""))
            {
                Nombre = "León";
            }
        }

        //La SOBRECARGA es la definición de varios Constructores con diferente cant de parámetros
        //Esto también se llama POLIMORFISMO PARAMETRICO
        //el this en la herencia es para que todos los otros constructores llamen al constructor padre
        public Leon(string Nombre) : this()
        {
            this.Nombre = Nombre;
        }

        public void Correr()
        {
            Console.WriteLine("Corriendo: " + VelocidadDefecto);
        }

        //La SOBRECARGA es la definición de varios Métodos con el mismo nombre pero con diferente cant de parámetros
        public void Correr(int Velocidad)
        {
            Console.WriteLine("Corriendo: " + Velocidad);
        }

        public void Correr(int Velocidad, string Detalle)
        {
            Console.WriteLine("Corriendo: " + Velocidad + Detalle);
        }

        //override es para sobreescribir un método virtual del padre, esto se llama SOBREESCRITURA
        public override string GetNombre()
        {
            return "Soy un león llamado " + Nombre;

        }



    }
}
