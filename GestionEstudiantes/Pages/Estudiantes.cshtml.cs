using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
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
                if (estudiante.Id==0)
                {
                   estudiante.Estado = _estudiante.GetEstadoByCodigo("M");
                   _estudiante.MatricularEstudiante(estudiante);
                }
                else
                {
                   _estudiante.ActualizarEstudiante(estudiante);
                }
                            
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500,e.Message);
            }
        }

        /// <summary>
        /// Valida que la identificaci�n no este repetida
        /// </summary>
        /// <param name="documento">documento de identidad</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetVerificarIdentificacion(int Idtipodocumento,string documento)
        {          

            try
            {
                if (!string.IsNullOrEmpty(documento) && Idtipodocumento>0)
                {
                    bool existe = !_estudiante.VerificarEstudianteByDocumento(Idtipodocumento, documento);
                    return StatusCode(200, existe);                   
                }

                return StatusCode(200, true);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Obtiene los documentos
        /// </summary>
        /// <param name="loader"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetTipoDocumento(DataSourceLoadOptions options)
        {
            try
            {
                List<TipoDocumento> documentos = _estudiante.GetDocumentos();
                return new JsonResult(DataSourceLoader.Load(documentos, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// obtiene los estados
        /// </summary>
        /// <param name="loader"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetEstados (DataSourceLoadOptions options)
        {
            try
            {
                List<EstadoEstudiante> estados  = _estudiante.GetEstados();
                return new JsonResult(DataSourceLoader.Load(estados, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult OnGetObtenerEstudiantes (DataSourceLoadOptions options)
        {
            try
            {
                List<Estudiantes> estudiantes = _estudiante.ObtenerTodosEstudiantes();
                return new JsonResult(DataSourceLoader.Load(estudiantes, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult OnGetGetEstudianteById(int IdEstudiante)
        {
            try
            {
                Estudiantes estudiante = _estudiante.ObtenerEstudiante(IdEstudiante);
                return StatusCode(200, estudiante);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
