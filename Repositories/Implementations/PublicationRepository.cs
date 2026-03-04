using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class PublicationRepository : BaseRepository<PublicationModel>
    {
        public PublicationRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить все публикации с материалами (переопределение)
        /// </summary>
        public override async Task<IEnumerable<PublicationModel>> GetAllAsync()
        {
            return await _dbSet
                .Include(p => p.Material)
                    .ThenInclude(m => m.Type)
                .Include(p => p.Material)
                    .ThenInclude(m => m.Level)
                .OrderByDescending(p => p.PublicationDate)
                .ToListAsync();
        }

        /// <summary>
        /// Получить публикацию по ID (переопределение)
        /// </summary>
        public override async Task<PublicationModel?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Material)
                    .ThenInclude(m => m.Type)
                .Include(p => p.Material)
                    .ThenInclude(m => m.Level)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Получить опубликованные материалы
        /// </summary>
        public async Task<IEnumerable<PublicationModel>> GetPublished()
        {
            return await _dbSet
                .Include(p => p.Material)
                .Where(p => p.IsPublicted)
                .OrderByDescending(p => p.PublicationDate)
                .ToListAsync();
        }

        /// <summary>
        /// Получить публикации за период
        /// </summary>
        public async Task<IEnumerable<PublicationModel>> GetByDateRange(DateTime start, DateTime end)
        {
            return await _dbSet
                .Include(p => p.Material)
                .Where(p => p.PublicationDate >= start && p.PublicationDate <= end)
                .OrderByDescending(p => p.PublicationDate)
                .ToListAsync();
        }

        /// <summary>
        /// Получить публикации по материалу
        /// </summary>
        public async Task<IEnumerable<PublicationModel>> GetByMaterial(int materialId)
        {
            return await _dbSet
                .Include(p => p.Material)
                .Where(p => p.MaterialId == materialId)
                .OrderByDescending(p => p.PublicationDate)
                .ToListAsync();
        }

        /// <summary>
        /// Опубликовать материал
        /// </summary>
        public async Task PublishMaterial(int materialId)
        {
            var publication = new PublicationModel
            {
                MaterialId = materialId,
                PublicationDate = DateTime.Now,
                IsPublicted = true
            };

            await _dbSet.AddAsync(publication);
            await SaveAsync();
        }
    }
}
