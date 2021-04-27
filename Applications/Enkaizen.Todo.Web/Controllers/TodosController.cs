using Enkaizen.Todo.Data.Entities;
using Enkaizen.Todo.Data.Services;
using Enkaizen.Todo.Web.Models;
using Enkaizen.Todo.Web.Models.TodoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Web.Controllers
{
    [Authorize]
    public class TodosController : Controller
    {
        public TodosController(ITodoService todoService, UserManager<ApplicationUser> userManager)
        {
            _todoService = todoService;
            _userManager = userManager;
        }

        private ITodoService _todoService;
        private UserManager<ApplicationUser> _userManager;

        public async Task<IActionResult> Index(int pageIndex = 1, int pageSize = 10)
        {
            IEnumerable<TodoTask> todos = null;
            int totalTodos = 0;
            try
            {
                todos = await _todoService.GetAllPaginatedTodosAsync(pageIndex, pageSize);
                totalTodos = await _todoService.GetCountAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error retrieving TodoTaks");
            }

            var todoViewModels = todos.Select(td => new TodoViewModel
            {
                Id = td.Id.ToString(),
                Description = td.Description,
                IsDone = td.IsDone,
                CreationDate = td.CreationDate.ToShortTimeString() + ", " + td.CreationDate.ToShortDateString()
            }).ToList();

            var model = new TodoIndexModel(todoViewModels, pageIndex, pageSize, totalTodos);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(TodoCreateViewModel model)
        {
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var newTodo = new TodoTask
                {
                    Description = model.Description,
                    IsDone = false,
                    CreationDate = DateTime.Now,
                    CreatorId = new Guid(loggedInUser.Id)
                };

                try 
                {
                    await _todoService.CreateAsync(newTodo);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error creating new TodoTask");
                }
                
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string todoId)
        {
            try
            {
                await _todoService.DeleteAsync(new Guid(todoId));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error deleting TodoTask");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> MarkDone(string todoId)
        {
            try
            {
                var todo = await _todoService.GetAsync(new Guid(todoId));
                todo.IsDone = true;
                await _todoService.EditAsync(todo);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating TodoTask");
            }

            return RedirectToAction("Index");
        }

    }
}
