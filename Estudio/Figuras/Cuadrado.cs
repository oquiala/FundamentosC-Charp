using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia.Figuras
{
    public class Cuadrado : Figura
    {
        public Cuadrado(int diametro) : base(diametro) { }

        public override void Dibujar()
        {
            Console.WriteLine($"Cuadrado d: {diametro}");
        }
    }
}
