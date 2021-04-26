using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Data.Contexts;
using Enkaizen.Todo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enkaizen.Todo.Data.UnitOfWorks
{
    public class TodoUnitOfWork : UnitOfWorkBase<TodoContext>, ITodoUnitOfWork
    {
        public TodoUnitOfWork(string connectionString, string migrationAssemblyName) 
            : base(connectionString, migrationAssemblyName)
        {
            TodoRepository = new TodoRepository(_dbContext);
        }

        public ITodoRepository TodoRepository { get; set; }
    }
}
