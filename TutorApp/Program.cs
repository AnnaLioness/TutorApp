using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Implementations;
using Services;
using Services.Services;
using System;

namespace TutorApp
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
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

            


            // Не запускаем форму, просто показываем сообщение
           // MessageBox.Show($"База данных создана!\nПуть: {dbPath}", "Успешно",MessageBoxButtons.OK, MessageBoxIcon.Information);
            services.AddTransient<LessonRepository>();
            services.AddTransient<StudentRepository>();
            services.AddTransient<MaterialRepository>();
            services.AddTransient<PublicationRepository>();
            services.AddTransient<LevelRepository>();
            services.AddTransient<SubjectRepository>();
            services.AddTransient<TypeRepository>();
            // Регистрация сервисов
            services.AddTransient<StudentService>();
            services.AddTransient<DictionaryService>();
            services.AddTransient<LessonService>();
            services.AddTransient<MaterialService>();
            services.AddTransient<PublicationService>();
            services.AddTransient<FormMain>();
            services.AddTransient<FormStudents>();
            services.AddTransient<FormStudent>();
            services.AddTransient<FormLevels>();
            ServiceProvider = services.BuildServiceProvider();

            // Создаём базу данных
            using (var scope = ServiceProvider.CreateScope())
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

            // Регистрация сервисов
            services.AddApplicationServices();

            // Можно даже не запускать форму, если нужно только создать БД
            Application.Run(ServiceProvider.GetRequiredService<FormMain>()); // закомментируйте, если не нужно
        }
    }
}