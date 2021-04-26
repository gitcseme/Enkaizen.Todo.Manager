using Enkaizen.Todo.Data.Entities;
using Enkaizen.Todo.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Data.Services
{
    public class TodoService : ITodoService
    {
        public TodoService(ITodoUnitOfWork todoUnitOfWork)
        {
            _todoUnitOfWork = todoUnitOfWork;
        }

        public ITodoUnitOfWork _todoUnitOfWork { get; }

        public async Task CreateAsync(TodoTask entity)
        {
            await _todoUnitOfWork.TodoRepository.AddAsync(entity);
            await _todoUnitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(TodoTask entity)
        {
            await _todoUnitOfWork.TodoRepository.RemoveAsync(entity);
            await _todoUnitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _todoUnitOfWork.Dispose();
        }

        public async Task EditAsync(TodoTask entity)
        {
            await _todoUnitOfWork.TodoRepository.EditAsync(entity);
            await _todoUnitOfWork.SaveAsync();
        }

        public TodoTask Get(Guid Id)
        {
            return _todoUnitOfWork.TodoRepository.Get(Id);
        }

        public async Task<TodoTask> GetAsync(Guid Id)
        {
            return await _todoUnitOfWork.TodoRepository.GetAsync(Id);
        }

        public async Task<IEnumerable<TodoTask>> TodoTasks()
        {
            return await _todoUnitOfWork.TodoRepository.GetAllAsync();
        }
    }
}
