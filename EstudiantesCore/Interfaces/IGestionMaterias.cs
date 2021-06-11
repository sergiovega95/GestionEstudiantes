using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Interfaces
{
    public interface IGestionMaterias 
    {

        List<EstudiantesXMateria> GetMateriasByEstudiante(int idEstudiante);

        void MatricularMateria(EstudiantesXMateria materiaMatriculada);

        void ActualizarMateriaMatriculada(EstudiantesXMateria materiaMatriculada);

        EstudiantesXMateria GetMateriaEstudianteById(int idMateriaEstudiante);

        List<Materia> GetMateriasPorDefecto() ;

    }
}
