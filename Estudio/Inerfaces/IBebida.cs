using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inerface.Inerfaces
{
    public interface IBebida
    {
        //Los atributos de la Interface no tienen modificador de alcance, Todos son public siempre
        int Cantidad { get; set; }

        string Mostrar();
        void LLenar(int cantidad);

        //** De las Interfaces no se Instancias objetos directamene
        //** Se debe crear una clase concreta que implemente esa interfaz para luego instanciarla
    }
}
