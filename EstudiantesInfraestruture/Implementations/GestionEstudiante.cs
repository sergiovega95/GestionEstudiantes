using EstudiantesCore.Entidades;
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
    public class GestionEstudiante  : IGestionEstudiante
    {
        private readonly AppDbContext _dbcontext;

        public GestionEstudiante(AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void ActualizarEstudiante(Estudiantes estudiante)
        {
            _dbcontext.Update<Estudiantes>(estudiante);
            _dbcontext.SaveChanges();           
        }

        public void MatricularEstudiante(Estudiantes estudiante)
        {
            estudiante.TipoDocumento = _dbcontext.TipoDocumento.Find(estudiante.TipoDocumento.Id);
            estudiante.Estado = _dbcontext.EstadoEstudiante.Find(estudiante.Estado.Id);
            _dbcontext.Estudiante.Add(estudiante);
            _dbcontext.SaveChanges();
        }

        public Estudiantes ObtenerEstudiante(int IdEstudiante)
        {
            Estudiantes estudiante = _dbcontext.Estudiante.Where(s => s.Id == IdEstudiante)
                                    .Include(s => s.TipoDocumento).Include(s => s.Estado).AsNoTracking().FirstOrDefault();

            return estudiante;           
        }

        public List<EstudiantesXMateria> ObtenerMateriasEstudiante(int IdEstudiante)
        {
            List<EstudiantesXMateria> materias = _dbcontext.EstudianteXMaterias.Where(s => s.Estudiante.Id == IdEstudiante)
                                                 .Include(s => s.Materia).Include(s => s.Estado).AsNoTracking().ToList();

            return materias;
        }

        public List<Estudiantes> ObtenerTodosEstudiantes()
        {
            List<Estudiantes> estudiantes = _dbcontext.Estudiante.Include(s=>s.TipoDocumento)
                                            .Include(s=>s.Estado).AsNoTracking().ToList();

            return estudiantes;
        }
           
        public List<TipoDocumento> GetDocumentos()
        {
            List<TipoDocumento> documentos = _dbcontext.TipoDocumento.ToList();
            return documentos;
        }

        public List<EstadoEstudiante> GetEstados ()
        {
            List<EstadoEstudiante> estados = _dbcontext.EstadoEstudiante.AsNoTracking().ToList();
            return estados;
        }

        public bool VerificarEstudianteByDocumento(int IdTipoDocumento, string Documento)
        {
            bool existe = _dbcontext.Estudiante
                         .Any(s => s.TipoDocumento.Id == IdTipoDocumento && s.Documento.ToUpper() == Documento);

            return existe;
        }

        public EstadoEstudiante GetEstadoByCodigo(string codigo)
        {
            EstadoEstudiante estado = _dbcontext.EstadoEstudiante.Where(s => s.Code == codigo).AsNoTracking().FirstOrDefault();
            return estado;
        }
    }
}
