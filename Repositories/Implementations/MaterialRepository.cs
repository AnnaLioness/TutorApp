using Microsoft.EntityFrameworkCore;
using Models.Enums;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class MaterialRepository : BaseRepository<MaterialModel>
    {
        public MaterialRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить все материалы с полной информацией (переопределение)
        /// </summary>
        public override async Task<IEnumerable<MaterialModel>> GetAllAsync()
        {
            return await _dbSet
                .Include(m => m.Type)
                    .ThenInclude(t => t.Subject)
                .Include(m => m.Level)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        /// <summary>
        /// Получить материал по ID (переопределение)
        /// </summary>
        public override async Task<MaterialModel?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(m => m.Type)
                    .ThenInclude(t => t.Subject)
                .Include(m => m.Level)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        /// <summary>
        /// Получить материалы по уровню
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> GetByLevel(int levelId)
        {
            return await _dbSet
                .Include(m => m.Type)
                .Include(m => m.Level)
                .Where(m => m.LevelId == levelId)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        /// <summary>
        /// Получить материалы по возрастной группе
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> GetByAgeGroup(AgeGroup ageGroup)
        {
            return await _dbSet
                .Include(m => m.Type)
                .Include(m => m.Level)
                .Where(m => m.AgeGroup == ageGroup)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        /// <summary>
        /// Получить материалы по сезону
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> GetBySeason(Season season)
        {
            return await _dbSet
                .Include(m => m.Type)
                .Include(m => m.Level)
                .Where(m => m.Season == season)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        /// <summary>
        /// Получить материалы по типу занятия
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> GetByType(int typeId)
        {
            return await _dbSet
                .Include(m => m.Level)
                .Where(m => m.TypeId == typeId)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        /// <summary>
        /// Поиск материалов по названию
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> Search(string title)
        {
            return await _dbSet
                .Include(m => m.Type)
                .Include(m => m.Level)
                .Where(m => m.Title.ToLower().Contains(title.ToLower()))
                .OrderBy(m => m.Title)
                .ToListAsync();
        }
    }
}
