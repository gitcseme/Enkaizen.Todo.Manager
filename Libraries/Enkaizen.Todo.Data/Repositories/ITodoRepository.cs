using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enkaizen.Todo.Data.Repositories
{
    public interface ITodoRepository : IRepositoryBase<TodoTask, Guid>
    {
    }
}
