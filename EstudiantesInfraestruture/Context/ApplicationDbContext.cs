using EstudiantesCore.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesInfraestruture.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<EstadoEstudiante> EstadoEstudiante { get; set; }
        public DbSet<EstadoMateria> EstadoMateria { get; set; }
        public DbSet<EstadoProfesor> EstadoProfesor { get; set; }
        public DbSet<Estudiantes> Estudiante { get; set; }
        public DbSet<EstudiantesXMateria> EstudiantesXMateria { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<ProfesorXMaterias> ProfesorXMaterias { get; set; }
        public DbSet<TipoDocumento> TipoDocumento { get; set; }
       
    }
}
