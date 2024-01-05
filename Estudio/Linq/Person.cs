using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.Linq
{
    public class Person
    {
        public int Edad { get; set; }
        public string Nombre { get; set; }

        public string EdadYNombre
        {
            get
            {
                return Edad + "-" + Nombre;
            }

        }

    }

}
