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
    public class PublicationServiceTests
    {
        private readonly AppDbContext _context;
        private readonly PublicationService _service;

        public PublicationServiceTests()
        {
            _context = TestDbContextFactory.CreateInMemoryDbContext();

            var publicationRepo = new PublicationRepository(_context);
            var materialRepo = new MaterialRepository(_context);

            _service = new PublicationService(publicationRepo, materialRepo);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        // ========== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ==========

        private async Task<int> CreateTestMaterial()
        {
            // Создаём уровень
            var level = new LevelModel { LevelName = "Test Level" };
            await _context.Levels.AddAsync(level);
            await _context.SaveChangesAsync();

            // Создаём тип
            var subject = new SubjectModel { SubjectName = "Test Subject" };
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            var type = new TypeModel { TypeName = "Test Type", SubjectId = subject.Id };
            await _context.Types.AddAsync(type);
            await _context.SaveChangesAsync();

            // Создаём материал
            var material = new MaterialModel
            {
                Title = "Test Material",
                Description = "Test Description",
                FilePath = "test.docx",
                TypeId = type.Id,
                LevelId = level.Id,
                AgeGroup = Models.Enums.AgeGroup.A,
                Season = Models.Enums.Season.Весна,
                IsHoliday = false,
                Holiday = null
            };
            await _context.Materials.AddAsync(material);
            await _context.SaveChangesAsync();

            return material.Id;
        }

        // ========== ТЕСТЫ ==========

        [Fact]
        public async Task AddPublication_ShouldAddAndReturnPublication()
        {
            // Arrange
            var materialId = await CreateTestMaterial();
            var publication = new PublicationModel
            {
                MaterialId = materialId,
                PublicationDate = DateTime.Now.AddDays(1),
                IsPublicted = false
            };

            // Act
            var result = await _service.AddPublication(publication);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(materialId, result.MaterialId);
            Assert.False(result.IsPublicted);
        }

        [Fact]
        public async Task GetAllPublications_ShouldReturnAllPublications()
        {
            // Arrange
            var materialId = await CreateTestMaterial();

            var pub1 = new PublicationModel { MaterialId = materialId, PublicationDate = DateTime.Now.AddDays(1), IsPublicted = false };
            var pub2 = new PublicationModel { MaterialId = materialId, PublicationDate = DateTime.Now.AddDays(2), IsPublicted = false };

            await _service.AddPublication(pub1);
            await _service.AddPublication(pub2);

            // Act
            var publications = await _service.GetAllPublications();

            // Assert
            Assert.Equal(2, publications.Count());
        }

        [Fact]
        public async Task UpdatePublication_ShouldUpdateStatus()
        {
            // Arrange
            var materialId = await CreateTestMaterial();
            var publication = new PublicationModel
            {
                MaterialId = materialId,
                PublicationDate = DateTime.Now.AddDays(1),
                IsPublicted = false
            };
            var added = await _service.AddPublication(publication);

            // Act
            added.IsPublicted = true;
            await _service.UpdatePublication(added);

            // Assert
            var updated = (await _service.GetAllPublications()).First();
            Assert.True(updated.IsPublicted);
        }
    }
}
