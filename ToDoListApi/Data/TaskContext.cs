using Microsoft.EntityFrameworkCore;
using ToDoListApi.Models;

namespace ToDoListApi.Data
{
    /// <summary>
    /// Contexto de base de datos para gestionar las tareas.
    /// </summary>
    public class TaskContext : DbContext
    {
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="TaskContext"/>.
        /// </summary>
        /// <param name="options">Opciones del contexto de base de datos.</param>
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        /// <summary>
        /// Conjunto de datos para las tareas.
        /// </summary>
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
