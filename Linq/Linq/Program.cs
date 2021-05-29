using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Alumno> alumnos = new List<Alumno>();

            Alumno alumno1 = new Alumno()
            {
                Id = 1,
                Nombre = "Sergio",
                Apellido = "Vega",
                Documento = "100515405",
                TipoDocumento = new TipoDocumento()
                {
                    Id = 1,
                    Nombre = "Cedula",
                    Code = "CC"
                },
                Edad = 10
            };

            Alumno alumno2 = new Alumno()
            {
                Id = 1,
                Nombre = "carlos",
                Apellido = "Vega",
                Documento = "156151",
                TipoDocumento = new TipoDocumento()
                {
                    Id = 1,
                    Nombre = "Cedula",
                    Code = "CC"
                },
                Edad = 20
            };

            Alumno alumno3 = new Alumno()
            {
                Id = 1,
                Nombre = "Sergio",
                Apellido = "perez",
                Documento = "16515",
                TipoDocumento = new TipoDocumento()
                {
                    Id = 2,
                    Nombre = "tarjeta",
                    Code = "TI"
                },
                Edad = 5
            };

            Alumno alumno4 = new Alumno()
            {
                Id = 1,
                Nombre = "Sergio2",
                Apellido = "perez2",
                Documento = "165152",
                TipoDocumento = new TipoDocumento()
                {
                    Id = 2,
                    Nombre = "tarjeta",
                    Code = "TI"
                },
                Edad = 5
            };

            Alumno alumno5 = new Alumno()
            {
                Id = 1,
                Nombre = "Sergio2",
                Apellido = "perez2",
                Documento = "165152",
                TipoDocumento = new TipoDocumento()
                {
                    Id = 2,
                    Nombre = "tarjeta",
                    Code = "TI"
                },
                Edad = 5
            };

            List<Alumno> nuevos = new List<Alumno>();
            nuevos.Add(alumno4);
            nuevos.Add(alumno5);

            alumnos.Add(alumno1);
            alumnos.Add(alumno2);
            alumnos.Add(alumno3);
            alumnos.Add(alumno3);

            ///WHERE (si va a la base de datos)

            var out1 = alumnos.Where(s => s.TipoDocumento.Id == 1).ToList();
            var out2 = alumnos.Where(s => s.TipoDocumento.Id == 1).Where(s => s.Documento == "100515405").ToList();
            var out3 = alumnos.Where(s => s.TipoDocumento.Id == 1 && s.Documento == "100515405").ToList();

            var out4 = (from a in alumnos
                        where a.TipoDocumento.Id == 1 && a.Documento == "100515405"
                        select a
                        ).ToList();

            //ORDENAMIENTO (si va a la base de datos)

            //ascendente
            var out5 = alumnos.OrderBy(s => s.Edad).ToList();
            //descendente
            var out6 = alumnos.OrderByDescending(s => s.Edad).ToList();

            //ascendente y con un segundo ordenado
            var out7 = alumnos.OrderBy(s => s.Edad).ThenBy(f=>f.Nombre).ToList();
            var out8 = alumnos.OrderBy(s => s.Edad).ThenByDescending(f => f.Nombre).ToList();

            //cuantificación (si van a la base de datos)
            var out9 = alumnos.All(s => s.TipoDocumento.Id == 1);
            var out10 = alumnos.Any(s => s.TipoDocumento.Id == 1 || s.Edad==10);

            //constains si va a la base de datos siempre y cuando la lista no este vacia
            var out11 = alumnos.Contains(alumno1);
            var out12 = alumnos.Contains(alumno4);

            var out13 = alumnos.Where(s => nuevos.Contains(s)).ToList();
            Console.WriteLine("Hello World!");

            List<int> numeros1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
            List<int> numeros2  = new List<int>() { 1,7, 3, 9, 10, 0 };

            //1,3 (una unica vez) este no va a la base
            var out14 = numeros1.Intersect(numeros2).ToList();

            //2,4,5,6 este no va a la base
            var out15 = numeros1.Except(numeros2).ToList();

            //0,2,4,5,6,7,9,10 este no va a la base
            var out17 = numeros1.Union(numeros2).ToList();

            // elimina los repetidos este si va a la base
            var out18 = alumnos.Distinct().ToList();

            ///si va la base de datos (pero solo si agrupa campos de la base de datos)
            var agrupado = alumnos.GroupBy(s => s.TipoDocumento.Id).ToList();

            ///si van a la base de datos
            var primerosN = alumnos.Take(1).ToList();
            var primerosNconskip  = alumnos.Skip(1).Take(1).ToList();
        }
    }
}
