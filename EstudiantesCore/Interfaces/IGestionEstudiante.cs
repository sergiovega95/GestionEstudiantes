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

        List<TipoDocumento> GetDocumentos();

        List<EstadoEstudiante> GetEstados();

        bool VerificarEstudianteByDocumento(int IdTipoDocumento , string Documento);

        EstadoEstudiante GetEstadoByCodigo(string codigo);

        List<Materia> GetMaterias();

        List<EstadoMateria> GetEstadosMateria();

        bool VerificarCodigoUnicoMateria(string codigo);

        void CrearNuevaMateria(Materia nuevaMateria);

        Materia GetMateriaById(int Id);

        void ActualizarMateria(Materia materia);

    }
}
