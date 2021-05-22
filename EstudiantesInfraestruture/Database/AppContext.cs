using EstudiantesCore.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesInfraestruture.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {          
       
        }

        public DbSet<EstadoEstudiante> EstadoEstudiante { get; set; }

        public DbSet<EstadoMateria> EstadoMateria { get; set; }

        public DbSet<EstadoProfesor> EstadoProfesor { get; set; }

        public DbSet<Estudiantes> Estudiante { get; set; }

        public DbSet<EstudiantesXMateria> EstudianteXMaterias { get; set; }

        public DbSet<Materia> Materia { get; set; }

        public DbSet<Profesor> Profesor { get; set; }

        public DbSet<ProfesorXMaterias> ProfesorXMaterias { get; set; }

        public DbSet<TipoDocumento> TipoDocumento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estudiantes>()
                .HasIndex(b => b.Documento)
                .IsUnique(true);

            modelBuilder.Entity<Profesor>()
                .HasIndex(b => b.Documento)
                .IsUnique(true);

            modelBuilder.Entity<Materia>()
                .HasIndex(b => b.Code)
                .IsUnique(true);

        }
    }
}
