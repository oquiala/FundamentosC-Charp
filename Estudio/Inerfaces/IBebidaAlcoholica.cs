using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inerface.Inerfaces
{
    public interface IBebidaAlcoholica : IBebida
    {
        //Los atributos de la Interface no tienen modificador de alcance, Todos son public siempre
        string Alcohol { get; set; }
        string Presentacion { get; set; }
        string Marca { get; set; }

        //Las Interface no pueden incluir Constructores de Instancias 
        void LLenar(int NuevaCantidad);

        //** De las Interfaces no se Instancias objetos directamene
        //** Se debe crear una clase concreta que implemente esa interfaz para luego instanciarla

        //** De una interfaz se pueden crear varias clases concretas que las implementen,
        //** todas con comportamientos diferentes pero que cumplan con pautas de la interface

        //** Tambien de de una interface pueden heredar varias interfaces

    }
}
