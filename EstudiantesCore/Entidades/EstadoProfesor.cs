using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    [Table("EstadoProfesor", Schema = "GE")]
    public class EstadoProfesor
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// denota el codigo del profesor
        /// </summary>
        public string Code { get; set; }

        public string Nombre { get; set; }
    }
}
