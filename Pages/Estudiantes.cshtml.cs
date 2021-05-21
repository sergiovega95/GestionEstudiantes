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

        [HttpPost]
        public IActionResult OnPostCrearEstudiante(EstudianteDTO estudiante)
        {
            try
            {
                return StatusCode(200,"Todo quedo bien");
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }
    }
}
