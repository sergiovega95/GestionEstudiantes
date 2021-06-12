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
using System.Threading.Tasks;

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
            materiaMatriculada.Estado = materiaMatriculada.Estado != null ? _dbcontext.EstadoMateria.Find(materiaMatriculada.Estado.Id) : null;
            _dbcontext.Update<EstudiantesXMateria>(materiaMatriculada);
            _dbcontext.SaveChanges();
        }


        public async Task<Notas> GetNotaById(int IdNota)
        {
            return await _dbcontext.Notas.FindAsync(IdNota);
        }

        public async  Task ActualizarNota(Notas nota)
        {
            _dbcontext.Update(nota);
            await _dbcontext.SaveChangesAsync();
        }

        public async  Task BorrarNota(int idNota)
        {
            Notas nota = await _dbcontext.Notas.FindAsync(idNota);

            if (nota!=null)
            {
                _dbcontext.Notas.Remove(nota);
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task CrearNota(Notas nota)
        {            
            nota.Materia = await _dbcontext.EstudianteXMaterias.FindAsync(nota.Materia.Id);
            _dbcontext.Notas.Add(nota);
            await _dbcontext.SaveChangesAsync();
        }

        public EstudiantesXMateria GetMateriaEstudianteById(int idMateriaEstudiante)
        {
            return _dbcontext.EstudianteXMaterias.Find(idMateriaEstudiante);
        }

        public List<EstudiantesXMateria> GetMateriasByEstudiante(int idEstudiante)
        {
            List<EstudiantesXMateria> materias = _dbcontext.EstudianteXMaterias.Where(s => s.Estudiante.Id == idEstudiante)
                                                 .Include(s => s.Materia).Include(s => s.Estado).AsNoTracking().ToList();

            return materias;
        }

        public List<Materia> GetMateriasPorDefecto()
        {
            return _dbcontext.Materia.Where(s => s.MatriculaPorDefecto).AsNoTracking().ToList();
        }

        public async Task<List<Notas>> GetNotasByMateriaEstudiante(int idEstudianteXMateria)
        {
            return await _dbcontext.Notas.Where(s => s.Materia.Id == idEstudianteXMateria).ToListAsync();
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
