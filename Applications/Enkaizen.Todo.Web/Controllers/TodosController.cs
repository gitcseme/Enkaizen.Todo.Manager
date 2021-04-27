using Enkaizen.Todo.Data.Entities;
using Enkaizen.Todo.Data.Services;
using Enkaizen.Todo.Web.Models;
using Enkaizen.Todo.Web.Models.TodoModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            var todos = await _todoService.GetAllPaginatedTodosAsync(pageIndex, pageSize);
            int totalTodos = await _todoService.GetCountAsync();

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

                await _todoService.CreateAsync(newTodo);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(string todoId)
        {
            await _todoService.DeleteAsync(new Guid(todoId));

            return RedirectToAction("Index");
        }
    }
}
