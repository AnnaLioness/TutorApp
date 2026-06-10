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

        
        public async Task<PublicationModel> AddPublication(PublicationModel publication)
        {
            await _publicationRepository.AddAsync(publication);
            await _publicationRepository.SaveAsync();
            return publication;
        }
        public async Task UpdatePublication(PublicationModel publication)
        {
            await _publicationRepository.UpdateAsync(publication);
            await _publicationRepository.SaveAsync();
        }
    }
}
