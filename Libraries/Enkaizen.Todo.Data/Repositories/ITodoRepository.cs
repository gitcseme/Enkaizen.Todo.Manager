using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Data.Repositories
{
    public interface ITodoRepository : IRepositoryBase<TodoTask, Guid>
    {
        Task<IEnumerable<TodoTask>> GetAllPaginatedTodosAsync(int pageIndex, int pageSize, bool isTrackingOff);
    }
}
