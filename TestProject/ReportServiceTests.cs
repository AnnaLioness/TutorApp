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
    public class ReportServiceTests
    {
        private readonly AppDbContext _context;
        private readonly ReportService _service;

        public ReportServiceTests()
        {
            _context = TestDbContextFactory.CreateInMemoryDbContext();

            var lessonRepo = new LessonRepository(_context);
            var studentRepo = new StudentRepository(_context);
            var typeRepo = new TypeRepository(_context);

            _service = new ReportService(lessonRepo, studentRepo, typeRepo);
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

        private async Task<(int studentId, int typeId)> AddTestStudentAndType()
        {
            var levelId = await CreateTestLevel();
            var subjectId = await CreateTestSubject();

            var student = new StudentModel
            {
                FullName = "Test Student",
                Age = 20,
                Phone = "123456789",
                LevelId = levelId
            };
            await _context.Students.AddAsync(student);

            var type = new TypeModel
            {
                TypeName = "Test Type",
                SubjectId = subjectId
            };
            await _context.Types.AddAsync(type);
            await _context.SaveChangesAsync();

            return (student.Id, type.Id);
        }

        private async Task AddTestLesson(DateOnly date, int price, int studentId, int typeId, LessonStatus status = LessonStatus.Проведён)
        {
            var lesson = new LessonModel
            {
                Date = date,
                Time = new TimeOnly(10, 0),
                Price = price,
                Status = status,
                StudentId = studentId,
                TypeId = typeId
            };
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }

        // ========== ТЕСТЫ ==========

        [Fact]
        public async Task GetProfitReport_ShouldReturnZero_WhenNoLessons()
        {
            var reportDate = new DateTime(2026, 5, 15);
            var report = await _service.GetProfitReport(ReportPeriodType.Month, reportDate);

            Assert.Equal(0, report.CurrentPeriodProfit);
            Assert.Equal(0, report.CurrentPeriodLessonsCount);
            Assert.Equal(0, report.ActiveStudents);
            Assert.Equal(0, report.AverageLessonPrice);
        }

        [Fact]
        public async Task GetProfitReport_ShouldCalculateCurrentPeriodProfit_ForMonth()
        {
            var (studentId, typeId) = await AddTestStudentAndType();
            var reportDate = new DateTime(2026, 5, 15);

            await AddTestLesson(new DateOnly(2026, 5, 10), 1000, studentId, typeId);
            await AddTestLesson(new DateOnly(2026, 5, 15), 1500, studentId, typeId);
            await AddTestLesson(new DateOnly(2026, 5, 20), 2000, studentId, typeId);

            var report = await _service.GetProfitReport(ReportPeriodType.Month, reportDate);

            Assert.Equal(4500, report.CurrentPeriodProfit);
            Assert.Equal(3, report.CurrentPeriodLessonsCount);
        }

        [Fact]
        public async Task GetProfitReport_ShouldCalculatePreviousPeriodProfit_ForMonth()
        {
            var (studentId, typeId) = await AddTestStudentAndType();
            var reportDate = new DateTime(2026, 5, 15);

            await AddTestLesson(new DateOnly(2026, 4, 5), 500, studentId, typeId);
            await AddTestLesson(new DateOnly(2026, 4, 10), 700, studentId, typeId);
            await AddTestLesson(new DateOnly(2026, 5, 10), 1000, studentId, typeId);

            var report = await _service.GetProfitReport(ReportPeriodType.Month, reportDate);

            Assert.Equal(1200, report.PreviousPeriodProfit);
            Assert.Equal(2, report.PreviousPeriodLessonsCount);
        }

        [Fact]
        public async Task GetProfitReport_ShouldCalculateActiveStudents()
        {
            var (studentId1, typeId) = await AddTestStudentAndType();

            var levelId = await CreateTestLevel();
            var student2 = new StudentModel
            {
                FullName = "Student 2",
                Age = 25,
                Phone = "222",
                LevelId = levelId
            };
            await _context.Students.AddAsync(student2);
            await _context.SaveChangesAsync();

            var reportDate = new DateTime(2026, 5, 15);

            await AddTestLesson(new DateOnly(2026, 5, 10), 1000, studentId1, typeId);

            var report = await _service.GetProfitReport(ReportPeriodType.Month, reportDate);

            Assert.Equal(1, report.ActiveStudents);
            Assert.Equal(2, report.TotalStudents);
            Assert.Equal(50, report.ActiveStudentsPercent);
        }

        [Fact]
        public async Task GetProfitReport_ShouldCalculateAverageLessonPrice()
        {
            var (studentId, typeId) = await AddTestStudentAndType();
            var reportDate = new DateTime(2026, 5, 15);

            await AddTestLesson(new DateOnly(2026, 5, 10), 1000, studentId, typeId);
            await AddTestLesson(new DateOnly(2026, 5, 15), 2000, studentId, typeId);
            await AddTestLesson(new DateOnly(2026, 5, 20), 3000, studentId, typeId);

            var report = await _service.GetProfitReport(ReportPeriodType.Month, reportDate);

            Assert.Equal(2000, report.AverageLessonPrice);
        }

        [Fact]
        public async Task GetProfitReport_ShouldIgnoreNonCompletedLessons()
        {
            var (studentId, typeId) = await AddTestStudentAndType();
            var reportDate = new DateTime(2026, 5, 15);

            await AddTestLesson(new DateOnly(2026, 5, 10), 1000, studentId, typeId, LessonStatus.Проведён);
            await AddTestLesson(new DateOnly(2026, 5, 12), 2000, studentId, typeId, LessonStatus.Запланирован);
            await AddTestLesson(new DateOnly(2026, 5, 14), 1500, studentId, typeId, LessonStatus.Отменён);

            var report = await _service.GetProfitReport(ReportPeriodType.Month, reportDate);

            Assert.Equal(1, report.CurrentPeriodLessonsCount);
            Assert.Equal(1000, report.CurrentPeriodProfit);
        }
    }
}
