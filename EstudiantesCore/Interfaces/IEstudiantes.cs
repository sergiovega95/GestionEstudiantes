using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstudiantesCore.Interfaces
{
    public interface IEstudiantes
    {
        Task MatricularEstudiante(Estudiante estudiante);

        Task<List<Estudiante>> GetAllEstudiantes();

        Task<Estudiante> GetEstudianteById(int Id);

        Task ActualizarEstudiante(Estudiante estudiante);

        Task<List<MateriasXEstudiante>> GetMateriasByEstudiante(int idEstudiante);
    }
}
