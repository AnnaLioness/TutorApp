using Microsoft.Extensions.DependencyInjection;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Сервисы для работы с основными сущностями
            services.AddScoped<LessonService>();
            services.AddScoped<StudentService>();
            services.AddScoped<MaterialService>();
            services.AddScoped<PublicationService>();

            // Сервис для справочников
            services.AddScoped<DictionaryService>();

            return services;
        }
    }
}
