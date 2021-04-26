using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Data.Contexts;
using Enkaizen.Todo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Data.Repositories
{
    public class TodoRepository : RepositoryBase<TodoTask, Guid, TodoContext>, ITodoRepository
    {
        public TodoRepository(TodoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TodoTask>> GetAllPaginatedTodosAsync(int pageIndex = 1, int pageSize = 10, bool isTrackingOff = true)
        {
            IQueryable<TodoTask> query = _DbSet.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            IEnumerable<TodoTask> data;
            if (isTrackingOff)
                data = await query.AsNoTracking().ToListAsync();
            else
                data = await query.ToListAsync();

            return data;
        }
    }
}
