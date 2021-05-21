using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudiantesCore.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionEstudiantes.Pages
{
    public class EstudiantesModel : PageModel
    {

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
                    return StatusCode(200, "Modelo invalido");
                }
                else
                {
                    return StatusCode(400, "Modelo invalido");
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
    }
}
