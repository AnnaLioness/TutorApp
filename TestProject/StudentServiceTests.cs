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
    public class StudentServiceTests
    {
        private readonly AppDbContext _context;
        private readonly StudentService _service;

        public StudentServiceTests()
        {
            _context = TestDbContextFactory.CreateInMemoryDbContext();

            var studentRepo = new StudentRepository(_context);
            var levelRepo = new LevelRepository(_context);

            _service = new StudentService(studentRepo, levelRepo);
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

        // ========== ТЕСТЫ ДЛЯ CREATE STUDENT ==========

        [Fact]
        public async Task CreateStudent_ShouldReturnError_WhenAgeIsLessThan3()
        {
            // Arrange
            var levelId = await CreateTestLevel();

            // Act
            var (success, message, student) = await _service.CreateStudent(
                "Test Student", 2, "123456789", levelId);

            // Assert
            Assert.False(success);
            Assert.Equal("Некорректный возраст", message);
            Assert.Null(student);
        }

        [Fact]
        public async Task CreateStudent_ShouldReturnError_WhenAgeIsGreaterThan100()
        {
            // Arrange
            var levelId = await CreateTestLevel();

            // Act
            var (success, message, student) = await _service.CreateStudent(
                "Test Student", 101, "123456789", levelId);

            // Assert
            Assert.False(success);
            Assert.Equal("Некорректный возраст", message);
            Assert.Null(student);
        }

        [Fact]
        public async Task CreateStudent_ShouldReturnError_WhenPhoneIsEmpty()
        {
            // Arrange
            var levelId = await CreateTestLevel();

            // Act
            var (success, message, student) = await _service.CreateStudent(
                "Test Student", 20, "", levelId);

            // Assert
            Assert.False(success);
            Assert.Equal("Телефон обязателен", message);
            Assert.Null(student);
        }

        [Fact]
        public async Task CreateStudent_ShouldReturnError_WhenPhoneIsWhitespace()
        {
            // Arrange
            var levelId = await CreateTestLevel();

            // Act
            var (success, message, student) = await _service.CreateStudent(
                "Test Student", 20, "   ", levelId);

            // Assert
            Assert.False(success);
            Assert.Equal("Телефон обязателен", message);
            Assert.Null(student);
        }

        [Fact]
        public async Task CreateStudent_ShouldReturnError_WhenLevelNotFound()
        {
            // Act
            var (success, message, student) = await _service.CreateStudent(
                "Test Student", 20, "123456789", 999);

            // Assert
            Assert.False(success);
            Assert.Equal("Уровень не найден", message);
            Assert.Null(student);
        }

        [Fact]
        public async Task CreateStudent_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var levelId = await CreateTestLevel();

            // Act
            var (success, message, student) = await _service.CreateStudent(
                "Иванов Иван", 25, "+79991234567", levelId);

            // Assert
            Assert.True(success);
            Assert.Equal("Студент успешно добавлен", message);
            Assert.NotNull(student);
            Assert.Equal("Иванов Иван", student.FullName);
            Assert.Equal(25, student.Age);
            Assert.Equal("+79991234567", student.Phone);
            Assert.Equal(levelId, student.LevelId);
        }

        [Fact]
        public async Task GetAllStudents_ShouldReturnAllStudents()
        {
            // Arrange
            var levelId = await CreateTestLevel();
            await _service.CreateStudent("Student1", 20, "111", levelId);
            await _service.CreateStudent("Student2", 25, "222", levelId);

            // Act
            var students = await _service.GetAllStudents();

            // Assert
            Assert.Equal(2, students.Count());
        }

        // ========== ТЕСТЫ ДЛЯ UPDATE STUDENT ==========

        [Fact]
        public async Task UpdateStudent_ShouldReturnError_WhenStudentNotFound()
        {
            // Act
            var (success, message) = await _service.UpdateStudent(999, fullName: "New Name");

            // Assert
            Assert.False(success);
            Assert.Equal("Студент не найден", message);
        }

        [Fact]
        public async Task UpdateStudent_ShouldUpdateFullName_WhenValid()
        {
            // Arrange
            var levelId = await CreateTestLevel();
            var (_, _, student) = await _service.CreateStudent(
                "Old Name", 25, "123456789", levelId);

            // Act
            var (success, message) = await _service.UpdateStudent(student.Id, fullName: "New Name");

            // Assert
            Assert.True(success);
            Assert.Equal("Данные студента обновлены", message);

            var updated = await _service.GetStudentById(student.Id);
            Assert.Equal("New Name", updated.FullName);
        }

        [Fact]
        public async Task UpdateStudent_ShouldUpdateAge_WhenValid()
        {
            // Arrange
            var levelId = await CreateTestLevel();
            var (_, _, student) = await _service.CreateStudent(
                "Test Student", 25, "123456789", levelId);

            // Act
            var (success, message) = await _service.UpdateStudent(student.Id, age: 30);

            // Assert
            Assert.True(success);

            var updated = await _service.GetStudentById(student.Id);
            Assert.Equal(30, updated.Age);
        }

        [Fact]
        public async Task UpdateStudent_ShouldReturnError_WhenAgeIsInvalid()
        {
            // Arrange
            var levelId = await CreateTestLevel();
            var (_, _, student) = await _service.CreateStudent(
                "Test Student", 25, "123456789", levelId);

            // Act
            var (success, message) = await _service.UpdateStudent(student.Id, age: 0);

            // Assert
            Assert.False(success);
            Assert.Equal("Некорректный возраст", message);
        }

        [Fact]
        public async Task UpdateStudent_ShouldUpdatePhone_WhenValid()
        {
            // Arrange
            var levelId = await CreateTestLevel();
            var (_, _, student) = await _service.CreateStudent(
                "Test Student", 25, "123456789", levelId);

            // Act
            var (success, message) = await _service.UpdateStudent(student.Id, phone: "+79998887766");

            // Assert
            Assert.True(success);

            var updated = await _service.GetStudentById(student.Id);
            Assert.Equal("+79998887766", updated.Phone);
        }

        [Fact]
        public async Task UpdateStudent_ShouldUpdateLevel_WhenValid()
        {
            // Arrange
            var levelId1 = await CreateTestLevel();
            var levelId2 = await CreateTestLevel();
            var (_, _, student) = await _service.CreateStudent(
                "Test Student", 25, "123456789", levelId1);

            // Act
            var (success, message) = await _service.UpdateStudent(student.Id, levelId: levelId2);

            // Assert
            Assert.True(success);

            var updated = await _service.GetStudentById(student.Id);
            Assert.Equal(levelId2, updated.LevelId);
        }

        [Fact]
        public async Task UpdateStudent_ShouldReturnError_WhenLevelNotFound()
        {
            // Arrange
            var levelId = await CreateTestLevel();
            var (_, _, student) = await _service.CreateStudent(
                "Test Student", 25, "123456789", levelId);

            // Act
            var (success, message) = await _service.UpdateStudent(student.Id, levelId: 999);

            // Assert
            Assert.False(success);
            Assert.Equal("Уровень не найден", message);
        }

        [Fact]
        public async Task UpdateStudent_ShouldUpdateMultipleFields_WhenValid()
        {
            // Arrange
            var levelId1 = await CreateTestLevel();
            var levelId2 = await CreateTestLevel();
            var (_, _, student) = await _service.CreateStudent(
                "Old Name", 25, "111", levelId1);

            // Act
            var (success, message) = await _service.UpdateStudent(
                student.Id,
                fullName: "New Name",
                age: 30,
                phone: "222",
                levelId: levelId2);

            // Assert
            Assert.True(success);

            var updated = await _service.GetStudentById(student.Id);
            Assert.Equal("New Name", updated.FullName);
            Assert.Equal(30, updated.Age);
            Assert.Equal("222", updated.Phone);
            Assert.Equal(levelId2, updated.LevelId);
        }

        // ========== ТЕСТЫ ДЛЯ DELETE STUDENT ==========

        [Fact]
        public async Task DeleteStudent_ShouldReturnError_WhenStudentNotFound()
        {
            // Act
            var (success, message) = await _service.DeleteStudent(999);

            // Assert
            Assert.False(success);
            Assert.Equal("Студент не найден", message);
        }

        [Fact]
        public async Task DeleteStudent_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var levelId = await CreateTestLevel();
            var (_, _, student) = await _service.CreateStudent(
                "Test Student", 25, "123456789", levelId);
            Assert.Single(await _service.GetAllStudents());

            // Act
            var (success, message) = await _service.DeleteStudent(student.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Студент удалён", message);
            Assert.Empty(await _service.GetAllStudents());
        }
    }
}
