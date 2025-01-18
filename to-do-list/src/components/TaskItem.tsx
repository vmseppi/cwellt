import React from "react";
import { Task } from "../types/task";

interface TaskItemProps {
  task: Task;
  onEdit: (task: Task) => void;
  onDelete: (id: number) => void;
  onComplete: (id: number) => void;
}

const TaskItem: React.FC<TaskItemProps> = ({
  task,
  onEdit,
  onDelete,
  onComplete,
}) => {
  return (
    <li
      className={`flex flex-col items-left max-w-[300px] min-h-[250px] mb-6 p-4 rounded-lg ${
        task.isCompleted ? "bg-green-100" : "bg-red-100"
      }`}
    >
      <h2 className="text-xl font-semibold">{task.title}</h2>
      <p className="text-gray-600">{task.description}</p>
      <p
        className={`mt-2 font-bold ${
          task.isCompleted ? "text-green-600" : "text-red-600"
        }`}
      >
        {task.isCompleted ? "✅ Completada" : "❌ Pendiente"}
      </p>
      <p className="text-sm text-gray-500">
        Creada el: {new Date(task.createdAt).toLocaleString()}
      </p>
      <div className="mt-2 flex items-center mb-6">
        <button
          className="px-4 py-2 mr-4 bg-yellow-400 text-white rounded"
          onClick={() => onEdit(task)}
        >
          Editar
        </button>
        <button
          className="px-4 py-2 bg-red-500 text-white rounded"
          onClick={() => onDelete(task.id)}
        >
          Eliminar
        </button>
      </div>
      <button
        className="px-4 py-2 bg-primary text-white rounded"
        onClick={() => onComplete(task.id)}
      >
        {task.isCompleted ? "Marcar como pendiente" : "Marcar como completada"}
      </button>
    </li>
  );
};

export default TaskItem;
