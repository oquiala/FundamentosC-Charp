using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text;
using Herencia.Animales;
using Herencia.Personas;
using Herencia.Figuras;
using Inerface.Inerfaces;
using System.Security.Cryptography.X509Certificates;
using Estudio.Partial;
using System.Collections;
using Estudio.Generics;
using Estudio.Lambda;
using Estudio.Linq;

namespace Estudio
{
    class Program
    {
        static void Main(string[] args)
        {
            //////////////////////////////   ANIMALES - SOBRECARGA  ////////////////////////////
            Console.WriteLine("--- ANIMALES - SOBRECARGA ---\r\n");

            Leon oLeon = new() { Nombre = "Simba" };
            oLeon.Correr();

            //--> Uso de sobrecarga 
            oLeon.Correr(30, " muy rápido");

            string nombre = oLeon.GetNombre();
            Console.WriteLine(nombre);

            int velocidad = oLeon.Velocidad;
            Console.WriteLine(velocidad + " Km/h");

            int velocidadM = oLeon.VelocidadMetros;
            Console.WriteLine(velocidadM + " m/h");


            ////////////////////////////    PERSONA - POLIMORFISMO   ////////////////////////////
            Console.WriteLine("\r\n--- PERSONA - POLIMORFISMO ---\r\n"); 

            Cerveza oCerveza = new Cerveza(5, 6.5M, 2);
            oCerveza.Fermentacion();

            Bar oBar = new();

            //POLIMORFISMO por inclusión permite crear un objeto de una clase (Persona)
            //pero definiendole su tipo a traves de una clase hija (Mesero)
            //en este caso el objeto mesero es de tipo clase Persona al que se le asigna una clase Mesero

            Persona oMesero = new Mesero("Pepe");
            Persona oCantinero = new Cantinero("Héctor");
            Persona oCliente = new Cliente("Itza");
            oBar.Entrar(oMesero);
            oBar.Entrar(oCantinero);
            oBar.Entrar(oCliente);


            ////////////////////////////    FIGURAS - POLIMORFISMO    /////////////////////////////
            Console.WriteLine("\r\n--- FIGURAS - POLIMORFISMO ---\r\n");

            //POLIMORFISMO por Herencia a través de una jerarquía de clases 
            List<Figura> lista = new()
            {
                new Circulo(10),
                new Cuadrado(230)                
            };
            lista.Add(new Triangulo(11));
            lista.ForEach (f => f.Dibujar());


            ///////////////////////////////////    INTERFACE    //////////////////////////////////
            Console.WriteLine("\r\n--- INTERFACE ---\r\n");

            IBebida oBebida = new Vino();

            IBebida oBebidaA = new Vino()
            {
                Alcohol = "3.5",
                Presentacion = "Botella",
                Marca = "RedBlend",
                Cantidad = 1
            };
            oBebidaA.LLenar(10);

            List<IBebida> lst = new() { oBebida, oBebidaA };
            Mostrar(lst);
                

            ////////////////////////////    INDIVIDUO - PARTIAL CLASS    ////////////////////////////
            Console.WriteLine("\r\n--- INDIVIDUO - PARTIAL CLASS ---\r\n");

            //Las Partial Class sirven para hacer una misma clase en diferentes archivos
            //En este caso la clase Individuo esta en dos archivos uno con las propiedades y otro con los metodos
            //y puedo acceder a ambos

            Individuo oIndividuo = new() { Nombre = "Osle", Apellido = "Quiala" };
            string ncIndividuo = oIndividuo.GetNombreCompleto();
            Console.WriteLine(ncIndividuo);


            ////////////////////////////    GENERICS    ////////////////////////////
            Console.WriteLine("\r\n--- GENERICS ---\r\n");

            //Generics es una característica de C# que permite crear variables, clases, interfaces, métodos, eventos y delegados
            //que sean independientes del tipo de dato.
            //En vez de escribir metodos o clases con la misma funcionalidad con diferentes tipos, se crea un unico metodo generico

            //en este caso creo una lista a la que le puedo enviar valores con cualquier tipo de dato
            var lis = new ArrayList();

            //en este caso usamos la clases generica Repository para mandarle una entidad de tipo Proveedor
            var repositoryProveedor = new Repository<Proveedor>();

            repositoryProveedor.Save(new Proveedor()
            {
                Apellido = "Quiala"
            });
            Console.WriteLine("Proveedor " + repositoryProveedor.list.First().Apellido);
            //en este caso usamos la clases generica Repository para mandarle una entidad de tipo Producto
            var repositoryProducto = new Repository<Producto>();

            repositoryProducto.Save(new Producto()
            {
                Codigo = "AH5471"
            });
            Console.WriteLine("Producto " + repositoryProducto.list.First().Codigo);
            //De esta manera usamos la misma clase Repository<T> para crear dos repositorios de diferentes entidades

            ////////////////////////////    LAMBDA    ////////////////////////////
            Console.WriteLine("\r\n--- LAMBDA ---\r\n");

            //--> la funcion Multiplicar tiene un parametro <int> de entrada y uno <int> de salida
            Func<int, int> Multiplicar = (a) => a * 2;
            //--> llamo a la funcion y le asigno una variable
            int result = Multiplicar(4);
            Console.WriteLine("Multiplicar(4) a * 2 = " + result);

            Func<int, int> Cuadrado = n => n * n;
            Console.WriteLine("Cuadrado(5) n * n = " + Cuadrado(5));
            
            
            //--> la funcion con 2 parametros
            Func<int, int, int> suma = (a, b) => a + b;
            int sum = suma(4, 10);
            Console.WriteLine("suma(4, 10) = " + sum);

            //--> la funcion con una sentencia con mas lineas de codigo, en este caso hay que especificar el return
            Func<int, int, int> may = (a, b) =>
            {
                if (a > b) return a;
                else return b;
            };

            int mayor = may(4, 10);
            Console.WriteLine("mayor(4, 10) = " + mayor);

            var numbers = new List<int> { 3, 5, 7, 4, 8, 9, 2 };

            Func<int, bool> GetPairs = (number) => number % 2 == 0;

            //--> Llamar una funcion Lambda desde una funcion de Linq
            var pairs = numbers.Where(GetPairs);
            Console.WriteLine("GetPairs 3, 5, 7, 4, 8, 9, 2");
            foreach (var pair in pairs)
            {
                Console.WriteLine(pair);
            }

            //--> Otra forma es con la funcion lambda directo en el where
            var pairsB = numbers.Where((number) => number % 2 == 0);
            
            //--> Action es para declarar una funcion que no retorna nada igual que void
            Action<int> print = (number) => Console.WriteLine("Action print " + number);
            print(5);

            //--> Para mostrar todos los items de una lista
            Action<List<int>> show = (numbers) =>
            {
                foreach (var number in numbers)
                    print(number);
            };
            //show(numbers);

            //--> Funcion de Orden Superior, Funciones que reciben otras funciones como parametros
            //--> ******* el ultimo parametro que recibe la funcion es el tipo de dato de lo que retorna
            //--> esta funcion recibe un int y una funcion como parametro y retorna un int
            //--> y la funcion que es un parametro de la otra a su ves recibe un int y retorna un int

            Func<int, Func<int, int>, int> fnHigherOrder = (number, fn) =>
            {
                if (number > 100)
                    return fn(number);
                else return number;
            };

            //--> Para hacer la llamada a la funcion le paso un int y una funcion Lambda
            var res = fnHigherOrder(600, n => n * 2);
            Console.WriteLine("fnHigherOrder(600, n => n * 2) = " + res);

            //--> Un Predicate es una funcion que devuelve un bool
            Predicate<int> fnMay = a => a > 1 ? true : false;

            Console.WriteLine("fnMay(2) a > 1 = " + fnMay(2));

            //--- --- Mejoras en C# 10 para expresiones Lambda --- ---//


            //--> otra forma de poner lo del predicado usando var para no especificar el tipo de dato en la funcion
            var fnMayB = (int a) => a > 1;
            //Console.WriteLine(fnMay(2));

            //-----------
            Func<int, int, int> sumar = (a, b) => a + b;

            //--> otra forma
            var sumarB = (int a, int b) => a + b;

            //--> Una funcion que devuelva o un int o un string
            var p = object (bool e) => e ? 1 : "is false";
            Console.WriteLine(p(true));

            //--> Un closure  es una funcion que devuelve una funcion
            Console.WriteLine("Un CLOSURE es una función que devuelve una función");
            var closure = Action (int n) =>
            {
                int i = 0;

                return () =>
                {
                    if (i < n)
                        Console.WriteLine($"Se ejecutó {i + 1}");
                    else
                        Console.WriteLine("Se terminó");

                    i++;
                };
            };

            var executor = closure(2);
            executor();
            executor();
            executor();                  

            //----//-------------------------------//----//

            var data = new Beer() { Name = "Minerva", Country = "Mexico" };

            var esNotNull = BeerValidations.NotNull(data.Name);
            Console.WriteLine(esNotNull);

            var beer = new Beer() { Name = "Minerva", Country = "Mexico" };

            var esNotNullName = BeerValidations.NotNullName(beer);
            //Console.WriteLine(esNotNullName);

            //var valida = BeerValidations.Validations(beer);


            ////////////////////////////    LINQ    ////////////////////////////
            Console.WriteLine("\r\n--- LINQ ---\r\n");

            var beers = new List<Birra>()
            {
                new Birra() { Name = "Pikantus", Brand = "Erdinger", Alcohol = 8.5m },
                new Birra() { Name = "London", Brand = "Fuller", Alcohol = 8 },
                new Birra() { Name = "IPA", Brand = "Fuller", Alcohol = 7 },
                new Birra() { Name = "Red", Brand = "Delirium", Alcohol = 7 },
                new Birra() { Name = "Dunkel", Brand = "Erdinger", Alcohol = 6.5m }
            };
            foreach (var birra in beers)
            {
                Console.WriteLine(" - " + birra.Name + " - " + birra.Brand + " - " + birra.Alcohol);
            }
            //--> Obtener el penultimo elemento, el acento circunflejo se pone con Alt 94
            var penultimo = beers.ElementAt(^2).Name;

            var ultimo = beers.ElementAt(^1).Name;

            //Console.WriteLine(ultimo);

            //--> Rango Take(..3) primeros 3 elementos
            //--> Rango Take(0..4) primeros 4 elementos
            //--> Rango Take(^3..) ultimos 3 elementos
            //--> Rango Take(1..3) desde la pocision 1 a la 3, ignora la posicion 0
            foreach (var birra in beers.Take(1..3))
            {
                Console.WriteLine("Take(1..3) " + birra.Name);
            }

            //--> DistinctBy() para devolver los elementos distintos 
            foreach (var birra in beers.DistinctBy(e => e.Brand))
            {
                Console.WriteLine("DistinctBy Brand " + birra.Brand);
            }

            //--> UnionBy para filtrar campos que no esten repetidos
            var beers2 = new List<Birra>()
            {
                new Birra() {Name = "Stout", Brand = "Minerva", Alcohol = 8},
                new Birra() {Name = "Pale", Brand = "Minerva", Alcohol = 5},
                new Birra() {Name = "Termens", Brand = "Delirium", Alcohol = 5}
            };

            foreach (var birra in beers.UnionBy(beers2, e => e.Brand))
            {
                //Console.WriteLine(birra.Brand);
            }

            //--> MaxBy()  Obtener Max o Min
            var maxAlcohol = beers.MaxBy(e => e.Alcohol)?.Name;

            Console.WriteLine("MaxBy(e => e.Alcohol) " + maxAlcohol);

            //--> Chunk() para hacer paquetes de paquetes o arreglos de arreglos o colecion de colecciones            
            var beersPack2 = beers.Chunk(2);
            Console.WriteLine(" - Chunk(2) Paquetes de dos cervezas - ");

            int i = 1;
            foreach (var pack in beersPack2)
            {
                foreach (var birra in pack)
                {
                    Console.WriteLine($"El Paquete {i} tiene {birra.Name}");
                }
                i++;
            }

            //--> FirstOrDefault() para poner un valor por defecto cuando no existe lo que buscamos

            var porDefault = beers.Where(e => e.Name == "Corona").FirstOrDefault(new Birra() { Name = "No Existe" }).Name;

            Console.WriteLine(porDefault);

            //--> Zip() para Combinaciones de elementos de 2 colecciones
            int[] numeros = { 1, 2, 3, 4 };
            Console.WriteLine(" - beers.Zip(numeros, (f, s) => f.Name + s) - Concatenar dos colecciones");

            //--> A cada elemento de la coleccion beers le concateno cada elemento de la colecion numbers
            var beersAndNumbers = beers.Zip(numeros, (f, s) => f.Name + s);
            foreach (var ba in beersAndNumbers)
            {
                Console.WriteLine(ba);
            }

            //--> Zip para combinar 3 colecciones
            string[] pubs = { "Crustaceo Cascarudo", "Pare y Siga" };
            Console.WriteLine(" - beers.Zip(numbers, pubs) - (ba.First.Name + ba.Second + ba.Third)");

            var beersAndNumbersC = beers.Zip(numbers, pubs);

            foreach (var ba in beersAndNumbersC)
            {
                Console.WriteLine(ba.First.Name + " " + ba.Second + " " + ba.Third);
            }


            //---- ---- LINQ BASICO ---- ----


            int[] arregloEnteros = { 1, 2, 10, 3, 2, 55, 666, 18, 2, 100, 2, 41 };

            //--> Ordenar y Filtrar
            IEnumerable<int> lstA = from d in arregloEnteros where d == 2 || d == 3 orderby d select d;
            foreach (var a in lstA)
            {
                Console.WriteLine(a);
            }

            //--> Filtrar con el objetos
            Complejo[] lstC =
            {
                new Complejo(1,"pato"),
                new Complejo(666, "diablo"),
                new Complejo(5,"perro"),
                new Complejo(10, "ave"),
                new Complejo(55, "foca"),

            };

            var oDiablo = (from d in lstC where d.Cadena == "diablo" select d).FirstOrDefault();

            Console.WriteLine(oDiablo.Imprime());

            //--> Ordenar con el objeto
            var lsta = from d in lstC orderby d.Numero select d;

            foreach (var ordenElements in lsta)
            {
                Console.WriteLine(ordenElements.Imprime());
            }


            //-------- -------- --------

            List<Person> lsti = new List<Person>()
            {
                new Person() {Edad = 40, Nombre = "Pancho"},
                new Person() {Edad = 30, Nombre = "Juan"},
                new Person() {Edad = 11, Nombre = "Mario"},
                new Person() {Edad = 18, Nombre = "Juana"},
                new Person() {Edad = 6, Nombre = "Memo"}
            };

            //--> Concatenar propiedades
            List<string> lstOrdenSoloNombresC = (from d in lsti orderby d.Nombre select (d.Nombre + " " + d.Edad)).ToList();

            //--> Obtener una propiedad ya concatena
            //-->  Take() es como el limt
            //-->  Skip() es para ignorar los primeros, sirve para paginado
            List<string> lstOrdenSoloNombresB = (from d in lsti orderby d.Nombre select d.EdadYNombre).Skip(2).Take(2).ToList();

            //--> Union de dos listas
            List<string> lstSoloTexto = new List<string>()
            {
                "30 - Hector", "15 - Gabriel", "20 - Fernando"
            };

            List<string> lstOrdenSoloNombres = (from d in lsti select d.EdadYNombre).Union(lstSoloTexto).OrderBy(d => d).ToList();

            //--> Otra Union para ordenar por el Nombre
            List<Person> lstOtra = new List<Person>()
            {
                new Person() {Edad = 30, Nombre = "Hector"},
                new Person() {Edad = 15, Nombre = "Gabriel"},
                new Person() {Edad = 50, Nombre = "Fernando"},
                new Person() {Edad = 33, Nombre = "Miguel"}
            };

            List<string> lstOrdenObjsX = (from d in lsti select d).Union(lstOtra).OrderBy(d => d.Nombre).Select(d => d.EdadYNombre).ToList();

            //--> Otra Opcion
            List<string> lstOrdenObjsY = (from d in lsti select d)
                                        .Union(from d in lstOtra select d)
                                        .OrderBy(d => d.Nombre)
                                        .Select(d => d.EdadYNombre)
                                        .ToList();

            //--> Subconsulta
            List<string> lstOrdenObjs = (from a in
                                            (from d in lsti select d).Union(from d in lstOtra select d)
                                         orderby a.Nombre
                                         select a.EdadYNombre).ToList();

            //--> Cantidad de personas
            int noPersonas = lstOrdenObjs.Count;
            Console.WriteLine(noPersonas);

            foreach (var Nombre in lstOrdenObjs)
            {
                //Console.WriteLine(Nombre);
            }

            //----- Libro -----

            Libro[] arrayLibrosA = new Libro[]
            {
                new Libro(1,"Poeta en Nueva York", "Federico García Lorca"),
                new Libro(2,"Los asesinos del Emperador", "Santiago Posteguillo"),
                new Libro(3,"Circo máximo", "Santiago Posteguillo"),
                new Libro(4,"La noche en que Frankestein leyó el Quijote", "Santiago Posteguillo"),
                new Libro(5,"El origen perdido", "Matilde Asensi")

            };

            //--> Forma 1 de usar Linq
            var librosA = from libro in arrayLibrosA where libro.Autor == "Santiago Posteguillo" select libro;
            //--> lo mismo pero con IEnumerable
            IEnumerable<Libro> libros = from libro in arrayLibrosA where libro.Autor == "Santiago Posteguillo" select libro;

            //--> Otra forma usando extensiones - en este caso no es necesario indicar el select
            var librosExtensionA = arrayLibrosA.Where(a => a.Autor == "Santiago Posteguillo");

            IEnumerable<Libro> librosExtensionB = arrayLibrosA.Where(a => a.Autor == "Santiago Posteguillo");

            //--> otras extensiones
            IEnumerable<Libro> librosExtension = arrayLibrosA.Where(a => a.Autor == "Santiago Posteguillo").OrderBy(a => a.Titulo);

            foreach (Libro libro in librosExtension)
            {
                //Console.WriteLine(libro.Titulo);
            }


            //-----------------  IEnumerable  ------------------

            IEnumerable<Libro> arrayLibros = new Libro[]
            {
                new Libro(1,"Poeta en Nueva York", "Federico García Lorca"),
                new Libro(2,"Los asesinos del Emperador", "Santiago Posteguillo"),
                new Libro(3,"Circo máximo", "Santiago Posteguillo"),
                new Libro(4,"La noche en que Frankestein leyó el Quijote", "Santiago Posteguillo"),
                new Libro(5,"El origen perdido", "Matilde Asensi")
            };

            IEnumerator<Libro> enumerator = arrayLibros.GetEnumerator();

            while (enumerator.MoveNext())
            {
                //Console.WriteLine(enumerator.Current.Titulo);
            }

            //--> otras

            IEnumerable<Libro> librosExt = arrayLibros.Where(a => a.Autor == "Santiago Posteguillo");

            Libro librosFirst = arrayLibros.First(a => a.Id == 1);

            //--> devuelve null  si no existe el objeto buscado
            Libro librosFirstDefault = arrayLibros.FirstOrDefault(a => a.Id == 0);

            //--> da una excepcion cuando hay mas de un objeto
            Libro librosFirsSingle = arrayLibros.SingleOrDefault(a => a.Id == 1);

            //Console.WriteLine(librosFirsSingle.Titulo);

            //--> agrupaciones
            var agrupacion = arrayLibros.GroupBy(a => a.Autor);

            foreach (var autor in agrupacion)
            {
                 Console.WriteLine(" - " + autor.Key);

                foreach (var libro in autor)
                {
                     Console.WriteLine(libro.Titulo);
                }

            }

            //--> Filtro Personalizado
            IEnumerable<Libro> libroFiltro = arrayLibros.Filtro(a => a.Autor == "Santiago Posteguillo");

            foreach (Libro libro in libroFiltro)
            {
                //Console.WriteLine(libro.Titulo);
            }


        }


        //El modificador static permite acceder a las variables y métodos aunque no tengamos una instancia del objeto que los contiene
        //no habrá una variable o metodo satatic por cada instancia de una clase, sino una sola para todas las instancias de la clase
        public static void Mostrar(List<IBebida> lst)
        {
            foreach (var elem in lst)
            {
                Console.WriteLine(elem.Mostrar());
            }
        }


    }

}

