using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Entidades
{
    public class ProfesorXMaterias
    {
        public int Id { get; set; }

        public Profesor Profesor { get; set; }

        public Materia Materia { get; set; }
    }
}
