using EstudiantesCore.Entidades;
using EstudiantesCore.Exceptions;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using EstudiantesInfraestruture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstudiantesInfraestruture.Implementations
{
    public class GestionMaterias : IGestionMaterias
    {
        private readonly AppDbContext _dbcontext;

        public GestionMaterias(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }                

        public void ActualizarMateriaMatriculada(EstudiantesXMateria materiaMatriculada)
        {
            _dbcontext.Update<EstudiantesXMateria>(materiaMatriculada);
            _dbcontext.SaveChanges();
        }

        public List<EstudiantesXMateria> GetMateriasByEstudiante(int idEstudiante)
        {
            List<EstudiantesXMateria> materias = _dbcontext.EstudianteXMaterias.Where(s => s.Estudiante.Id == idEstudiante)
                                                 .Include(s => s.Materia).Include(s => s.Estado).AsNoTracking().ToList();

            return materias;
        }

        public void MatricularMateria(EstudiantesXMateria materiaMatriculada)
        {
            materiaMatriculada.Estudiante = _dbcontext.Estudiante.Find(materiaMatriculada.Estudiante.Id);
            materiaMatriculada.Estado = _dbcontext.EstadoMateria.Find(materiaMatriculada.Estado.Id);
            materiaMatriculada.Materia = _dbcontext.Materia.Find(materiaMatriculada.Materia.Id);
            _dbcontext.EstudianteXMaterias.Add(materiaMatriculada);
            _dbcontext.SaveChanges();
        }
       
    }
}
