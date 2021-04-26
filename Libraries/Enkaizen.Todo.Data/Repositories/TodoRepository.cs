using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Data.Contexts;
using Enkaizen.Todo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enkaizen.Todo.Data.Repositories
{
    public class TodoRepository : RepositoryBase<TodoTask, Guid, TodoContext>, ITodoRepository
    {
        public TodoRepository(TodoContext context) : base(context)
        {
        }
    }
}
