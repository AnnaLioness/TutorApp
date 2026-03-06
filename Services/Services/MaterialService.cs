using Models.Enums;
using Models.Models;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MaterialService
    {
        private readonly MaterialRepository _materialRepository;
        private readonly TypeRepository _typeRepository;
        private readonly LevelRepository _levelRepository;
        private readonly PublicationRepository _publicationRepository;

        public MaterialService(
            MaterialRepository materialRepository,
            TypeRepository typeRepository,
            LevelRepository levelRepository,
            PublicationRepository publicationRepository)
        {
            _materialRepository = materialRepository;
            _typeRepository = typeRepository;
            _levelRepository = levelRepository;
            _publicationRepository = publicationRepository;
        }

        /// <summary>
        /// Получить все материалы
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> GetAllMaterials()
        {
            return await _materialRepository.GetAllAsync();
        }

        /// <summary>
        /// Получить материал по ID
        /// </summary>
        public async Task<MaterialModel?> GetMaterialById(int id)
        {
            return await _materialRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Создать новый материал
        /// </summary>
        public async Task<(bool success, string message, MaterialModel? material)> CreateMaterial(
            string title,
            string description,
            string filePath,
            int typeId,
            int levelId,
            AgeGroup ageGroup,
            Season season)
        {
            // Проверяем обязательные поля
            if (string.IsNullOrWhiteSpace(title))
                return (false, "Название обязательно", null);

            // Проверяем существование типа
            var type = await _typeRepository.GetByIdAsync(typeId);
            if (type == null)
                return (false, "Тип материала не найден", null);

            // Проверяем существование уровня
            var level = await _levelRepository.GetByIdAsync(levelId);
            if (level == null)
                return (false, "Уровень не найден", null);

            var material = new MaterialModel
            {
                Title = title,
                Description = description,
                FilePath = filePath,
                TypeId = typeId,
                LevelId = levelId,
                AgeGroup = ageGroup,
                Season = season
            };

            await _materialRepository.AddAsync(material);
            await _materialRepository.SaveAsync();

            return (true, "Материал создан", material);
        }

        /// <summary>
        /// Обновить материал
        /// </summary>
        public async Task<(bool success, string message)> UpdateMaterial(
            int materialId,
            string? title = null,
            string? description = null,
            string? filePath = null,
            int? typeId = null,
            int? levelId = null,
            AgeGroup? ageGroup = null,
            Season? season = null)
        {
            var material = await _materialRepository.GetByIdAsync(materialId);
            if (material == null)
                return (false, "Материал не найден");

            if (title != null)
                material.Title = title;
            if (description != null)
                material.Description = description;
            if (filePath != null)
                material.FilePath = filePath;
            if (typeId.HasValue)
            {
                var type = await _typeRepository.GetByIdAsync(typeId.Value);
                if (type == null)
                    return (false, "Тип не найден");
                material.TypeId = typeId.Value;
            }
            if (levelId.HasValue)
            {
                var level = await _levelRepository.GetByIdAsync(levelId.Value);
                if (level == null)
                    return (false, "Уровень не найден");
                material.LevelId = levelId.Value;
            }
            if (ageGroup.HasValue)
                material.AgeGroup = ageGroup.Value;
            if (season.HasValue)
                material.Season = season.Value;

            await _materialRepository.UpdateAsync(material);
            await _materialRepository.SaveAsync();

            return (true, "Материал обновлён");
        }

        /// <summary>
        /// Удалить материал
        /// </summary>
        public async Task<(bool success, string message)> DeleteMaterial(int materialId)
        {
            var material = await _materialRepository.GetByIdAsync(materialId);
            if (material == null)
                return (false, "Материал не найден");

            // Проверяем, есть ли публикации
            var publications = await _publicationRepository.GetByMaterial(materialId);
            if (publications.Any())
                return (false, "Нельзя удалить материал с публикациями");

            await _materialRepository.DeleteAsync(material);
            await _materialRepository.SaveAsync();

            return (true, "Материал удалён");
        }

        /// <summary>
        /// Поиск материалов
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> SearchMaterials(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllMaterials();

            return await _materialRepository.Search(searchTerm);
        }

        /// <summary>
        /// Получить материалы для уровня
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> GetMaterialsForLevel(int levelId)
        {
            return await _materialRepository.GetByLevel(levelId);
        }

        /// <summary>
        /// Получить материалы для возрастной группы
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> GetMaterialsForAgeGroup(AgeGroup ageGroup)
        {
            return await _materialRepository.GetByAgeGroup(ageGroup);
        }

        /// <summary>
        /// Получить материалы для сезона
        /// </summary>
        public async Task<IEnumerable<MaterialModel>> GetMaterialsForSeason(Season season)
        {
            return await _materialRepository.GetBySeason(season);
        }

        /// <summary>
        /// Опубликовать материал
        /// </summary>
        public async Task<(bool success, string message)> PublishMaterial(int materialId)
        {
            var material = await _materialRepository.GetByIdAsync(materialId);
            if (material == null)
                return (false, "Материал не найден");

            await _publicationRepository.PublishMaterial(materialId);
            return (true, "Материал опубликован");
        }
    }
}
