import React, { useEffect, useState } from "react";
import { TaskFormProps } from "../types/taskForm";

const TaskForm: React.FC<TaskFormProps> = ({
  onSubmit,
  editingTask,
  cancelEdit,
}) => {
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");

  useEffect(() => {
    if (editingTask) {
      setTitle(editingTask.title);
      setDescription(editingTask.description);
    }
  }, [editingTask]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();

    if (title.trim() === "") {
      alert("El título es obligatorio");
      return;
    }
    if (description.trim().length < 10) {
      alert("La descripción debe tener al menos 10 caracteres");
      return;
    }

    onSubmit({ title, description });
    setTitle("");
    setDescription("");
  };

  return (
    <form onSubmit={handleSubmit} className="mb-6">
      <input
        type="text"
        placeholder="Título"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
        className="border p-2 rounded w-full mb-2"
      />
      <textarea
        placeholder="Descripción"
        value={description}
        onChange={(e) => setDescription(e.target.value)}
        className="border p-2 rounded w-full mb-2"
      />
      <button
        type="submit"
        className="bg-primary text-white p-2 rounded w-full"
      >
        {editingTask ? "Actualizar Tarea" : "Crear Tarea"}
      </button>
      {editingTask && (
        <button
          type="button"
          onClick={cancelEdit}
          className="bg-gray-500 text-white p-2 rounded w-full mt-2"
        >
          Cancelar
        </button>
      )}
    </form>
  );
};

export default TaskForm;
