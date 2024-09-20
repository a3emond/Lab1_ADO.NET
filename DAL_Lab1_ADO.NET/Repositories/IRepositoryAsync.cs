using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Lab1_ADO.NET.Repositories
{
    internal interface IRepositoryAsync<T>
    {
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<T> GetByIdAsync(int id); 
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
