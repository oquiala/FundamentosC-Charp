using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.Linq
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public Libro(int id, string titulo, string autor)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Autor = autor;
        }

    }

}
