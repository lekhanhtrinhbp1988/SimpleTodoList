using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleTodoList.Core.Services;
using SimpleTodoList.Infrastructure;
using SimpleTodoList.Infrastructure.Entities;
using SimpleTodoList.Web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodoList.Web.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoDbContext _context;
        private readonly ITodoService _todoService;

        public TodoController(ILogger<TodoController> logger, TodoDbContext context, ITodoService todoService)
        {
            _logger = logger;
            _context = context;
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todos = await _context.Todos.AsNoTracking().Select(e => new TodoViewModel
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description
            }).ToListAsync();

            return View(todos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateEditTodoViewModel();
            return View(model);
        }

        [HttpGet]
        public IActionResult AjaxCreate()
        {
            var model = new CreateEditTodoViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AjaxCreate(CreateEditTodoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newTodo = new Todo
                {
                    Title = model.Title,
                    Description = model.Description
                };

                var result = await _todoService.Create(newTodo);

                return Json(result);
            }
            return Json(false);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateEditTodoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newTodo = new Todo
                {
                    Title = model.Title,
                    Description = model.Description
                };

                await _todoService.Create(newTodo);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
