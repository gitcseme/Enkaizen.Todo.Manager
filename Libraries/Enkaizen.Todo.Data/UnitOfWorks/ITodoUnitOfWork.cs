using Enkaizen.Todo.Dal;
using Enkaizen.Todo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enkaizen.Todo.Data.UnitOfWorks
{
    public interface ITodoUnitOfWork : IUnitOfWorkBase
    {
        ITodoRepository TodoRepository { get; }
    }
}
