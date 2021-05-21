using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudiantesCore.Dtos;
using EstudiantesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEstudiantes.Pages
{
    public class EstudiantesModel : PageModel
    {
        private readonly IEstudiantes _gestionEstudiante;

        public EstudiantesModel(IEstudiantes gestionEstudiante)
        {
            _gestionEstudiante = gestionEstudiante;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// Metodo que crea un nuevo estudiante
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OnPostCrearEstudiante(EstudianteDTO estudiante)
        {
            try
            {
                if(TryValidateModel(estudiante))
                {
                    //_gestionEstudiante.MatricularEstudiante(estu);
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(400);
                }
                
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        /// <summary>
        /// Metodo que verifica que la identificación del núevo estudiante sea unica 
        /// </summary>
        /// <param name="identificacion">identificación del estudiante</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetVerificarIdentificacionUnica(string identificacion)
        {
            try
            {
                return StatusCode(200, true);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Actualiza la información de un usuario existente
        /// </summary>
        /// <param name="estudiante"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult OnPutActualizarEstudiante(EstudianteDTO estudiante)
        {
            try
            {
                if (TryValidateModel(estudiante))
                {
                    //_gestionEstudiante.ActualizarEstudiante(estu);
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(400);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Obtener estudiante
        /// </summary>
        /// <param name="idEstudiante">id estudiante</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetEstudiante(int idEstudiante)
        {
            try
            {
                return StatusCode(200);
            }
            catch (Exception e)
            {
               return StatusCode(500, e.Message);
            }
        }

        
    }
}
