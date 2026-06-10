using Models.Enums;
using Models.Models;
using Repositories.Implementations;
using Repositories;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
     public class LessonServiceTests
    {
        private readonly AppDbContext _context;
        private readonly LessonService _service;

        public LessonServiceTests()
        {
            _context = TestDbContextFactory.CreateInMemoryDbContext();

            var lessonRepo = new LessonRepository(_context);
            var studentRepo = new StudentRepository(_context);
            var typeRepo = new TypeRepository(_context);

            _service = new LessonService(lessonRepo, studentRepo, typeRepo);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        // ========== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ==========

        private async Task<int> CreateTestLevel()
        {
            var level = new LevelModel { LevelName = "Test Level" };
            await _context.Levels.AddAsync(level);
            await _context.SaveChangesAsync();
            return level.Id;
        }

        private async Task<int> CreateTestSubject()
        {
            var subject = new SubjectModel { SubjectName = "Test Subject" };
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();
            return subject.Id;
        }

        private async Task<(int studentId, int typeId)> AddTestData()
        {
            var levelId = await CreateTestLevel();
            var subjectId = await CreateTestSubject();

            var student = new StudentModel
            {
                FullName = "Тестовый студент",
                Age = 20,
                Phone = "123456789",
                LevelId = levelId
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            var type = new TypeModel
            {
                TypeName = "Тестовый тип",
                SubjectId = subjectId
            };
            await _context.Types.AddAsync(type);
            await _context.SaveChangesAsync();

            return (student.Id, type.Id);
        }

        // ========== ТЕСТЫ ДЛЯ CREATE LESSON ==========

        [Fact]
        public async Task CreateLesson_ShouldReturnError_WhenStudentNotFound()
        {
            // Act
            var (success, message, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0),
                1000,
                999, // несуществующий студент
                1);

            // Assert
            Assert.False(success);
            Assert.Equal("Студент не найден", message);
            Assert.Null(lesson);
        }

        [Fact]
        public async Task CreateLesson_ShouldReturnError_WhenTypeNotFound()
        {
            // Arrange
            var levelId = await CreateTestLevel();
            var student = new StudentModel
            {
                FullName = "Тестовый студент",
                Age = 20,
                Phone = "123456789",
                LevelId = levelId
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            // Act
            var (success, message, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0),
                1000,
                student.Id,
                999); // несуществующий тип

            // Assert
            Assert.False(success);
            Assert.Equal("Тип урока не найден", message);
            Assert.Null(lesson);
        }

        [Fact]
        public async Task CreateLesson_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();

            // Act
            var (success, message, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0),
                1000,
                studentId,
                typeId);

            // Assert
            Assert.True(success);
            Assert.Equal("Урок успешно создан", message);
            Assert.NotNull(lesson);
            Assert.Equal(LessonStatus.Запланирован, lesson.Status);
            Assert.Equal(1000, lesson.Price);
        }

        [Fact]
        public async Task CreateLesson_ShouldReturnError_WhenTimeSlotIsTaken()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var lessonDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
            var lessonTime = new TimeOnly(10, 0);

            // Создаём первый урок
            await _service.CreateLesson(lessonDate, lessonTime, 1000, studentId, typeId);

            // Act — пытаемся создать второй урок на то же время
            var (success, message, lesson) = await _service.CreateLesson(
                lessonDate, lessonTime, 1000, studentId, typeId);

            // Assert
            Assert.False(success);
            Assert.Contains("занято", message);
            Assert.Null(lesson);
        }

        [Fact]
        public async Task GetAllLessons_ShouldReturnAllLessons()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var lessonDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

            await _service.CreateLesson(lessonDate, new TimeOnly(10, 0), 1000, studentId, typeId);
            await _service.CreateLesson(lessonDate, new TimeOnly(11, 0), 1500, studentId, typeId);

            // Act
            var lessons = await _service.GetAllLessons();

            // Assert
            Assert.Equal(2, lessons.Count());
        }

        // ========== ТЕСТЫ ДЛЯ UPDATE LESSON ==========

        [Fact]
        public async Task UpdateLesson_ShouldReturnError_WhenLessonNotFound()
        {
            // Act
            var (success, message) = await _service.UpdateLesson(999, price: 2000);

            // Assert
            Assert.False(success);
            Assert.Equal("Урок не найден", message);
        }

        [Fact]
        public async Task UpdateLesson_ShouldUpdatePrice_WhenValid()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var (_, _, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0), 1000, studentId, typeId);

            // Act
            var (success, message) = await _service.UpdateLesson(lesson.Id, price: 2000);

            // Assert
            Assert.True(success);
            Assert.Equal("Урок обновлён", message);

            var updated = await _service.GetLessonById(lesson.Id);
            Assert.Equal(2000, updated.Price);
        }

        [Fact]
        public async Task UpdateLesson_ShouldUpdateComment_WhenValid()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var (_, _, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0), 1000, studentId, typeId);

            // Act
            var (success, message) = await _service.UpdateLesson(lesson.Id, comment: "Новый комментарий");

            // Assert
            Assert.True(success);
            var updated = await _service.GetLessonById(lesson.Id);
            Assert.Equal("Новый комментарий", updated.Comment);
        }

        [Fact]
        public async Task UpdateLesson_ShouldReturnError_WhenNewTimeSlotIsTaken()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var lessonDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1));

            // Создаём два урока в разное время
            var (_, _, lesson1) = await _service.CreateLesson(
                lessonDate, new TimeOnly(10, 0), 1000, studentId, typeId);
            var (_, _, lesson2) = await _service.CreateLesson(
                lessonDate, new TimeOnly(11, 0), 1000, studentId, typeId);

            // Act — пытаемся переместить lesson2 на время lesson1
            var (success, message) = await _service.UpdateLesson(lesson2.Id, time: new TimeOnly(10, 0));

            // Assert
            Assert.False(success);
            Assert.Contains("занято", message);
        }

        // ========== ТЕСТЫ ДЛЯ CANCEL LESSON ==========

        [Fact]
        public async Task CancelLesson_ShouldReturnError_WhenLessonNotFound()
        {
            // Act
            var (success, message) = await _service.CancelLesson(999);

            // Assert
            Assert.False(success);
            Assert.Equal("Урок не найден", message);
        }

        [Fact]
        public async Task CancelLesson_ShouldReturnError_WhenLessonAlreadyCancelled()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var (_, _, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0), 1000, studentId, typeId);
            await _service.CancelLesson(lesson.Id);

            // Act
            var (success, message) = await _service.CancelLesson(lesson.Id);

            // Assert
            Assert.False(success);
            Assert.Equal("Урок уже отменён", message);
        }

        [Fact]
        public async Task CancelLesson_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var (_, _, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0), 1000, studentId, typeId);

            // Act
            var (success, message) = await _service.CancelLesson(lesson.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Урок отменён", message);

            var updated = await _service.GetLessonById(lesson.Id);
            Assert.Equal(LessonStatus.Отменён, updated.Status);
        }

        // ========== ТЕСТЫ ДЛЯ COMPLETE LESSON ==========

        [Fact]
        public async Task CompleteLesson_ShouldReturnError_WhenLessonNotFound()
        {
            // Act
            var (success, message) = await _service.CompleteLesson(999);

            // Assert
            Assert.False(success);
            Assert.Equal("Урок не найден", message);
        }

        [Fact]
        public async Task CompleteLesson_ShouldReturnError_WhenLessonAlreadyCompleted()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var (_, _, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0), 1000, studentId, typeId);
            await _service.CompleteLesson(lesson.Id);

            // Act
            var (success, message) = await _service.CompleteLesson(lesson.Id);

            // Assert
            Assert.False(success);
            Assert.Equal("Урок уже проведён", message);
        }

        [Fact]
        public async Task CompleteLesson_ShouldReturnError_WhenLessonIsCancelled()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var (_, _, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0), 1000, studentId, typeId);
            await _service.CancelLesson(lesson.Id);

            // Act
            var (success, message) = await _service.CompleteLesson(lesson.Id);

            // Assert
            Assert.False(success);
            Assert.Equal("Нельзя провести отменённый урок", message);
        }

        [Fact]
        public async Task CompleteLesson_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var (_, _, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0), 1000, studentId, typeId);

            // Act
            var (success, message) = await _service.CompleteLesson(lesson.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Урок отмечен как проведённый", message);

            var updated = await _service.GetLessonById(lesson.Id);
            Assert.Equal(LessonStatus.Проведён, updated.Status);
        }

        // ========== ТЕСТЫ ДЛЯ DELETE LESSON ==========

        [Fact]
        public async Task DeleteLesson_ShouldReturnError_WhenLessonNotFound()
        {
            // Act
            var (success, message) = await _service.DeleteLesson(999);

            // Assert
            Assert.False(success);
            Assert.Equal("Урок не найден", message);
        }

        [Fact]
        public async Task DeleteLesson_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (studentId, typeId) = await AddTestData();
            var (_, _, lesson) = await _service.CreateLesson(
                DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                new TimeOnly(10, 0), 1000, studentId, typeId);
            Assert.Single(await _service.GetAllLessons());

            // Act
            var (success, message) = await _service.DeleteLesson(lesson.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Урок удалён", message);
            Assert.Empty(await _service.GetAllLessons());
        }
    }
}
