using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstudiantesCore.Dtos
{
    public class EstudianteDTO
    {
           
        public int Id { get; set; }

        public string Nombre { get; set; }

       
        public string Apellido { get; set; }

        
        public string Documento { get; set; }

     
        public DateTime FechaNacimiento { get; set; }

        public string Sexo { get; set; }

        [Required]
        [MaxLength(500)]
        public string Direccion { get; set; }

        [Required]
        [MaxLength(20)]
        public string Telefono { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        public DateTime FechaIngreso { get; set; }

        public DateTime FechaEgreso { get; set; }

        public DateTime FechaRetiro { get; set; }
        
        public TipoDocumento TipoDocumento { get; set; }
       
        public EstadoEstudiante Estado { get; set; }
    }
}
