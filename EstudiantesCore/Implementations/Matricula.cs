using EstudiantesCore.Entidades;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstudiantesCore.Implementations
{
    public class Matricula : IMatricula
    {
        private readonly IGestionMaterias _materia;
        private readonly IGestionEstudiante _estudiante;

        public void MatricularEstudiante(Estudiantes nuevo)
        {
            List<Materia> materiasdefecto = _materia.GetMateriasPorDefecto();
            List<EstudiantesXMateria> materiasMatricular = new List<EstudiantesXMateria>();

            foreach (var materia  in materiasdefecto)
            {
                materiasMatricular.Add(new EstudiantesXMateria() {

                     Materia= new Materia() { Id= materia.Id }
                });
            }

            _estudiante.MatricularEstudiante(nuevo, materiasMatricular);

        }
    }
}
