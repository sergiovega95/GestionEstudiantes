using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.Dtos;
using EstudiantesCore.Entidades;
using EstudiantesCore.Enums;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GestionEstudiantes.Pages
{
    public class EstudiantesModel : PageModel
    {
        private readonly IGestionEstudiante _estudiante ;
        private readonly ILogger<EstudiantesModel> _logger;

        public void OnGet()
        {
            _logger.LogInformation("Entre a la vista de estudiantes");
        }


        public EstudiantesModel(IGestionEstudiante estudiante, ILogger<EstudiantesModel> logger)
        {
            _estudiante = estudiante;
            _logger = logger;
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
                    estudiante.Estado = _estudiante.GetEstadoByCodigo(EnumEstadoEstudiante.Matriculado);
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
                _logger.LogError(e, "Codigo 23 Error al crear un usuarió");
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

        /// <summary>
        /// Metodo que me permite obtener un estudiante utilizando el id
        /// </summary>
        /// <param name="idEstudiante">id único del estudiante</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetObtenerEstudiante(int idEstudiante)
        {
            try
            {
                if (idEstudiante>0)
                {
                    Estudiantes estudiante = _estudiante.ObtenerEstudiante(idEstudiante);
                    return StatusCode(200, estudiante);
                }
                else
                {
                    return StatusCode(200, null);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

    }
}
