using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using EstudiantesCore;
using EstudiantesCore.Entidades;
using EstudiantesCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace GestionEstudiantes.Pages
{
    public class ProfesoresModel : PageModel
    {
        private readonly IGestionProfesores _profesores;

        public ProfesoresModel(IGestionProfesores profesores)
        {
            _profesores = profesores;
        }

        public void OnGet()
        {
        }

        /// <summary>
        /// Obtiene todos los profesores inscritos en el aplicativo
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetObtenerProfesores(DataSourceLoadOptions loadOptions)
        {
            try
            {
                List<Profesor> profesores = _profesores.GetProfesores();
                return new JsonResult(DataSourceLoader.Load(profesores, loadOptions));
            }
            catch (Exception e)
            {
                return BadRequest("Ocurrió un error al cargar los profesores");
            }
        }

        /// <summary>
        /// Metodo que crea un nuevo profesor
        /// </summary>
        /// <param name="values">json con los valores del nuevo profesor</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult OnPostCrearProfesor(string values)
        {
            try
            {

                Profesor nuevo = JsonConvert.DeserializeObject<Profesor>(values);
                nuevo.Estado = _profesores.GetEstadoByCode(EnumEstadosProfesor.Activo);

                if (nuevo.Id!=0)
                {
                    return BadRequest("Modelo invalido");
                }
                else
                {
                    _profesores.CrearProfesor(nuevo);
                    return StatusCode(200);
                }
                
            }
            catch (Exception e)
            {
                return BadRequest("Ocurrió un error al registrar un nuevo profesor");
            }
        }

        /// <summary>
        /// Actualiza los datos un profesor
        /// </summary>
        /// <param name="key">id unico del profesor</param>
        /// <param name="values">json con los cambios</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult OnPutActualizarProfesor(int key , string values)
        {
            try
            {
                if (key==0)
                {
                    return BadRequest("Modelo invalido");
                }
                else
                {
                    Profesor ProfesorExistente = _profesores.GetProfesorById(key);
                    JsonConvert.PopulateObject(values, ProfesorExistente);
                    _profesores.ActualizarProfesor(ProfesorExistente);
                    return StatusCode(200);
                }
            }
            catch (Exception e)
            {
               return BadRequest("Error al actualizar los datos del profesor");
            } 
        }

        /// <summary>
        /// Verifica que un profesor no exista 
        /// </summary>
        /// <param name="idTipoDocumento">is del tipo de documento</param>
        /// <param name="documento">documento</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetIdentificacionUnica(int idTipoDocumento, string documento)
        {
            try
            {
                bool noExiste = true;

                if (idTipoDocumento>0 && !string.IsNullOrEmpty(documento))
                {
                    noExiste = !_profesores.ExisteProfesorByDocumento(idTipoDocumento, documento);
                }

                return StatusCode(200, noExiste);
               
            }
            catch (Exception e)
            {               
                return StatusCode(500, "Ocurrio un error en el sistema");
            }

            
        }

        /// <summary>
        /// obtiene los estados
        /// </summary>
        /// <param name="loader"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult OnGetEstadosProfesores(DataSourceLoadOptions options)
        {
            try
            {
                List<EstadoProfesor> estados = _profesores.GetEstadosProfesor();
                return new JsonResult(DataSourceLoader.Load(estados, options));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


    }
}
