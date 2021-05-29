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

        public List<Materia> GetMaterias()
        {
            List<Materia> materia = _dbcontext.Materia.Include(s => s.Estado).AsNoTracking().ToList();
            return materia;           
        }

        public List<EstadoMateria> GetEstadosMateria()
        {
            List<EstadoMateria> estados = _dbcontext.EstadoMateria.ToList();

            return estados;
        }

        public bool VerificarCodigoUnicoMateria(string codigo)
        {
            return _dbcontext.Materia.Any(s => s.Code.ToUpper() == codigo.ToUpper());
        }

        public void CrearNuevaMateria(Materia nuevaMateria)
        {
            nuevaMateria.Estado = _dbcontext.EstadoMateria.Find(nuevaMateria.Estado.Id);
            _dbcontext.Materia.Add(nuevaMateria);
            _dbcontext.SaveChanges();
        }

        public Materia GetMateriaById(int Id)
        {
           return _dbcontext.Materia.Find(Id);
        }

        public void ActualizarMateria(Materia materia)
        {
            if (materia.Estado.Id!=0)
            {
                materia.Estado = _dbcontext.EstadoMateria.Find(materia.Id);
            }
            _dbcontext.SaveChanges();
        }
    }
}
