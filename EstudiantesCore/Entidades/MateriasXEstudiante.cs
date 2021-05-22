using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    public class MateriasXEstudiante
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Estudiante Estudiante { get; set; }

        public Materia Materia { get; set; }

        public EstadoMateria Estado { get; set; }
    }
}
