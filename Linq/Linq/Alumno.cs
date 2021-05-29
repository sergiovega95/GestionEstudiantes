using System;
using System.Collections.Generic;
using System.Text;

namespace Linq
{
    public class Alumno
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int  Edad { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public string Documento { get; set; }
    }
}
