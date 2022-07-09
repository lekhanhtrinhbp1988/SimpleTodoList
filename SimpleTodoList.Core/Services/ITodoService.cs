using SimpleTodoList.Infrastructure.Entities;
using System.Threading.Tasks;

namespace SimpleTodoList.Core.Services
{
    public interface ITodoService
    {
        Task<bool> Create(Todo todo);
    }
}