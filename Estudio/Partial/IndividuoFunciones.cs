using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.Partial
{
    public partial class Individuo
    {
        //Las Partial Class sirven para hacer una misma clase en diferentes archivos 
        public string GetNombreCompleto()
        {
            return Nombre + " " + Apellido;
        }


    }
}
