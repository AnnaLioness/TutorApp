using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Конструктор принимает настройки подключения
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet - это таблицы в базе данных
        public DbSet<LessonModel> Lessons { get; set; }
        public DbSet<LevelModel> Levels { get; set; }
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<PublicationModel> Publications { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<TypeModel> Types { get; set; }

        /// <summary>
        /// Настройка связей между таблицами
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Связь Student -> Level (многие к одному)
            modelBuilder.Entity<StudentModel>()
                .HasOne(s => s.Level)
                .WithMany()
                .HasForeignKey(s => s.LevelId);

            // Связь Type -> Subject (многие к одному)
            modelBuilder.Entity<TypeModel>()
                .HasOne(t => t.Subject)
                .WithMany(s => s.Types)
                .HasForeignKey(t => t.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь Lesson -> Student (многие к одному)
            modelBuilder.Entity<LessonModel>()
                .HasOne(l => l.Student)
                .WithMany(s => s.Lessons)  // если у StudentModel есть коллекция Lessons
                .HasForeignKey(l => l.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь Lesson -> Type (многие к одному)
            modelBuilder.Entity<LessonModel>()
                .HasOne(l => l.Type)
                .WithMany()
                .HasForeignKey(l => l.TypeId);

            // Конвертация enum в строку (чтобы в БД было видно название, а не число)
            modelBuilder.Entity<LessonModel>()
                .Property(l => l.Status)
                .HasConversion<string>();

            modelBuilder.Entity<MaterialModel>()
                .Property(m => m.AgeGroup)
                .HasConversion<string>();

            modelBuilder.Entity<MaterialModel>()
                .Property(m => m.Season)
                .HasConversion<string>();
        }
    }
}
