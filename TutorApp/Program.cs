using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Implementations;
using Services;
using System;

namespace TutorApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            var services = new ServiceCollection();

            // Путь к базе данных в папке приложения
            var dbPath = Path.Combine(Application.StartupPath, "TutorApp.db");
            Console.WriteLine($"Путь к БД: {dbPath}");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            var serviceProvider = services.BuildServiceProvider();

            // Создаём базу данных
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Вариант 1: Просто создать БД (без миграций)
                // context.Database.EnsureCreated();

                // Вариант 2: Применить миграции (рекомендуется)
                context.Database.Migrate();

                Console.WriteLine("База данных успешно создана!");
                Console.WriteLine($"Файл: {dbPath}");

                // Проверяем подключение
                if (context.Database.CanConnect())
                {
                    Console.WriteLine("Подключение к БД успешно!");

                    // Считаем количество записей в таблицах
                    Console.WriteLine($"Студентов: {context.Students.Count()}");
                    Console.WriteLine($"Уроков: {context.Lessons.Count()}");
                    Console.WriteLine($"Уровней: {context.Levels.Count()}");
                }
            }

            // Не запускаем форму, просто показываем сообщение
            MessageBox.Show($"База данных создана!\nПуть: {dbPath}", "Успешно",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            services.AddScoped<LessonRepository>();
            services.AddScoped<StudentRepository>();
            services.AddScoped<MaterialRepository>();
            services.AddScoped<PublicationRepository>();
            services.AddScoped<LevelRepository>();
            services.AddScoped<SubjectRepository>();
            services.AddScoped<TypeRepository>();

            // Регистрация сервисов
            services.AddApplicationServices();

            // Можно даже не запускать форму, если нужно только создать БД
            // Application.Run(new Form1()); // закомментируйте, если не нужно
        }
    }
}