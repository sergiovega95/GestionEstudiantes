using EstudiantesCore.Entidades;
using EstudiantesCore.Interfaces;
using EstudiantesInfraestruture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesInfraestruture.Implementations
{
    public class Estudiantes:IEstudiantes
    {
        private readonly ApplicationDbContext _dbContext;

        public Estudiantes(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Agregar un número estudiante
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        public async Task MatricularEstudiante(Estudiante estudiante)
        {
            estudiante.Estado = _dbContext.EstadoEstudiante.Where(s => s.Code.ToUpper() == "A").FirstOrDefault();
            _dbContext.Estudiante.Add(estudiante);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Obtiene todos los estudiantes matriculados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Estudiante>> GetAllEstudiantes()
        {
            return await _dbContext.Estudiante
                            .Include(s=>s.TipoDocumento)
                            .Include(s=>s.Estado)
                            .ToListAsync();
        }

        /// <summary>
        /// Obtiene la información de un estudiante por su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Estudiante> GetEstudianteById(int Id)
        {
            return await _dbContext.Estudiante
                   .Include(s=>s.TipoDocumento)
                   .Include(s=>s.Estado)
                   .Where(s => s.Id == Id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// actualiza 
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        public async Task ActualizarEstudiante(Estudiante estudiante)
        {
            bool existeEstudiante = await _dbContext.Estudiante.AnyAsync(s => s.Id == estudiante.Id);

            if (existeEstudiante)
            {
                _dbContext.Estudiante.Update(estudiante);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Usuario no encontrado");
            }           
        }

        /// <summary>
        /// Obtiene todas las materías que tiene un estudiante
        /// </summary>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        public async Task<List<MateriasXEstudiante>> GetMateriasByEstudiante(int idEstudiante)
        {
            return await _dbContext.MateriasXEstudiante
                         .Where(s => s.Estudiante.Id == idEstudiante)
                         .Include(s => s.Estado)
                         .Include(s => s.Materia).ToListAsync();
        }
    }
}
