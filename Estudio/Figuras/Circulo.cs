using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia.Figuras
{
    public class Circulo : Figura
    {
        public Circulo(int diametro) : base(diametro) { }

        public override void Dibujar()
        {
            Console.WriteLine($"Circulo d: {diametro}");
        }
    }
}
