using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Herencia.Personas
{
    public class Bar
    {

        List<Persona> lstPersona = new();

        public void Entrar(Persona oPersona)
        {
            lstPersona.Add(oPersona);
            oPersona.Accion();
        }


    }
}
