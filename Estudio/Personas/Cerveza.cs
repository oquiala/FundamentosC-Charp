using System;
using System.Collections.Generic;
using System.Text;


namespace Herencia.Personas
{
    public class Cerveza
    {
        //atributos
        public int Amargor { get; set; }
        public decimal Alcohol { get; set; }
        public int TiempoFermentacion { get; set; }

        //Constructor
        public Cerveza(int Amargor, decimal Alcohol, int TiempoFermentacion)
        {
            //El [this] es para diferenciar los atributos de la clase de lo que se entran por parametros que tienen el mismo nombre
            this.Amargor = Amargor;
            this.Alcohol = Alcohol;
            this.TiempoFermentacion = TiempoFermentacion;
        }

        //Métodos
        public void Fermentacion()
        {
            for (int i = 0; i < TiempoFermentacion; i++)
            {
                Console.WriteLine("Se fermentó");
            }
        }

    }


}


