# ToDoList API

Este proyecto es una API REST para gestionar tareas (To-Do List). Está desarrollado en **ASP.NET Core 9.0** con soporte para Swagger para la documentación interactiva y utiliza una base de datos en memoria para facilitar las pruebas y el desarrollo.

---

## 🚀 Instrucciones para ejecutar el proyecto localmente

### **Requisitos previos**

1. Tener instalado el SDK de .NET 9.0. Puedes verificar tu instalación con:
   ```bash
   dotnet --version
   ```

### \*Pasos para ejecutar

Clonar el repositorio:

git clone <https://github.com/vmseppi/cwellt.git>
cd cwellt

CONFIGURAR Y EJECUTAR BACKEND (API)

1-Accede a la carpeta del backend: cd ToDoListApi
2-Restaura las dependencias: dotnet restore
3-Compila el proyecto: dotnet build
4-Ejecuta el servidor: dotnet run

Una vez que la API esté corriendo, abre tu navegador y accede a Swagger para interactuar con los endpoints:
http://localhost:5000/swagger

CONFIGURAR Y EJECUTAR FRONTEND:
1-Volver a la raiz del proyecto: cwellt
2-Acceder a frontend : cd to-do-list
3-Instala las dependencias del proyecto: npm install
4-Ejecuta servidor de desarrollo: npm start
5-Abre tu navegador y accede al frontend en: http://localhost:3000

🛠️ Decisiones técnicas tomadas
Framework: Se utilizó ASP.NET Core 9.0.

Base de datos en memoria:
Para simplificar las pruebas y el desarrollo inicial, se configuró una base de datos en memoria utilizando Entity Framework Core.
Esto evita la necesidad de instalar y configurar una base de datos externa.

Swagger:
Integrado para proporcionar documentación interactiva de los endpoints de la API.
Esto facilita a los desarrolladores explorar y probar la API directamente desde el navegador.

CORS:
Configurado para permitir cualquier origen, método y encabezado durante el desarrollo.
En producción, esta configuración debería restringirse para mayor seguridad.

📌 Notas adicionales

Documentación XML: El proyecto está configurado para generar un archivo XML con los comentarios de los controladores y endpoints. Esto se integra automáticamente con Swagger.
Extensibilidad:
🧩 Endpoints disponibles

Los principales endpoints de la API incluyen:

GET /api/task: Obtiene todas las tareas.
GET /api/task/{id}: Obtiene una tarea específica por ID.
POST /api/task: Crea una nueva tarea.
PUT /api/task/{id}: Actualiza una tarea existente.
DELETE /api/task/{id}: Elimina una tarea.
Para más detalles, consulta Swagger en http://localhost:5000/swagger.

💬 Contacto
Si tienes alguna pregunta o sugerencia, no dudes en contactarme:

Email: vmseppi@gmail.com
GitHub: https://github.com/vmseppi
