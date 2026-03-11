using Models.Models;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class DictionaryService
    {
        private readonly LevelRepository _levelRepository;
        private readonly SubjectRepository _subjectRepository;
        private readonly TypeRepository _typeRepository;

        public DictionaryService(
            LevelRepository levelRepository,
            SubjectRepository subjectRepository,
            TypeRepository typeRepository)
        {
            _levelRepository = levelRepository;
            _subjectRepository = subjectRepository;
            _typeRepository = typeRepository;
        }

        // УРОВНИ
        public async Task<IEnumerable<LevelModel>> GetAllLevels()
        {
            return await _levelRepository.GetAllAsync();
        }

        public async Task<LevelModel?> GetLevelById(int id)
        {
            return await _levelRepository.GetByIdAsync(id);
        }

        public async Task<(bool success, string message, LevelModel? level)> CreateLevel(string levelName)
        {
            if (string.IsNullOrWhiteSpace(levelName))
                return (false, "Название уровня обязательно", null);

            // Проверяем уникальность
            var existing = await _levelRepository.GetByName(levelName);
            if (existing != null)
                return (false, "Уровень с таким названием уже существует", null);

            var level = new LevelModel { LevelName = levelName };
            await _levelRepository.AddAsync(level);
            await _levelRepository.SaveAsync();

            return (true, "Уровень создан", level);
        }
        /// Обновить существующий уровень
        /// </summary>
        public async Task<(bool success, string message)> UpdateLevel(int levelId, string newLevelName)
        {
            if (string.IsNullOrWhiteSpace(newLevelName))
                return (false, "Название уровня обязательно");

            var level = await _levelRepository.GetByIdAsync(levelId);
            if (level == null)
                return (false, "Уровень не найден");

            // Проверяем, не существует ли уже другой уровень с таким названием
            var existing = await _levelRepository.GetByName(newLevelName);
            if (existing != null && existing.Id != levelId)
                return (false, "Уровень с таким названием уже существует");

            level.LevelName = newLevelName;

            // Используем метод Update из базового репозитория
            await _levelRepository.UpdateAsync(level);
            await _levelRepository.SaveAsync();

            return (true, "Уровень успешно обновлен");
        }

        /// <summary>
        /// Удалить уровень
        /// </summary>
        public async Task<(bool success, string message)> DeleteLevel(int levelId)
        {
            try
            {
                var level = await _levelRepository.GetByIdAsync(levelId);
                if (level == null)
                    return (false, "Уровень не найден");

                // Используем метод Delete из базового репозитория
                await _levelRepository.DeleteAsync(level);
                await _levelRepository.SaveAsync();

                return (true, "Уровень успешно удален");
            }
            catch (Exception ex)
            {
                return (false, $"Ошибка при удалении уровня: {ex.Message}");
            }
        }

        // ПРЕДМЕТЫ
        public async Task<IEnumerable<SubjectModel>> GetAllSubjects()
        {
            return await _subjectRepository.GetAllAsync();
        }

        public async Task<SubjectModel?> GetSubjectById(int id)
        {
            return await _subjectRepository.GetByIdAsync(id);
        }

        public async Task<(bool success, string message, SubjectModel? subject)> CreateSubject(string subjectName)
        {
            if (string.IsNullOrWhiteSpace(subjectName))
                return (false, "Название предмета обязательно", null);

            var existing = await _subjectRepository.GetByName(subjectName);
            if (existing != null)
                return (false, "Предмет с таким названием уже существует", null);

            var subject = new SubjectModel { SubjectName = subjectName };
            await _subjectRepository.AddAsync(subject);
            await _subjectRepository.SaveAsync();

            return (true, "Предмет создан", subject);
        }

        // ТИПЫ ЗАНЯТИЙ
        public async Task<IEnumerable<TypeModel>> GetAllTypes()
        {
            return await _typeRepository.GetAllAsync();
        }

        public async Task<TypeModel?> GetTypeById(int id)
        {
            return await _typeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TypeModel>> GetTypesBySubject(int subjectId)
        {
            return await _typeRepository.GetBySubject(subjectId);
        }

        public async Task<(bool success, string message, TypeModel? type)> CreateType(
            string typeName,
            int subjectId)
        {
            if (string.IsNullOrWhiteSpace(typeName))
                return (false, "Название типа обязательно", null);

            var subject = await _subjectRepository.GetByIdAsync(subjectId);
            if (subject == null)
                return (false, "Предмет не найден", null);

            var type = new TypeModel
            {
                TypeName = typeName,
                SubjectId = subjectId
            };

            await _typeRepository.AddAsync(type);
            await _typeRepository.SaveAsync();

            return (true, "Тип занятия создан", type);
        }
    }
}
