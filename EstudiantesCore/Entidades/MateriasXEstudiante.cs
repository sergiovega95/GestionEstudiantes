using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Entidades
{
    public class MateriasXEstudiante
    {
        public int Id { get; set; }

        public Estudiante Estudiante { get; set; }

        public Materia Materia { get; set; }

        public EstadoMateria Estado { get; set; }
    }
}
