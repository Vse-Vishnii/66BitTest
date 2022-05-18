using System.Collections.Generic;
using System.Threading.Tasks;

namespace _66BitApp.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(long id);
        Task<T> Add(T entity);
        Task<T> Update(long id, T newEntity);
        Task<T> Delete(long id);
    }
}
