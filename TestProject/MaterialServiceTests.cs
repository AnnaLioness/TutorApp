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
    public class MaterialServiceTests
    {
        private readonly AppDbContext _context;
        private readonly MaterialService _service;

        public MaterialServiceTests()
        {
            _context = TestDbContextFactory.CreateInMemoryDbContext();

            var materialRepo = new MaterialRepository(_context);
            var typeRepo = new TypeRepository(_context);
            var levelRepo = new LevelRepository(_context);
            var publicationRepo = new PublicationRepository(_context);

            _service = new MaterialService(materialRepo, typeRepo, levelRepo, publicationRepo);
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

        private async Task<int> CreateTestType()
        {
            var subject = new SubjectModel { SubjectName = "Test Subject" };
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            var type = new TypeModel { TypeName = "Test Type", SubjectId = subject.Id };
            await _context.Types.AddAsync(type);
            await _context.SaveChangesAsync();
            return type.Id;
        }

        private async Task<(int typeId, int levelId)> AddTestData()
        {
            var levelId = await CreateTestLevel();
            var typeId = await CreateTestType();
            return (typeId, levelId);
        }

        // ========== ТЕСТЫ ДЛЯ CREATE MATERIAL ==========

        [Fact]
        public async Task CreateMaterial_ShouldReturnError_WhenTitleIsEmpty()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();

            // Act
            var (success, message, material) = await _service.CreateMaterial(
                "", "Description", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Название обязательно", message);
            Assert.Null(material);
        }

        [Fact]
        public async Task CreateMaterial_ShouldReturnError_WhenTitleIsWhitespace()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();

            // Act
            var (success, message, material) = await _service.CreateMaterial(
                "   ", "Description", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Название обязательно", message);
            Assert.Null(material);
        }

        [Fact]
        public async Task CreateMaterial_ShouldReturnError_WhenTypeNotFound()
        {
            // Arrange
            var levelId = await CreateTestLevel();

            // Act
            var (success, message, material) = await _service.CreateMaterial(
                "Title", "Description", "file.docx", 999, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Тип материала не найден", message);
            Assert.Null(material);
        }

        [Fact]
        public async Task CreateMaterial_ShouldReturnError_WhenLevelNotFound()
        {
            // Arrange
            var typeId = await CreateTestType();

            // Act
            var (success, message, material) = await _service.CreateMaterial(
                "Title", "Description", "file.docx", typeId, 999,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Уровень не найден", message);
            Assert.Null(material);
        }

        [Fact]
        public async Task CreateMaterial_ShouldReturnError_WhenHolidayWithoutType()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();

            // Act
            var (success, message, material) = await _service.CreateMaterial(
                "Title", "Description", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, true, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Для праздничного материала необходимо указать тип праздника", message);
            Assert.Null(material);
        }

        [Fact]
        public async Task CreateMaterial_ShouldReturnSuccess_WhenValidNonHoliday()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();

            // Act
            var (success, message, material) = await _service.CreateMaterial(
                "Test Material", "Description", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.True(success);
            Assert.Equal("Материал создан", message);
            Assert.NotNull(material);
            Assert.Equal("Test Material", material.Title);
            Assert.Equal(AgeGroup.A, material.AgeGroup);
            Assert.Equal(Season.Весна, material.Season);
            Assert.False(material.IsHoliday);
            Assert.Null(material.Holiday);
        }

        [Fact]
        public async Task CreateMaterial_ShouldReturnSuccess_WhenValidHoliday()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();

            // Act
            var (success, message, material) = await _service.CreateMaterial(
                "Christmas Material", "Description", "file.docx", typeId, levelId,
                AgeGroup.B, Season.Зима, true, Holiday.Christmas);

            // Assert
            Assert.True(success);
            Assert.Equal("Материал создан", message);
            Assert.NotNull(material);
            Assert.True(material.IsHoliday);
            Assert.Equal(Holiday.Christmas, material.Holiday);
        }

        [Fact]
        public async Task GetAllMaterials_ShouldReturnAllMaterials()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();
            await _service.CreateMaterial("Material1", "Desc1", "file1.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);
            await _service.CreateMaterial("Material2", "Desc2", "file2.docx", typeId, levelId,
                AgeGroup.B, Season.Лето, false, null);

            // Act
            var materials = await _service.GetAllMaterials();

            // Assert
            Assert.Equal(2, materials.Count());
        }

        // ========== ТЕСТЫ ДЛЯ UPDATE MATERIAL ==========

        [Fact]
        public async Task UpdateMaterial_ShouldReturnError_WhenMaterialNotFound()
        {
            // Act
            var (success, message) = await _service.UpdateMaterial(
                999, "Title", "Desc", "file.docx", 1, 1,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Материал не найден", message);
        }

        [Fact]
        public async Task UpdateMaterial_ShouldReturnError_WhenTitleIsEmpty()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();
            var (_, _, material) = await _service.CreateMaterial(
                "Original Title", "Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Act
            var (success, message) = await _service.UpdateMaterial(
                material.Id, "", "Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Название обязательно", message);
        }

        [Fact]
        public async Task UpdateMaterial_ShouldReturnError_WhenTypeNotFound()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();
            var (_, _, material) = await _service.CreateMaterial(
                "Original Title", "Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Act
            var (success, message) = await _service.UpdateMaterial(
                material.Id, "Updated Title", "Desc", "file.docx", 999, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Тип материала не найден", message);
        }

        [Fact]
        public async Task UpdateMaterial_ShouldReturnError_WhenLevelNotFound()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();
            var (_, _, material) = await _service.CreateMaterial(
                "Original Title", "Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Act
            var (success, message) = await _service.UpdateMaterial(
                material.Id, "Updated Title", "Desc", "file.docx", typeId, 999,
                AgeGroup.A, Season.Весна, false, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Уровень не найден", message);
        }

        [Fact]
        public async Task UpdateMaterial_ShouldReturnError_WhenHolidayWithoutType()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();
            var (_, _, material) = await _service.CreateMaterial(
                "Original Title", "Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Act
            var (success, message) = await _service.UpdateMaterial(
                material.Id, "Updated Title", "Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, true, null);

            // Assert
            Assert.False(success);
            Assert.Equal("Для праздничного материала необходимо указать тип праздника", message);
        }

        [Fact]
        public async Task UpdateMaterial_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();
            var (_, _, material) = await _service.CreateMaterial(
                "Original Title", "Original Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Act
            var (success, message) = await _service.UpdateMaterial(
                material.Id, "Updated Title", "Updated Desc", "newfile.docx", typeId, levelId,
                AgeGroup.B, Season.Лето, true, Holiday.NewYear);

            // Assert
            Assert.True(success);
            Assert.Equal("Материал обновлён", message);

            var updated = await _service.GetMaterialById(material.Id);
            Assert.Equal("Updated Title", updated.Title);
            Assert.Equal("Updated Desc", updated.Description);
            Assert.Equal(AgeGroup.B, updated.AgeGroup);
            Assert.Equal(Season.Лето, updated.Season);
            Assert.True(updated.IsHoliday);
            Assert.Equal(Holiday.NewYear, updated.Holiday);
        }

        // ========== ТЕСТЫ ДЛЯ DELETE MATERIAL ==========

        [Fact]
        public async Task DeleteMaterial_ShouldReturnError_WhenMaterialNotFound()
        {
            // Act
            var (success, message) = await _service.DeleteMaterial(999);

            // Assert
            Assert.False(success);
            Assert.Equal("Материал не найден", message);
        }

        [Fact]
        public async Task DeleteMaterial_ShouldReturnError_WhenMaterialHasPublications()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();
            var (_, _, material) = await _service.CreateMaterial(
                "Test Material", "Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);

            // Создаём публикацию для этого материала
            var publication = new PublicationModel
            {
                MaterialId = material.Id,
                PublicationDate = DateTime.Now.AddDays(1),
                IsPublicted = false
            };
            await _context.Publications.AddAsync(publication);
            await _context.SaveChangesAsync();

            // Act
            var (success, message) = await _service.DeleteMaterial(material.Id);

            // Assert
            Assert.False(success);
            Assert.Equal("Нельзя удалить материал с публикациями", message);
            Assert.NotNull(await _service.GetMaterialById(material.Id));
        }

        [Fact]
        public async Task DeleteMaterial_ShouldReturnSuccess_WhenValid()
        {
            // Arrange
            var (typeId, levelId) = await AddTestData();
            var (_, _, material) = await _service.CreateMaterial(
                "Test Material", "Desc", "file.docx", typeId, levelId,
                AgeGroup.A, Season.Весна, false, null);
            Assert.Single(await _service.GetAllMaterials());

            // Act
            var (success, message) = await _service.DeleteMaterial(material.Id);

            // Assert
            Assert.True(success);
            Assert.Equal("Материал удалён", message);
            Assert.Empty(await _service.GetAllMaterials());
        }
    }
}
