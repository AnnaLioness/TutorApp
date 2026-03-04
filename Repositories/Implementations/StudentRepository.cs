using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class StudentRepository : BaseRepository<StudentModel>
    {
        public StudentRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить всех студентов с их уровнями (переопределение)
        /// </summary>
        public override async Task<IEnumerable<StudentModel>> GetAllAsync()
        {
            return await _dbSet
                .Include(s => s.Level)
                .OrderBy(s => s.FullName)
                .ToListAsync();
        }

        /// <summary>
        /// Получить студента по ID с уровнем (переопределение)
        /// </summary>
        public override async Task<StudentModel?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(s => s.Level)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Получить студентов по уровню
        /// </summary>
        public async Task<IEnumerable<StudentModel>> GetByLevel(int levelId)
        {
            return await _dbSet
                .Include(s => s.Level)
                .Where(s => s.LevelId == levelId)
                .OrderBy(s => s.FullName)
                .ToListAsync();
        }

        /// <summary>
        /// Получить студента со всеми его уроками
        /// </summary>
        public async Task<StudentModel?> GetWithLessons(int id)
        {
            return await _dbSet
                .Include(s => s.Level)
                .Include(s => s.Lessons)
                    .ThenInclude(l => l.Type)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Поиск студентов по имени или телефону
        /// </summary>
        public async Task<IEnumerable<StudentModel>> Search(string searchTerm)
        {
            var search = searchTerm.ToLower();

            return await _dbSet
                .Include(s => s.Level)
                .Where(s => s.FullName.ToLower().Contains(search) ||
                           s.Phone.Contains(searchTerm))
                .OrderBy(s => s.FullName)
                .ToListAsync();
        }

        /// <summary>
        /// Получить студентов без уроков за период
        /// </summary>
        public async Task<IEnumerable<StudentModel>> GetWithoutLessons(DateOnly start, DateOnly end)
        {
            // Студенты, у которых есть уроки в указанный период
            var studentsWithLessons = await _context.Lessons
                .Where(l => l.Date >= start && l.Date <= end)
                .Select(l => l.StudentId)
                .Distinct()
                .ToListAsync();

            // Все студенты, кроме тех, у кого есть уроки
            return await _dbSet
                .Include(s => s.Level)
                .Where(s => !studentsWithLessons.Contains(s.Id))
                .OrderBy(s => s.FullName)
                .ToListAsync();
        }
    }
}
