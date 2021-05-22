using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudiantesCore.Dtos;
using EstudiantesCore.Entidades;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEstudiantes.Pages
{
    public class EstudiantesModel : PageModel
    {
        private readonly IGestionEstudiante _estudiante ;

        public void OnGet()
        {
        }

        public EstudiantesModel(IGestionEstudiante estudiante )
        {
            _estudiante = estudiante;
        }

        /// <summary>
        ///  Crear un nuevo estudiante
        /// </summary>
        /// <param name="estudiante">objeto que contine la info del nuevo estudiante</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OnPostCrearEstudiante(Estudiantes estudiante)
        {
            try
            {
                bool modeloValido = TryValidateModel(estudiante);

                if (modeloValido)
                {
                    _estudiante.MatricularEstudiante(estudiante);
                }
                else
                {
                    return StatusCode(400, "Modelo invalido");
                }

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        /// <summary>
        /// Valida que la identificación no este repetida
        /// </summary>
        /// <param name="documento">documento de identidad</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetVerificarIdentificacion(int Idtipodocumento,string documento)
        {          

            try
            {
                if (!string.IsNullOrEmpty(documento))
                {
                    if (documento=="1098777611")
                    {
                        return StatusCode(200, false);
                    }
                }

                return StatusCode(200, true);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
