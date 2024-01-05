using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inerface.Inerfaces
{
    public class Vino : IBebidaAlcoholica
    {
        //Dar clic en IBebidaAlcoholica / Acciones Rapidas / Implementar Interface

        //** De las Interfaces no se Instancias objetos directamene
        //** Se debe crear una clase concreta que implemente esa interfaz para luego instanciarla
        public string Alcohol { get; set; }
        public string Presentacion { get; set; }
        public string Marca { get; set; }
        public int Cantidad { get; set; }

        public void LLenar(int NuevaCantidad)
        {
            Cantidad = NuevaCantidad + 10;
        }

        public string Mostrar()
        {
            return "La cantidad de Vino es " + Cantidad;
        }

    }
}
