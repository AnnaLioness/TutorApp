using Models.Models;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PublicationService
    {
        private readonly PublicationRepository _publicationRepository;
        private readonly MaterialRepository _materialRepository;

        public PublicationService(
            PublicationRepository publicationRepository,
            MaterialRepository materialRepository)
        {
            _publicationRepository = publicationRepository;
            _materialRepository = materialRepository;
        }

        /// <summary>
        /// Получить все публикации
        /// </summary>
        public async Task<IEnumerable<PublicationModel>> GetAllPublications()
        {
            return await _publicationRepository.GetAllAsync();
        }

        /// <summary>
        /// Получить публикацию по ID
        /// </summary>
        public async Task<PublicationModel?> GetPublicationById(int id)
        {
            return await _publicationRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Получить опубликованные материалы
        /// </summary>
        public async Task<IEnumerable<PublicationModel>> GetPublishedMaterials()
        {
            return await _publicationRepository.GetPublished();
        }

        /// <summary>
        /// Снять с публикации
        /// </summary>
        public async Task<(bool success, string message)> UnpublishMaterial(int publicationId)
        {
            var publication = await _publicationRepository.GetByIdAsync(publicationId);
            if (publication == null)
                return (false, "Публикация не найдена");

            publication.IsPublicted = false;
            await _publicationRepository.UpdateAsync(publication);
            await _publicationRepository.SaveAsync();

            return (true, "Материал снят с публикации");
        }

        /// <summary>
        /// Получить последние публикации
        /// </summary>
        public async Task<IEnumerable<PublicationModel>> GetLatestPublications(int count = 10)
        {
            var all = await _publicationRepository.GetPublished();
            return all.OrderByDescending(p => p.PublicationDate).Take(count);
        }
    }
}
