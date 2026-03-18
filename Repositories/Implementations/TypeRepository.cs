using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class TypeRepository : BaseRepository<TypeModel>
    {
        public TypeRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить все типы с предметами (переопределение)
        /// </summary>
        public override async Task<IEnumerable<TypeModel>> GetAllAsync()
        {
            return await _dbSet
                .Include(t => t.Subject)
                .OrderBy(t => t.TypeName)
                .ToListAsync();
        }

        /// <summary>
        /// Получить тип по ID (переопределение)
        /// </summary>
        public override async Task<TypeModel?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(t => t.Subject)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// Получить типы по предмету
        /// </summary>
        public async Task<IEnumerable<TypeModel>> GetBySubject(int subjectId)
        {
            return await _dbSet
                .Include(t => t.Subject)
                .Where(t => t.SubjectId == subjectId)
                .OrderBy(t => t.TypeName)
                .ToListAsync();
        }

        /// <summary>
        /// Получить типы с предметами (для отчётов)
        /// </summary>
        public async Task<IEnumerable<TypeModel>> GetWithSubjects()
        {
            return await _dbSet
                .Include(t => t.Subject)
                .OrderBy(t => t.Subject.SubjectName)
                .ThenBy(t => t.TypeName)
                .ToListAsync();
        }
        public async Task<TypeModel?> GetByName(string typeName)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.TypeName.ToLower() == typeName.ToLower());
        }
    }
}
