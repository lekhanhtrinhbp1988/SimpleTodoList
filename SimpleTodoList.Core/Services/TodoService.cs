﻿using SimpleTodoList.Infrastructure;
using SimpleTodoList.Infrastructure.Entities;
using System;
using System.Threading.Tasks;

namespace SimpleTodoList.Core.Services
{
    public class TodoService : ITodoService
    {
        private TodoDbContext _context;

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

             _context.Todos.Remove(todo);

            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
