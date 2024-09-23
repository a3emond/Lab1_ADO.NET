using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL_Lab1_ADO.NET.Repositories
{
    public interface IRepositoryAsync<T>
    {
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<T> GetByIdAsync(int id); 
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
