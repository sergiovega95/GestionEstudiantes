using EstudiantesCore.Entidades;
using EstudiantesCore.Interfaces;
using EstudiantesInfraestruture.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstudiantesInfraestruture.Implementations
{
    public class GestionProfesores : IGestionProfesores
    {
        private readonly AppDbContext _dbcontext;

        public GestionProfesores (AppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void ActualizarProfesor(Profesor profesor)
        {
            profesor.TipoDocumento = profesor.TipoDocumento != null ? _dbcontext.TipoDocumento.Find(profesor.TipoDocumento.Id): profesor.TipoDocumento;
            profesor.Estado = profesor.Estado != null ? _dbcontext.EstadoProfesor.Find(profesor.Estado.Id) : profesor.Estado;
            _dbcontext.Update<Profesor>(profesor);
            _dbcontext.SaveChanges();
        }

        public void CrearProfesor(Profesor profesor)
        {
            profesor.TipoDocumento = _dbcontext.TipoDocumento.Find(profesor.TipoDocumento.Id);
            profesor.Estado =  _dbcontext.EstadoProfesor.Find(profesor.Estado.Id);
            _dbcontext.Profesor.Add(profesor);
            _dbcontext.SaveChanges();
        }

        public bool ExisteProfesorByDocumento(int idTipoDocumento, string documento)
        {
            return _dbcontext.Profesor.Any(s => s.TipoDocumento.Id == idTipoDocumento && s.Documento.ToUpper() == documento.ToUpper());
        }

        public EstadoProfesor GetEstadoByCode(string code)
        {
            return _dbcontext.EstadoProfesor.Where(s => s.Code.ToUpper() == code.ToUpper()).AsNoTracking().FirstOrDefault();
        }

        public List<EstadoProfesor> GetEstadosProfesor()
        {
            return _dbcontext.EstadoProfesor.AsNoTracking().ToList();
        }

        public Profesor GetProfesorById(int idProfesor)
        {
            return  _dbcontext.Profesor.Find(idProfesor);
        }

        public List<Profesor> GetProfesores()
        {
            return _dbcontext.Profesor.Include(s=>s.TipoDocumento).Include(f=>f.Estado).AsNoTracking().ToList();
        }
    }
}
