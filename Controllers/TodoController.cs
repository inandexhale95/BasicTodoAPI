namespace WebAPI.Controllers;

using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{

    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService) => _todoService = todoService;

    [HttpGet("/todoitems")]
    public async Task<List<Todo>> GetTodoList() => await _todoService.GetTodoListAsync();

    [HttpGet("/todoitems/{id}")]
    public async Task<Todo?> GetTodo(int id) => await _todoService.GetTodoAsync(id);

    [HttpPost("/todoitems")]
    public async Task AddTodoAsync([FromBody] Todo todo) => await _todoService.AddTodoAsync(todo);

    [HttpPut("/todoitems")]
    public async Task ModifyTodoAsync(int id, [FromBody] Todo inputTodo) =>
        await _todoService.ModifyTodoAsync(id, inputTodo);

    [HttpDelete("/todoitems/{id}")]
    public async Task RemoveTodoAsync(int id) => await _todoService.RemoveTodo(id);
}