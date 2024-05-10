using GestorTareas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestorTareas.Controllers
{
    [ApiController]
    [Route("controlador")]
    public class ControlTareas : ControllerBase
    {
        private static List<Tarea> tareas = new List<Tarea>();

        // Registrar tarea nueva
        [HttpPost("registrar")]
        public IActionResult CrearTarea(Tarea tarea)
        {
            tareas.Add(tarea);
            return CreatedAtAction(nameof(TareaId), new { id = tarea.Id }, tarea);
        }

        // Actualizar una tarea
        [HttpPut("Actualizar {id}")]
        public IActionResult Actualizar(int id, Tarea actualizar)
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea == null)
                return NotFound();

            tarea.Titulo = actualizar.Titulo;
            tarea.Completado = actualizar.Completado;

            return NoContent();
        }

        // Eliminar una tarea
        [HttpDelete("Eliminar{id}")]
        public IActionResult Borrar(int id)
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea == null)
                return NotFound();

            tareas.Remove(tarea);
            return NoContent();
        }

        // Lista de tareas
        [HttpGet ("lista")]
        public IEnumerable<Tarea> GetTarea()
        {
            return tareas;
        }

        // Buscar una tarea
        [HttpGet("Buscar {id}")]
        public IActionResult TareaId(int id)
        {
            var tarea = tareas.Find(t => t.Id == id);
            if (tarea == null)
                return NotFound();

            return Ok(tarea);
        }

        // Lista de tareas completadas
        [HttpGet("completadas")]
        public IEnumerable<Tarea> TareasCompletadas()
        {
            return (IEnumerable<Tarea>)tareas.Where(t => t.Completado);
        }
    }
}
