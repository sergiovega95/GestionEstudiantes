using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    [Table("Notas", Schema = "GE")]
    public class Notas
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }

        [Required]        
        public decimal Nota { get; set; }

        [Required]
        public int Porcentaje { get; set; }

        [Required]
        public EstudiantesXMateria Materia { get; set; }

    }
}
