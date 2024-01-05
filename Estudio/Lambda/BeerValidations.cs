using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio.Lambda
{
    public class BeerValidations
    {
        public static readonly Predicate<string> NotNull = d => d != null;

        public static readonly Predicate<Beer> NotNullName = d => d.Name != null;

        public static readonly Predicate<Beer> NotNullCountry = d => d.Country != null;

        //--> Otra forma más óptima
        public static readonly Predicate<Beer>[] Validations =
        {
            d => d.Name != null,
            d => d.Country != null,
            d => d.Name.Count() < 10,
            d => d.Country.Count() < 20,
        };
        
    }

}
