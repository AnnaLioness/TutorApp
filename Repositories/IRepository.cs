using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<T> where T : class, IId
    {
        /// <summary>Получить все записи</summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>Получить запись по ID</summary>
        Task<T?> GetByIdAsync(int id);

        /// <summary>Добавить новую запись</summary>
        Task AddAsync(T entity);

        /// <summary>Обновить запись</summary>
        Task UpdateAsync(T entity);

        /// <summary>Удалить запись</summary>
        Task DeleteAsync(T entity);

        /// <summary>Сохранить изменения в БД</summary>
        Task SaveAsync();
    }
}
