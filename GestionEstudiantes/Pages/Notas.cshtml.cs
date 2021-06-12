using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore.Dtos;
using EstudiantesCore.Entidades;
using EstudiantesCore.Enums;
using EstudiantesCore.Exceptions;
using EstudiantesCore.Interactores;
using EstudiantesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GestionEstudiantes.Pages
{
    public class NotasModel : PageModel
    {
        private readonly IGestionEstudiante _estudiante ;
        private readonly ILogger<EstudiantesModel> _logger;
        private readonly IMatricula _matricula;
        private readonly IGestionMaterias _materias;

        public void OnGet()
        {
           
        }

        public NotasModel ( ILogger<EstudiantesModel> logger , IGestionMaterias materias)
        {
           
            _logger = logger;
            _materias = materias;
            
        }

        [HttpGet]
        public IActionResult OnGetObtenerMateriasMatriculadasEstudiante(DataSourceLoadOptions options, int idEstudiante)
        {
            try
            {
                List<EstudiantesXMateria> materias = new List<EstudiantesXMateria>();

                if (idEstudiante != 0)
                {
                    materias = _materias.GetMateriasByEstudiante(idEstudiante).Where(s=>s.Estado.Code==EnumEstadoMateria.Activo).ToList();
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
        /// <param name="options"></param>
        /// <param name="idEstudianteXMateria"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> OnGetCargarNotas(DataSourceLoadOptions options , int idEstudianteXMateria)
        {
            try
            {
                List<Notas> notas = new List<Notas>();

                if (idEstudianteXMateria>0)
                {
                    notas= await _materias.GetNotasByMateriaEstudiante(idEstudianteXMateria);
                }

                return new JsonResult(DataSourceLoader.Load(notas, options));
            }
            catch (Exception e)
            {
                _logger.LogError("Error al cargar las notas del estudiante", e);
                return BadRequest("Error al cargar las notas del estudiante");
            }

        }

        /// <summary>
        /// Crea una nueva nota
        /// </summary>
        /// <param name="values">los datos</param>
        /// <param name="idEstudianteXMateria">id de la relación materia por estudiante</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> OnPostCrearNota(string values , int idEstudianteXMateria)
        {
            try
            {
                if (idEstudianteXMateria>0)
                {
                    Notas nota = JsonConvert.DeserializeObject<Notas>(values);
                    nota.Materia = new EstudiantesXMateria() { Id = idEstudianteXMateria };                    
                    await _materias.CrearNota(nota);


                }

                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError("Error al crear la nota del estudiante", e);
                return BadRequest("Error al crear la nota del estudiante");
            }
        }

        /// <summary>
        /// actualiza una nota
        /// </summary>
        /// <param name="key">la llave primaria</param>
        /// <param name="values">cambios entidad</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> OnPutActualizarNota(int key, string values)
        {
            try
            {
                if (key > 0)
                {
                    Notas notaActual = await _materias.GetNotaById(key);
                    JsonConvert.PopulateObject(values, notaActual);
                    await _materias.ActualizarNota(notaActual);

                }

                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError("Error al actualizar la nota del estudiante", e);
                return BadRequest("Error al actualizar la nota del estudiante");
            }
        }

        /// <summary>
        /// Borra una nota 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> OnDeleteBorrarNota (int key)
        {
            try
            {
                if (key > 0)
                {
                    await _materias.BorrarNota(key);
                }

                return StatusCode(200);
            }
            catch (Exception e)
            {
                _logger.LogError("Error al borrar la nota del estudiante", e);
                return BadRequest("Error al borrar la nota del estudiante");
            }
        }
    }
}
