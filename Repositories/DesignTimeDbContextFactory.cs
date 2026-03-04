using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Указываем путь к файлу базы данных
            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "TutorApp.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            Console.WriteLine($"DesignTime: База данных будет создана по пути: {dbPath}");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
