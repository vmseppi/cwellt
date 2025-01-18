using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System;
using System.Linq;
using ToDoListApi.Models;
/// <summary>
/// Controlador para gestionar tareas en la API.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class TaskController : ControllerBase
{
    private static List<TaskItem> Tasks = new List<TaskItem>();

    /// <summary>
    /// Obtiene todas las tareas.
    /// </summary>
    /// <returns>Una lista de tareas.</returns>
    /// <response code="200">Retorna todas las tareas disponibles.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<TaskItem>> GetTasks()
    {
        return Ok(Tasks);
    }

    /// <summary>
    /// Obtiene una tarea específica por su ID.
    /// </summary>
    /// <param name="id">El ID de la tarea.</param>
    /// <returns>La tarea solicitada.</returns>
    /// <response code="200">Retorna la tarea si existe.</response>
    /// <response code="404">Retorna un mensaje indicando que la tarea no fue encontrada.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<TaskItem> GetTask(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound(new { message = "Tarea no encontrada" });
        }
        return Ok(task);
    }

    /// <summary>
    /// Crea una nueva tarea.
    /// </summary>
    /// <param name="newTask">El objeto que contiene los datos de la nueva tarea.</param>
    /// <returns>La tarea creada.</returns>
    /// <response code="201">Retorna la tarea creada exitosamente.</response>
    /// <response code="400">Retorna un mensaje indicando que la entrada no es válida.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<TaskItem> CreateTask(TaskItem newTask)
    {
        if (string.IsNullOrWhiteSpace(newTask.Title))
        {
            return BadRequest(new { message = "El título es obligatorio" });
        }

        if (string.IsNullOrWhiteSpace(newTask.Description) || newTask.Description.Length < 10)
        {
            return BadRequest(new { message = "La descripción debe tener al menos 10 caracteres" });
        }

        newTask.Id = Tasks.Count > 0 ? Tasks.Max(t => t.Id) + 1 : 1;
        newTask.CreatedAt = DateTime.Now;
        Tasks.Add(newTask);
        return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
    }

    /// <summary>
    /// Actualiza una tarea existente.
    /// </summary>
    /// <param name="id">El ID de la tarea a actualizar.</param>
    /// <param name="updatedTask">Los datos actualizados de la tarea.</param>
    /// <response code="204">La tarea fue actualizada exitosamente.</response>
    /// <response code="404">Retorna un mensaje indicando que la tarea no fue encontrada.</response>
    /// <response code="400">Retorna un mensaje indicando que los datos son inválidos.</response>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult UpdateTask(int id, TaskItem updatedTask)
    {
        if (string.IsNullOrWhiteSpace(updatedTask.Title))
        {
            return BadRequest(new { message = "El título es obligatorio" });
        }

        if (string.IsNullOrWhiteSpace(updatedTask.Description) || updatedTask.Description.Length < 10)
        {
            return BadRequest(new { message = "La descripción debe tener al menos 10 caracteres" });
        }

        var existingTask = Tasks.FirstOrDefault(t => t.Id == id);
        if (existingTask == null)
        {
            return NotFound(new { message = "Tarea no encontrada" });
        }

        existingTask.Title = updatedTask.Title;
        existingTask.Description = updatedTask.Description;
        existingTask.IsCompleted = updatedTask.IsCompleted;
        return NoContent();
    }

    /// <summary>
    /// Elimina una tarea por su ID.
    /// </summary>
    /// <param name="id">El ID de la tarea a eliminar.</param>
    /// <response code="204">La tarea fue eliminada exitosamente.</response>
    /// <response code="404">Retorna un mensaje indicando que la tarea no fue encontrada.</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteTask(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound(new { message = "Tarea no encontrada" });
        }

        Tasks.Remove(task);
        return NoContent();
    }
}
