using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Entidades
{
    public class EstudiantesXMateria
    {
        public int Id { get; set; }

        public Estudiantes Estudiante { get; set; }

        public Materia Materia { get; set; }

        public EstadoMateria Estado { get; set; }
    }
}
