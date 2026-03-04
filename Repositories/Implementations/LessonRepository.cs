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
    public class LessonRepository : BaseRepository<LessonModel>
    {
        public LessonRepository(AppDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Получить все уроки с полной информацией
        /// </summary>
        public override async Task<IEnumerable<LessonModel>> GetAllAsync()
        {
            return await _dbSet
                .Include(l => l.Student)
                .Include(l => l.Type)
                    .ThenInclude(t => t.Subject)
                .OrderBy(l => l.Date)
                .ThenBy(l => l.Time)
                .ToListAsync();
        }

        /// <summary>
        /// Получить урок по ID с полной информацией
        /// </summary>
        public override async Task<LessonModel?> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(l => l.Student)
                .Include(l => l.Type)
                    .ThenInclude(t => t.Subject)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        /// <summary>
        /// Получить уроки по дате
        /// </summary>
        public async Task<IEnumerable<LessonModel>> GetByDate(DateOnly date)
        {
            return await _dbSet
                .Include(l => l.Student)
                .Include(l => l.Type)
                .Where(l => l.Date == date)
                .OrderBy(l => l.Time)
                .ToListAsync();
        }

        /// <summary>
        /// ОСОБЫЙ МЕТОД: Добавление урока с проверкой на интервал в 1 час
        /// Проверяет, что новый урок начинается не ближе часа к существующим
        /// </summary>
        /// <param name="newLesson">Новый урок</param>
        /// <returns>true - урок добавлен, false - нарушен интервал в 1 час</returns>
        public async Task<bool> TryAddWithTimeCheck(LessonModel newLesson)
        {
            // Получаем все уроки на эту же дату
            var lessonsOnSameDay = await _dbSet
                .Where(l => l.Date == newLesson.Date)
                .OrderBy(l => l.Time)
                .ToListAsync();

            // Проверяем интервал с каждым существующим уроком
            foreach (var existingLesson in lessonsOnSameDay)
            {
                if (!IsOneHourApart(newLesson.Time, existingLesson.Time))
                {
                    Console.WriteLine($"Конфликт: новый урок в {newLesson.Time} " +
                                    $"и существующий в {existingLesson.Time} - " +
                                    $"меньше часа между уроками");
                    return false;
                }
            }

            // Если все проверки пройдены, добавляем урок
            await _dbSet.AddAsync(newLesson);
            return true;
        }

        /// <summary>
        /// ОСОБЫЙ МЕТОД: Обновление урока с проверкой на интервал в 1 час
        /// </summary>
        /// <param name="updatedLesson">Обновлённый урок</param>
        /// <returns>true - урок обновлён, false - нарушен интервал в 1 час</returns>
        public async Task<bool> TryUpdateWithTimeCheck(LessonModel updatedLesson)
        {
            // Получаем все уроки на эту же дату, кроме текущего
            var lessonsOnSameDay = await _dbSet
                .Where(l => l.Date == updatedLesson.Date && l.Id != updatedLesson.Id)
                .OrderBy(l => l.Time)
                .ToListAsync();

            // Проверяем интервал с каждым другим уроком
            foreach (var existingLesson in lessonsOnSameDay)
            {
                if (!IsOneHourApart(updatedLesson.Time, existingLesson.Time))
                {
                    Console.WriteLine($"Конфликт: обновлённый урок в {updatedLesson.Time} " +
                                    $"и существующий в {existingLesson.Time} - " +
                                    $"меньше часа между уроками");
                    return false;
                }
            }

            // Если все проверки пройдены, обновляем урок
            _dbSet.Update(updatedLesson);
            return true;
        }

        /// <summary>
        /// ВСПОМОГАТЕЛЬНЫЙ МЕТОД: Проверка, что между двумя временами есть минимум час
        /// </summary>
        /// <param name="time1">Первое время</param>
        /// <param name="time2">Второе время</param>
        /// <returns>true - если между временами есть хотя бы час</returns>
        private bool IsOneHourApart(TimeOnly time1, TimeOnly time2)
        {
            // Вычисляем разницу в минутах
            var diffInMinutes = Math.Abs((time1 - time2).TotalMinutes);

            // Проверяем, что разница >= 60 минут (1 час)
            // Можно добавить запас в 5 минут: diffInMinutes >= 65
            return diffInMinutes >= 60;
        }

        /// <summary>
        /// ВСПОМОГАТЕЛЬНЫЙ МЕТОД: Получить доступные временные слоты для даты
        /// Возвращает времена, которые свободны с учётом часового интервала
        /// </summary>
        public async Task<List<TimeOnly>> GetAvailableTimeSlots(DateOnly date)
        {
            // Получаем все уроки на эту дату, отсортированные по времени
            var lessons = await GetByDate(date);
            var busyTimes = lessons.Select(l => l.Time).OrderBy(t => t).ToList();

            // Все возможные времена для уроков (с 9:00 до 20:00)
            var allPossibleSlots = new List<TimeOnly>();
            for (int hour = 9; hour <= 20; hour++)
            {
                allPossibleSlots.Add(new TimeOnly(hour, 0));
                allPossibleSlots.Add(new TimeOnly(hour, 30));
            }

            // Фильтруем занятые слоты
            var availableSlots = allPossibleSlots
                .Where(slot => IsSlotAvailable(slot, busyTimes))
                .OrderBy(s => s)
                .ToList();

            return availableSlots;
        }

        /// <summary>
        /// ВСПОМОГАТЕЛЬНЫЙ МЕТОД: Проверка, доступен ли временной слот
        /// </summary>
        private bool IsSlotAvailable(TimeOnly slot, List<TimeOnly> busyTimes)
        {
            foreach (var busy in busyTimes)
            {
                if (!IsOneHourApart(slot, busy))
                {
                    return false; // Слишком близко к занятому времени
                }
            }
            return true;
        }

        /// <summary>
        /// ВСПОМОГАТЕЛЬНЫЙ МЕТОД: Проверить, свободно ли время для урока
        /// </summary>
        public async Task<bool> IsTimeSlotAvailable(DateOnly date, TimeOnly time, int? excludeLessonId = null)
        {
            var query = _dbSet.Where(l => l.Date == date);

            // Исключаем текущий урок при проверке (для обновления)
            if (excludeLessonId.HasValue)
            {
                query = query.Where(l => l.Id != excludeLessonId.Value);
            }

            var lessons = await query.ToListAsync();

            foreach (var lesson in lessons)
            {
                if (!IsOneHourApart(time, lesson.Time))
                {
                    return false; // Слишком близко к другому уроку
                }
            }

            return true; // Время свободно
        }

        /// <summary>
        /// ВСПОМОГАТЕЛЬНЫЙ МЕТОД: Найти ближайший свободный слот
        /// </summary>
        public async Task<TimeOnly?> FindNextAvailableSlot(DateOnly date, TimeOnly desiredTime)
        {
            var availableSlots = await GetAvailableTimeSlots(date);

            // Ищем первый слот после желаемого времени
            return availableSlots
                .Where(s => s >= desiredTime)
                .FirstOrDefault();
        }
    }
}
