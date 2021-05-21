using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Entidades
{
    public class Profesor
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Documento { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public EstadoProfesor Estado { get; set; }
    }
}
