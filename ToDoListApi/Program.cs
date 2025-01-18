using Microsoft.EntityFrameworkCore;
using ToDoListApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Registrar el DbContext con una base de datos en memoria
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseInMemoryDatabase("TaskDatabase"));

// Registrar controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
