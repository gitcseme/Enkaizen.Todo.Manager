using Enkaizen.Todo.Data.Entities;
using Enkaizen.Todo.Data.Services;
using Enkaizen.Todo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Enkaizen.Todo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITodoService _todoService;

        public HomeController(ILogger<HomeController> logger, ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            //var userId = Guid.NewGuid();

            //var todo = new TodoTask
            //{
            //    CreatorId = userId,
            //    ModifierId = userId,
            //    Description = "This is a test",
            //    IsDone = false
            //};

            //await _todoService.CreateAsync(todo);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
