using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ToDoListApi.Models;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private static List<TaskItem> Tasks = new List<TaskItem>
    {
        new TaskItem { Id = 1, Title = "Configurar proyecto", Description = "Configurar .NET Core API", IsCompleted = false, CreatedAt = DateTime.Now },
        new TaskItem { Id = 2, Title = "Crear modelo", Description = "Definir modelo TaskItem", IsCompleted = true, CreatedAt = DateTime.Now }
    };

    // GET: api/task
    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetTasks()
    {
        return Ok(Tasks);
    }

    // GET: api/task/{id}
    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetTask(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    // POST: api/task
    [HttpPost]
    public ActionResult<TaskItem> CreateTask(TaskItem newTask)
    {
        newTask.Id = Tasks.Count > 0 ? Tasks.Max(t => t.Id) + 1 : 1;
        newTask.CreatedAt = DateTime.Now;
        Tasks.Add(newTask);
        return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
    }

    // PUT: api/task/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, TaskItem updatedTask)
    {
        var existingTask = Tasks.FirstOrDefault(t => t.Id == id);
        if (existingTask == null)
        {
            return NotFound();
        }
        existingTask.Title = updatedTask.Title;
        existingTask.Description = updatedTask.Description;
        existingTask.IsCompleted = updatedTask.IsCompleted;
        return NoContent();
    }

    // DELETE: api/task/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
        {
            return NotFound();
        }
        Tasks.Remove(task);
        return NoContent();
    }
}
