using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Interfaces
{
    public interface IGestionEstudiante
    {
        void MatricularEstudiante(Estudiantes estudiante);

        void ActualizarEstudiante(Estudiantes estudiante);

        Estudiantes ObtenerEstudiante(int IdEstudiante);

        List<Estudiantes> ObtenerTodosEstudiantes();

        List<EstudiantesXMateria> ObtenerMateriasEstudiante(int IdEstudiante);
    }
}
