using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class LevelRepository : BaseRepository<LevelModel>
    {
        public LevelRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить все уровни, отсортированные по названию (переопределение)
        /// </summary>
        public override async Task<IEnumerable<LevelModel>> GetAllAsync()
        {
            return await _dbSet
                .OrderBy(l => l.LevelName)
                .ToListAsync();
        }

        /// <summary>
        /// Получить уровень по названию
        /// </summary>
        public async Task<LevelModel?> GetByName(string levelName)
        {
            return await _dbSet
                .FirstOrDefaultAsync(l => l.LevelName.ToLower() == levelName.ToLower());
        }
    }
}
