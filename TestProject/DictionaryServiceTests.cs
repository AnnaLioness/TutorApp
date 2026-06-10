using Models.Models;
using Moq;
using Repositories;
using Repositories.Implementations;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class DictionaryServiceTests
    {
        private readonly AppDbContext _context;
        private readonly DictionaryService _service;

        public DictionaryServiceTests()
        {
            _context = TestDbContextFactory.CreateInMemoryDbContext();

            var levelRepo = new LevelRepository(_context);
            var subjectRepo = new SubjectRepository(_context);
            var typeRepo = new TypeRepository(_context);

            _service = new DictionaryService(levelRepo, subjectRepo, typeRepo);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        // ========== ТЕСТЫ ДЛЯ УРОВНЕЙ ==========

        [Fact]
        public async Task CreateLevel_ShouldReturnError_WhenNameIsEmpty()
        {
            // Act
            var (success, message, level) = await _service.CreateLevel("");

            // Assert
            Assert.False(success);
            Assert.Equal("Название уровня обязательно", message);
            Assert.Null(level);
        }

        [Fact]
        public async Task CreateLevel_ShouldReturnError_WhenNameIsWhitespace()
        {
            // Act
            var (success, message, level) = await _service.CreateLevel("   ");

            // Assert
            Assert.False(success);
            Assert.Equal("Название уровня обязательно", message);
            Assert.Null(level);
        }

        [Fact]
        public async Task CreateLevel_ShouldReturnError_WhenLevelAlreadyExists()
        {
            // Arrange
            await _service.CreateLevel("Beginner");

            // Act
            var (success, message, level) = await _service.CreateLevel("Beginner");

            // Assert
            Assert.False(success);
            Assert.Equal("Уровень с таким названием уже существует", message);
            Assert.Null(level);
        }

        [Fact]
        public async Task CreateLevel_ShouldReturnSuccess_WhenValid()
        {
            // Act
            var (success, message, level) = await _service.CreateLevel("Advanced");

            // Assert
            Assert.True(success);
            Assert.Equal("Уровень создан", message);
            Assert.NotNull(level);
            Assert.Equal("Advanced", level.LevelName);
        }

        [Fact]
        public async Task GetAllLevels_ShouldReturnAllLevels()
        {
            // Arrange
            await _service.CreateLevel("Level1");
            await _service.CreateLevel("Level2");

            // Act
            var levels = await _service.GetAllLevels();

            // Assert
            Assert.Equal(2, levels.Count());
        }

        [Fact]
        public async Task UpdateLevel_ShouldReturnError_WhenNameIsEmpty()
        {
            // Arrange
            var (_, _, level) = await _service.CreateLevel("OldName");

            // Act
            var (success, message) = await _service.UpdateLevel(level.Id, "");

            // Assert
            Assert.False(success);
            Assert.Equal("Название уровня обязательно", message);
        }

        [Fact]
        public async Task UpdateLevel_ShouldReturnError_WhenLevelNotFound()
        {
            // Act
            var (success, message) = await _service.UpdateLevel(999, "NewName");

            // Assert
            Assert.False(success);
            Assert.Equal("Уровень не найден", message);
        }

        [Fact]
        public async Task UpdateLevel_ShouldReturnError_WhenNameAlreadyExists()
        {
            // Arrange
            await _service.CreateLevel("Existing");
            var (_, _, level) = await _service.CreateLevel("Old");

            // Act
            var (success, message) = await _service.UpdateLevel(level.Id, "Existing");

            // Assert
            Assert.False(success);
            Assert.Equal("Уровень с таким названием уже существует", message);
        }

        [Fact]
        public async Task UpdateLevel_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (_, _, level) = await _service.CreateLevel("Old");

            // Act
            var (success, message) = await _service.UpdateLevel(level.Id, "New");

            // Assert
            Assert.True(success);
            Assert.Equal("Уровень успешно обновлен", message);

            // Проверяем, что данные действительно обновились
            var updated = (await _service.GetAllLevels()).First();
            Assert.Equal("New", updated.LevelName);
        }

        [Fact]
        public async Task DeleteLevel_ShouldReturnError_WhenLevelNotFound()
        {
            // Act
            var (success, message) = await _service.DeleteLevel(999);

            // Assert
            Assert.False(success);
            Assert.Equal("Уровень не найден", message);
        }

        [Fact]
        public async Task DeleteLevel_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (_, _, level) = await _service.CreateLevel("ToDelete");
            Assert.Single(await _service.GetAllLevels());

            // Act
            var (success, message) = await _service.DeleteLevel(level.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Уровень успешно удален", message);
            Assert.Empty(await _service.GetAllLevels());
        }

        // ========== ТЕСТЫ ДЛЯ ПРЕДМЕТОВ ==========

        [Fact]
        public async Task CreateSubject_ShouldReturnError_WhenNameIsEmpty()
        {
            // Act
            var (success, message, subject) = await _service.CreateSubject("");

            // Assert
            Assert.False(success);
            Assert.Equal("Название предмета обязательно", message);
            Assert.Null(subject);
        }

        [Fact]
        public async Task CreateSubject_ShouldReturnError_WhenSubjectAlreadyExists()
        {
            // Arrange
            await _service.CreateSubject("Math");

            // Act
            var (success, message, subject) = await _service.CreateSubject("Math");

            // Assert
            Assert.False(success);
            Assert.Equal("Предмет с таким названием уже существует", message);
            Assert.Null(subject);
        }

        [Fact]
        public async Task CreateSubject_ShouldReturnSuccess_WhenValid()
        {
            // Act
            var (success, message, subject) = await _service.CreateSubject("Physics");

            // Assert
            Assert.True(success);
            Assert.Equal("Предмет создан", message);
            Assert.NotNull(subject);
            Assert.Equal("Physics", subject.SubjectName);
        }

        [Fact]
        public async Task GetAllSubjects_ShouldReturnAllSubjects()
        {
            // Arrange
            await _service.CreateSubject("Math");
            await _service.CreateSubject("Physics");

            // Act
            var subjects = await _service.GetAllSubjects();

            // Assert
            Assert.Equal(2, subjects.Count());
        }

        [Fact]
        public async Task UpdateSubject_ShouldReturnError_WhenSubjectNotFound()
        {
            // Act
            var (success, message) = await _service.UpdateSubject(999, "NewName");

            // Assert
            Assert.False(success);
            Assert.Equal("Предмет не найден", message);
        }

        [Fact]
        public async Task UpdateSubject_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (_, _, subject) = await _service.CreateSubject("Old");

            // Act
            var (success, message) = await _service.UpdateSubject(subject.Id, "New");

            // Assert
            Assert.True(success);
            Assert.Equal("Предмет успешно обновлен", message);
        }

        [Fact]
        public async Task DeleteSubject_ShouldReturnError_WhenSubjectNotFound()
        {
            // Act
            var (success, message) = await _service.DeleteSubject(999);

            // Assert
            Assert.False(success);
            Assert.Equal("Предмет не найден", message);
        }

        [Fact]
        public async Task DeleteSubject_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (_, _, subject) = await _service.CreateSubject("ToDelete");

            // Act
            var (success, message) = await _service.DeleteSubject(subject.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Предмет успешно удален", message);
        }

        // ========== ТЕСТЫ ДЛЯ ТИПОВ ЗАНЯТИЙ ==========

        [Fact]
        public async Task CreateType_ShouldReturnError_WhenNameIsEmpty()
        {
            // Arrange
            var (_, _, subject) = await _service.CreateSubject("English");

            // Act
            var (success, message, type) = await _service.CreateType("", subject.Id);

            // Assert
            Assert.False(success);
            Assert.Equal("Название типа обязательно", message);
            Assert.Null(type);
        }

        [Fact]
        public async Task CreateType_ShouldReturnError_WhenSubjectNotFound()
        {
            // Act
            var (success, message, type) = await _service.CreateType("Grammar", 999);

            // Assert
            Assert.False(success);
            Assert.Equal("Предмет не найден", message);
            Assert.Null(type);
        }

        [Fact]
        public async Task CreateType_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (_, _, subject) = await _service.CreateSubject("English");

            // Act
            var (success, message, type) = await _service.CreateType("Grammar", subject.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Тип занятия создан", message);
            Assert.NotNull(type);
            Assert.Equal("Grammar", type.TypeName);
            Assert.Equal(subject.Id, type.SubjectId);
        }

        [Fact]
        public async Task GetTypesBySubject_ShouldReturnOnlyTypesForThatSubject()
        {
            // Arrange
            var (_, _, subject1) = await _service.CreateSubject("English");
            var (_, _, subject2) = await _service.CreateSubject("Math");

            await _service.CreateType("Grammar", subject1.Id);
            await _service.CreateType("Vocabulary", subject1.Id);
            await _service.CreateType("Algebra", subject2.Id);

            // Act
            var typesForEnglish = await _service.GetTypesBySubject(subject1.Id);

            // Assert
            Assert.Equal(2, typesForEnglish.Count());
            Assert.All(typesForEnglish, t => Assert.Equal(subject1.Id, t.SubjectId));
        }
    }
}
