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
    public class LessonService
    {
        private readonly LessonRepository _lessonRepository;
        private readonly StudentRepository _studentRepository;
        private readonly TypeRepository _typeRepository;

        public LessonService(
            LessonRepository lessonRepository,
            StudentRepository studentRepository,
            TypeRepository typeRepository)
        {
            _lessonRepository = lessonRepository;
            _studentRepository = studentRepository;
            _typeRepository = typeRepository;
        }

        /// <summary>
        /// Получить все уроки
        /// </summary>
        public async Task<IEnumerable<LessonModel>> GetAllLessons()
        {
            return await _lessonRepository.GetAllAsync();
        }

        /// <summary>
        /// Получить урок по ID
        /// </summary>
        public async Task<LessonModel?> GetLessonById(int id)
        {
            return await _lessonRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Создать новый урок с проверкой времени
        /// </summary>
        public async Task<(bool success, string message, LessonModel? lesson)> CreateLesson(
            DateOnly date,
            TimeOnly time,
            int price,
            int studentId,
            int typeId,
            string? comment = null)
        {
            // Проверяем существование студента
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
                return (false, "Студент не найден", null);

            // Проверяем существование типа урока
            var type = await _typeRepository.GetByIdAsync(typeId);
            if (type == null)
                return (false, "Тип урока не найден", null);

            // Создаём урок
            var lesson = new LessonModel
            {
                Date = date,
                Time = time,
                Price = price,
                Comment = comment ?? string.Empty,
                Status = LessonStatus.Запланирован,
                StudentId = studentId,
                TypeId = typeId
            };

            // Проверяем свободное время
            var added = await _lessonRepository.TryAddWithTimeCheck(lesson);
            if (!added)
            {
                // Предложим ближайшее свободное время
                var nextSlot = await _lessonRepository.FindNextAvailableSlot(date, time);
                var nextSlotMessage = nextSlot.HasValue
                    ? $" Ближайшее свободное время: {nextSlot.Value}"
                    : " Свободных слотов нет на эту дату";

                return (false, $"Время {time} занято.{nextSlotMessage}", null);
            }

            await _lessonRepository.SaveAsync();
            return (true, "Урок успешно создан", lesson);
        }

        /// <summary>
        /// Обновить урок с проверкой времени
        /// </summary>
        public async Task<(bool success, string message)> UpdateLesson(
            int lessonId,
            DateOnly? date = null,
            TimeOnly? time = null,
            int? price = null,
            int? typeId = null,
            string? comment = null,
            LessonStatus? status = null)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);
            if (lesson == null)
                return (false, "Урок не найден");

            // Сохраняем старое время для проверки
            var oldTime = lesson.Time;
            var oldDate = lesson.Date;

            // Обновляем поля
            if (date.HasValue)
                lesson.Date = date.Value;
            if (time.HasValue)
                lesson.Time = time.Value;
            if (price.HasValue)
                lesson.Price = price.Value;
            if (typeId.HasValue)
                lesson.TypeId = typeId.Value;
            if (comment != null)
                lesson.Comment = comment;
            if (status.HasValue)
                lesson.Status = status.Value;

            // Если изменились дата или время, проверяем доступность
            if (date.HasValue || time.HasValue)
            {
                var updated = await _lessonRepository.TryUpdateWithTimeCheck(lesson);
                if (!updated)
                {
                    // Возвращаем старые значения
                    lesson.Date = oldDate;
                    lesson.Time = oldTime;

                    var nextSlot = await _lessonRepository.FindNextAvailableSlot(
                        date ?? oldDate,
                        time ?? oldTime);

                    var nextSlotMessage = nextSlot.HasValue
                        ? $" Ближайшее свободное время: {nextSlot.Value}"
                        : "";

                    return (false, $"Новое время {time ?? oldTime} занято.{nextSlotMessage}");
                }
            }
            else
            {
                await _lessonRepository.UpdateAsync(lesson);
            }

            await _lessonRepository.SaveAsync();
            return (true, "Урок обновлён");
        }

        /// <summary>
        /// Отменить урок
        /// </summary>
        public async Task<(bool success, string message)> CancelLesson(int lessonId)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);
            if (lesson == null)
                return (false, "Урок не найден");

            if (lesson.Status == LessonStatus.Отменён)
                return (false, "Урок уже отменён");

            lesson.Status = LessonStatus.Отменён;
            await _lessonRepository.UpdateAsync(lesson);
            await _lessonRepository.SaveAsync();

            return (true, "Урок отменён");
        }

        /// <summary>
        /// Провести урок (отметить как проведённый)
        /// </summary>
        public async Task<(bool success, string message)> CompleteLesson(int lessonId)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);
            if (lesson == null)
                return (false, "Урок не найден");

            if (lesson.Status == LessonStatus.Проведён)
                return (false, "Урок уже проведён");

            if (lesson.Status == LessonStatus.Отменён)
                return (false, "Нельзя провести отменённый урок");

            lesson.Status = LessonStatus.Проведён;
            await _lessonRepository.UpdateAsync(lesson);
            await _lessonRepository.SaveAsync();

            return (true, "Урок отмечен как проведённый");
        }

        /// <summary>
        /// Получить уроки на дату
        /// </summary>
        public async Task<IEnumerable<LessonModel>> GetLessonsByDate(DateOnly date)
        {
            return await _lessonRepository.GetByDate(date);
        }

        /// <summary>
        /// Получить уроки студента
        /// </summary>
        /*public async Task<IEnumerable<LessonModel>> GetStudentLessons(int studentId)
        {
            return await _lessonRepository.GetByStudent(studentId);
        }

        /// <summary>
        /// Получить предстоящие уроки
        /// </summary>
        public async Task<IEnumerable<LessonModel>> GetUpcomingLessons()
        {
            return await _lessonRepository.GetUpcoming();
        }*/

        /// <summary>
        /// Получить статистику уроков за период
        /// </summary>
        /*public async Task<object> GetLessonStatistics(DateOnly startDate, DateOnly endDate)
        {
            var lessons = await _lessonRepository.GetByDateRange(startDate, endDate);
            var lessonsList = lessons.ToList();

            return new
            {
                TotalLessons = lessonsList.Count,
                TotalIncome = lessonsList.Sum(l => l.Price),
                ScheduledCount = lessonsList.Count(l => l.Status == LessonStatus.Запланирован),
                CompletedCount = lessonsList.Count(l => l.Status == LessonStatus.Проведён),
                CancelledCount = lessonsList.Count(l => l.Status == LessonStatus.Отменён),
                AveragePrice = lessonsList.Any() ? lessonsList.Average(l => l.Price) : 0
            };
        }*/

        /// <summary>
        /// Получить свободные временные слоты
        /// </summary>
        public async Task<List<TimeOnly>> GetAvailableTimeSlots(DateOnly date)
        {
            return await _lessonRepository.GetAvailableTimeSlots(date);
        }
        public async Task<(bool success, string message)> DeleteLesson(int lessonId)
        {
            var lesson = await _lessonRepository.GetByIdAsync(lessonId);
            if (lesson == null)
                return (false, "Урок не найден");


            await _lessonRepository.DeleteAsync(lesson);
            await _lessonRepository.SaveAsync();

            return (true, "Урок удалён");
        }
    }
}
