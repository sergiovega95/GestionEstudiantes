using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    [Table("EstadoEstudiante", Schema = "GE")]
    public class EstadoEstudiante
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Nombre { get; set; }
    }
}
