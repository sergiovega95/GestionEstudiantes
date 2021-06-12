using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesCore.Interfaces
{
    public interface IGestionMaterias
    {

        List<EstudiantesXMateria> GetMateriasByEstudiante(int idEstudiante);

        void MatricularMateria(EstudiantesXMateria materiaMatriculada);

        void ActualizarMateriaMatriculada(EstudiantesXMateria materiaMatriculada);

        EstudiantesXMateria GetMateriaEstudianteById(int idMateriaEstudiante);

        List<Materia> GetMateriasPorDefecto();

        Task<List<Notas>> GetNotasByMateriaEstudiante(int idEstudianteXMateria); 

        Task CrearNota(Notas nota);

        Task ActualizarNota(Notas nota);

        Task BorrarNota(int idNota);

        Task<Notas> GetNotaById(int IdNota);
    }
}
