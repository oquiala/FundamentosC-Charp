using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.Linq
{
    public static class ExLinq
    {
        public static IEnumerable<T> Filtro<T>(this IEnumerable<T> source, Func<T, bool> predicado)
        {
            List<T> result = new List<T>();

            foreach (var item in source)
            {
                if (predicado(item))
                {
                    yield return item;
                }
            }

        }

    }

}
