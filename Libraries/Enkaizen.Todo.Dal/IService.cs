using System;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Dal
{
    public interface IService<T> : IDisposable where T : class
    {
        Task CreateAsync(T entity);
        Task EditAsync(T entity);
        Task DeleteAsync(T entity);

        T Get(Guid Id);
        Task<T> GetAsync(Guid Id);
    }
}
