using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.Linq
{
    public class Complejo
    {
        public int Numero { get; set; }
        public string Cadena { get; set; }

        public Complejo(int Numero, string Cadena)
        {
            this.Numero = Numero;
            this.Cadena = Cadena;
        }

        public String Imprime()
        {
            return Numero + " " + Cadena;
        }

    }

}
