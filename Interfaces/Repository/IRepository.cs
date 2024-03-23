using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();

        Task<T>? GetItemAsync(int id);

        Task<T> CreateAsync(T item); // создание объекта

        void Update(T item); // обновление объекта

        void DeleteAsync(int id); // удаление объекта по id
    }

}
