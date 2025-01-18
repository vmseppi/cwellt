import axios from "axios";
import { Task } from "../types/task";

const BASE_URL = "http://localhost:5052/api/Task";

// GET
export const getTasks = async (): Promise<Task[]> => {
  const response = await axios.get<Task[]>(BASE_URL);
  return response.data;
};

// CREATE
export const createTask = async (
  task: Omit<Task, "id" | "isCompleted" | "createdAt">
): Promise<Task> => {
  const response = await axios.post<Task>(`${BASE_URL}`, task);
  return response.data;
};

// PATCH
export const updateTask = async (
  id: number,
  updatedTask: Task
): Promise<void> => {
  await axios.put(`${BASE_URL}/${id}`, updatedTask);
};

// DELETE
export const deleteTask = async (id: number): Promise<void> => {
  await axios.delete(`${BASE_URL}/${id}`);
};
