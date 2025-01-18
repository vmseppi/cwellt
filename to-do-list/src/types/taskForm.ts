import { Task } from "./task";

export interface TaskFormProps {
  onSubmit: (task: Omit<Task, "id" | "isCompleted" | "createdAt">) => void;
  editingTask?: Task | null;
  cancelEdit: () => void;
}
