using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia.Figuras
{
    //Case abstracta para hacer herencia y Polimorfismo
    public abstract class Figura
    {
        protected int diametro;

        //Contructor en forma de lambda
        public Figura(int diametro) => this.diametro = diametro;

        public abstract void Dibujar();

    }
}
