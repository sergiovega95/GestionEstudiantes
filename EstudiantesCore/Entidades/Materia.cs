using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiantesCore.Entidades
{
    [Table("Materia", Schema = "GE")]
    public class Materia
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        public string Nombre { get; set; }

        [Required]
        public virtual EstadoMateria Estado { get; set; }

        [Required]
        public int year { get; set; }
    }
}
