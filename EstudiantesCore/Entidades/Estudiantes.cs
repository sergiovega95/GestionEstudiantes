using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstudiantesCore.Entidades
{
    [Table("Estudiante", Schema = "GE")]
    public class Estudiantes
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Nombre es obligatorio")]
        [MaxLength(300)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido es obligatorio")]
        [MaxLength(200)]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingrese un documento")]
        [MaxLength(20)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de nacimiento del estudiante")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Ingrese el sexo del estudiante")]
        [MaxLength(1)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Ingrese la dirección del estudiante")]
        [MaxLength(500)]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Ingrese el telefono del estudiante")]
        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese la fecha de ingreso del estudiante")]
        public DateTime FechaIngreso { get; set; }

        public DateTime FechaEgreso { get; set; }

        public DateTime FechaRetiro { get; set; }

        [Required(ErrorMessage = "Seleccione el tipo de documento")]
        public virtual TipoDocumento TipoDocumento { get; set; }

        [Required]
        public virtual EstadoEstudiante Estado { get; set; }


    }
}
