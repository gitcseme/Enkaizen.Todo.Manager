using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Data.Services
{
    public interface ITodoService : IService<TodoTask>
    {
        Task<IEnumerable<TodoTask>> GetAllPaginatedTodosAsync(int pageIndex = 1, int pageSize = 10, bool isTrackingOff = true);
        Task<int> GetCountAsync();
        Task DeleteAsync(Guid Id);
    }
}
