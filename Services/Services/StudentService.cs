using Models.Models;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        private readonly LevelRepository _levelRepository;

        public StudentService(
            StudentRepository studentRepository,
            LevelRepository levelRepository)
        {
            _studentRepository = studentRepository;
            _levelRepository = levelRepository;
        }

        /// <summary>
        /// Получить всех студентов
        /// </summary>
        public async Task<IEnumerable<StudentModel>> GetAllStudents()
        {
            return await _studentRepository.GetAllAsync();
        }

        /// <summary>
        /// Получить студента по ID
        /// </summary>
        public async Task<StudentModel?> GetStudentById(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Получить студента с его уроками
        /// </summary>
        public async Task<StudentModel?> GetStudentWithLessons(int id)
        {
            return await _studentRepository.GetWithLessons(id);
        }

        /// <summary>
        /// Создать нового студента
        /// </summary>
        public async Task<(bool success, string message, StudentModel? student)> CreateStudent(
            string fullName,
            int age,
            string phone,
            int levelId)
        {
            // Проверяем возраст
            if (age < 3 || age > 100)
                return (false, "Некорректный возраст", null);

            // Проверяем телефон
            if (string.IsNullOrWhiteSpace(phone))
                return (false, "Телефон обязателен", null);

            // Проверяем существование уровня
            var level = await _levelRepository.GetByIdAsync(levelId);
            if (level == null)
                return (false, "Уровень не найден", null);

            var student = new StudentModel
            {
                FullName = fullName,
                Age = age,
                Phone = phone,
                LevelId = levelId
            };

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveAsync();

            return (true, "Студент успешно добавлен", student);
        }

        /// <summary>
        /// Обновить данные студента
        /// </summary>
        public async Task<(bool success, string message)> UpdateStudent(
            int studentId,
            string? fullName = null,
            int? age = null,
            string? phone = null,
            int? levelId = null)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
                return (false, "Студент не найден");

            if (fullName != null)
                student.FullName = fullName;

            if (age.HasValue)
            {
                if (age < 3 || age > 100)
                    return (false, "Некорректный возраст");
                student.Age = age.Value;
            }

            if (phone != null)
                student.Phone = phone;

            if (levelId.HasValue)
            {
                var level = await _levelRepository.GetByIdAsync(levelId.Value);
                if (level == null)
                    return (false, "Уровень не найден");
                student.LevelId = levelId.Value;
            }

            await _studentRepository.UpdateAsync(student);
            await _studentRepository.SaveAsync();

            return (true, "Данные студента обновлены");
        }

        /// <summary>
        /// Удалить студента
        /// </summary>
        public async Task<(bool success, string message)> DeleteStudent(int studentId)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
                return (false, "Студент не найден");

            // Можно добавить проверку на наличие будущих уроков
            await _studentRepository.DeleteAsync(student);
            await _studentRepository.SaveAsync();

            return (true, "Студент удалён");
        }

        /// <summary>
        /// Поиск студентов
        /// </summary>
        public async Task<IEnumerable<StudentModel>> SearchStudents(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllStudents();

            return await _studentRepository.Search(searchTerm);
        }

        /// <summary>
        /// Получить студентов по уровню
        /// </summary>
        public async Task<IEnumerable<StudentModel>> GetStudentsByLevel(int levelId)
        {
            return await _studentRepository.GetByLevel(levelId);
        }

        /// <summary>
        /// Получить активных студентов (с уроками в ближайшее время)
        /// </summary>
        public async Task<IEnumerable<StudentModel>> GetActiveStudents()
        {
            var allStudents = await _studentRepository.GetAllAsync();
            var today = DateOnly.FromDateTime(DateTime.Today);
            var monthLater = today.AddMonths(1);

            // Студенты, у которых есть уроки в ближайший месяц
            var activeStudents = new List<StudentModel>();
            foreach (var student in allStudents)
            {
                var lessons = await _studentRepository.GetWithLessons(student.Id);
                if (lessons?.Lessons?.Any(l => l.Date >= today && l.Date <= monthLater) == true)
                {
                    activeStudents.Add(student);
                }
            }

            return activeStudents;
        }

        /// <summary>
        /// Получить статистику по студентам
        /// </summary>
        public async Task<object> GetStudentStatistics()
        {
            var students = await _studentRepository.GetAllAsync();
            var studentsList = students.ToList();

            return new
            {
                TotalStudents = studentsList.Count,
                AverageAge = studentsList.Any() ? studentsList.Average(s => s.Age) : 0,
                // Распределение по уровням
                LevelDistribution = studentsList
                    .GroupBy(s => s.Level?.LevelName ?? "Без уровня")
                    .Select(g => new { Level = g.Key, Count = g.Count() })
            };
        }
    }
}
