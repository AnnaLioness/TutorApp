using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class SubjectRepository : BaseRepository<SubjectModel>
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить все предметы (переопределение)
        /// </summary>
        public override async Task<IEnumerable<SubjectModel>> GetAllAsync()
        {
            return await _dbSet
                .OrderBy(s => s.SubjectName)
                .ToListAsync();
        }

        /// <summary>
        /// Получить предмет по названию
        /// </summary>
        public async Task<SubjectModel?> GetByName(string subjectName)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.SubjectName.ToLower() == subjectName.ToLower());
        }

        /// <summary>
        /// Получить предметы с типами занятий
        /// </summary>
        public async Task<IEnumerable<SubjectModel>> GetWithTypes()
        {
            return await _dbSet
                .Include(s => s.Types)  // предполагается, что в SubjectModel есть коллекция Types
                .OrderBy(s => s.SubjectName)
                .ToListAsync();
        }
    }
}
