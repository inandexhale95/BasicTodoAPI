using WebAPI.Models;

namespace WebAPI.Services;

public interface ITodoService
{
    Task<List<Todo>> GetTodoListAsync();
    Task<Todo> GetTodoAsync(int id);
    Task AddTodoAsync(Todo todo);
    Task ModifyTodoAsync(int id, Todo inputTodo);
    Task RemoveTodo(int id);
}