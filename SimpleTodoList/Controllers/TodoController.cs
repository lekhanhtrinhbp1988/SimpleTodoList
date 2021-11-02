﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleTodoList.Entities;
using SimpleTodoList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTodoList.Controllers
{
    public class TodoController : Controller
    {
        private readonly ILogger<TodoController> _logger;
        private readonly TodoDbContext _context;

        public TodoController(ILogger<TodoController> logger, TodoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateEditTodoViewModel();
            return View(model);
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
                await _context.Todos.AddAsync(newTodo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}