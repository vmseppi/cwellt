function App() {
  const tasks = [
    {
      id: 1,
      title: "Configurar TypeScript",
      description: "Configurar TypeScript en el proyecto React",
      isCompleted: false,
      createdAt: new Date(),
    },
    {
      id: 2,
      title: "Crear componente Task",
      description: "Crear un componente para mostrar una tarea",
      isCompleted: true,
      createdAt: new Date(),
    },
  ];

  return (
    <div className="bg-gray-100 min-h-screen flex items-center justify-center">
      <div className="w-3/4 bg-white shadow-md rounded-lg p-8">
        <h1 className="text-2xl font-bold mb-6">To-Do List</h1>
        <ul className="space-y-4">
          {tasks.map((task) => (
            <li
              key={task.id}
              className={`p-4 rounded-lg ${
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
                Creada el: {task.createdAt.toLocaleString()}
              </p>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}

export default App;
