using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudiantesCore.Entidades
{
    [Table("ProfesorXMaterias", Schema = "GE")]
    public class ProfesorXMaterias
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Profesor Profesor { get; set; }

        public Materia Materia { get; set; }
    }
}
