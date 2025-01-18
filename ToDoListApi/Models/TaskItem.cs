using System;

namespace ToDoListApi.Models
{ 
    /// <summary>
    /// Representa una tarea en la lista.
    /// </summary>
   public class TaskItem
{   
     /// <summary>
    /// Identificador único de la tarea.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Título de la tarea.
    /// </summary>
    public required string Title { get; set; }
     /// <summary>
    /// Descripción detallada de la tarea.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Indica si la tarea está completada.
    /// </summary>
    public bool IsCompleted { get; set; }
      /// <summary>
    /// Fecha de creación de la tarea.
    /// </summary>
    public DateTime CreatedAt { get; set; }
}

}
