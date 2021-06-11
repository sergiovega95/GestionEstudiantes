using System;
using System.Collections.Generic;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.Entidades;
using EstudiantesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GestionEstudiantes.Pages
{
    public class MateriasEstudiante : PageModel
    {
        private readonly IGestionEstudiante _estudiante ;
        private readonly ILogger<MateriasEstudiante> _logger;
        private readonly IGestionMaterias _materias;

        public void OnGet()
        {
           
        }


        public MateriasEstudiante(IGestionEstudiante estudiante, ILogger<MateriasEstudiante> logger , IGestionMaterias materias)
        {
            _estudiante = estudiante;
            _logger = logger;
            _materias = materias;
        }

        [HttpGet]
        public IActionResult OnGetObtenerInformacionEstudiante(string documento)
        {
            try
            {
                return StatusCode(200, _estudiante.ObtenerEstudianteByDocumento(documento));
            }
            catch (Exception e)
            {
                _logger.LogError("Error al obtener la información de un estudiante", e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult OnGetObtenerMateriasMatriculadasEstudiante(DataSourceLoadOptions options , int idEstudiante)
        {
            try
            {
                List<EstudiantesXMateria> materias = new List<EstudiantesXMateria>();

                if (idEstudiante != 0)
                {
                    materias = _materias.GetMateriasByEstudiante(idEstudiante);
                }
                
                return new JsonResult(DataSourceLoader.Load(materias, options));
            }
            catch (Exception e)
            {
                _logger.LogError("Error al obtener las materías de un estudiante", e);
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="idEstudiante"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OnPostCrearMateriaEstudiante(string values , int idEstudiante)
        {
            try
            {              
                if (idEstudiante != 0)
                {
                    EstudiantesXMateria materia = JsonConvert.DeserializeObject<EstudiantesXMateria>(values);
                    materia.Estudiante = new Estudiantes() { Id = idEstudiante };                   
                    _materias.MatricularMateria(materia);                    
                }

                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError("Error al obtener las materías de un estudiante", e);
                return BadRequest("Error al matricular la matería");
            }
        }

        /// <summary>
        /// Actualiza el estado de una matería o demas
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult OnPutActualizarMateriaEstudiante(int key , string values)
        {
            try
            {
                if (key != 0)
                {
                    EstudiantesXMateria materia = _materias.GetMateriaEstudianteById(key);
                    JsonConvert.PopulateObject(values, materia);
                    _materias.ActualizarMateriaMatriculada(materia);
                }

                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError("Error al obtener las materías de un estudiante", e);
                return BadRequest("Error al actualizar la matería");
            }
        }


    }
}
