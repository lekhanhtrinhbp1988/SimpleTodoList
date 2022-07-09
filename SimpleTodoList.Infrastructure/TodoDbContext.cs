using Microsoft.EntityFrameworkCore;
using SimpleTodoList.Infrastructure.Entities;

namespace SimpleTodoList.Infrastructure
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }
        public DbSet<Todo> Todos { get; set; }
    }
}
