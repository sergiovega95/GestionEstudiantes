using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Interactores
{
    public interface IMatricula
    {
        void MatricularEstudiante(Estudiantes estudiante);

        void ActualizarEstudiante(Estudiantes estudiante);

        Estudiantes ObtenerEstudiante(int IdEstudiante);

        List<Estudiantes> ObtenerTodosEstudiantes();

        List<EstudiantesXMateria> ObtenerMateriasEstudiante(int IdEstudiante);
    }
}
