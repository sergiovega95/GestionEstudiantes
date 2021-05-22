using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiantesCore.Entidades
{
    [Table("EstudiantesXMateria", Schema = "GE")]
    public class EstudiantesXMateria
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Estudiantes Estudiante { get; set; }

        public Materia Materia { get; set; }

        public EstadoMateria Estado { get; set; }
    }
}
