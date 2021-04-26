using System;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Dal
{
    public interface IUnitOfWorkBase : IDisposable
    {
        Task SaveAsync();
        void Save();
    }
}
