using Microsoft.EntityFrameworkCore;
using netart.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы для Swagger
builder.Services.AddSwaggerGen(); // Используем AddSwaggerGen для настройки Swagger

// Настроим DbContext с SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddControllers();

var app = builder.Build();

// Конфигурация HTTP запросов
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Генерация Swagger спецификации
    app.UseSwaggerUI(); // Интерфейс для взаимодействия с Swagger
}

app.UseHttpsRedirection();
app.MapControllers(); // Убедитесь, что добавили маршрут для контроллеров

app.Run();