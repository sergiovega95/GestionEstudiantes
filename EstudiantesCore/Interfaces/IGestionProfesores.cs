using EstudiantesCore.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Interfaces
{
    public interface IGestionProfesores
    {
        List<Profesor> GetProfesores();

        void CrearProfesor(Profesor profesor);

        void ActualizarProfesor(Profesor profesor);

        List<EstadoProfesor> GetEstadosProfesor();

        EstadoProfesor GetEstadoByCode(string code);

        Profesor GetProfesorById(int idProfesor);

        bool ExisteProfesorByDocumento(int idTipoDocumento , string documento);

    }
}
