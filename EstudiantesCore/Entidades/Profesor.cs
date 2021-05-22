using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiantesCore.Entidades
{
    [Table("Profesor", Schema = "GE")]
    public class Profesor
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Documento { get; set; }

        public TipoDocumento TipoDocumento { get; set; }

        public EstadoProfesor Estado { get; set; }
    }
}
