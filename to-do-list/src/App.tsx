import React, { useState, useEffect } from "react";
import TaskForm from "./components/TaskForm";
import { Task } from "./types/task";
import TaskList from "./components/TaskList";
import { getTasks, createTask, updateTask, deleteTask } from "./types/taskApi";
import { Note } from "./components/Icon";

const App = () => {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [editingTask, setEditingTask] = useState<Task | null>(null);

  useEffect(() => {
    const fetchTasks = async () => {
      try {
        const data = await getTasks();
        console.log(data);
        setTasks(data);
      } catch (error) {
        console.error("Error al cargar las tareas:", error);
      }
    };
    fetchTasks();
  }, []);

  const handleCreateOrUpdate = async (
    task: Omit<Task, "id" | "isCompleted" | "createdAt">
  ) => {
    if (editingTask) {
      const updatedTask: Task = { ...editingTask, ...task };
      try {
        await updateTask(editingTask.id, updatedTask);

        setTasks(tasks.map((t) => (t.id === editingTask.id ? updatedTask : t)));

        setEditingTask(null);
      } catch (error) {
        console.error("Error al actualizar la tarea:", error);
      }
    } else {
      try {
        const newTask = await createTask(task);
        setTasks([...tasks, newTask]);
      } catch (error) {
        console.error("Error al crear la tarea:", error);
      }
    }
  };

  const handleDelete = async (id: number) => {
    try {
      await deleteTask(id);
      setTasks(tasks.filter((task) => task.id !== id));
    } catch (error) {
      console.error("Error al eliminar la tarea:", error);
    }
  };

  const handleComplete = async (id: number) => {
    const taskToComplete = tasks.find((task) => task.id === id);
    if (!taskToComplete) return;

    const updatedTask: Task = { ...taskToComplete, isCompleted: true };
    try {
      await updateTask(id, updatedTask);
      setTasks(tasks.map((task) => (task.id === id ? updatedTask : task)));
    } catch (error) {
      console.error("Error al completar la tarea:", error);
    }
  };

  return (
    <div className="bg-purple-500 min-h-screen flex items-center justify-center py-6">
      <div className="w-3/4 bg-white shadow-md rounded-lg p-8">
        <div className="flex items-center mb-6">
          <Note />
          <h1 className="text-2xl font-bold text-primary">To-Do List</h1>
        </div>

        <TaskForm
          onSubmit={handleCreateOrUpdate}
          editingTask={editingTask}
          cancelEdit={() => setEditingTask(null)}
        />

        <div>
          <TaskList
            tasks={tasks}
            onEdit={setEditingTask}
            onDelete={handleDelete}
            onComplete={handleComplete}
          />
        </div>
      </div>
    </div>
  );
};

export default App;
