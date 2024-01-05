using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.Generics
{
    //Esto es una clase generica donde T es un tipo genérico
    //en este caso T hereda de la clase abstracta Entity
    //para obligar a ese tipo de dato T a que cumpla con determinadas características
    public class Repository<T> where T : Entity
    {
        public IList<T> list;

        public Repository()
        {
            list = new List<T>() ; 
        }

        public void Save(T entity)
        {
            if(entity.Id.Equals(Guid.Empty)) 
            { 
                entity.Id = Guid.NewGuid() ;
                list.Add(entity) ;
            }
            else
            {
                //reeplazar
            }
        }

    }
}
