
using Microsoft.EntityFrameworkCore;
using WebAPI.Contexts;
using WebAPI.Models;
using WebAPI.Services;

public class TodoService : ITodoService
{
    
    private readonly TodoContext _todoContext;

    public TodoService(TodoContext todoContext) => _todoContext = todoContext;

    public async Task AddTodoAsync(Todo todo)
    {
        await _todoContext.AddAsync(todo);
        await _todoContext.SaveChangesAsync();
    }

    public async Task<Todo> GetTodoAsync(int id) => 
        await _todoContext.Todos.FirstOrDefaultAsync(todo => todo.Id == id) ?? throw new Exception($"{id}는 존재하지 않습니다.");

    public async Task<List<Todo>> GetTodoListAsync() => await _todoContext.Todos.ToListAsync();
    
    public async Task ModifyTodoAsync(int id, Todo inputTodo)
    {
        var dbTodo = await _todoContext.Todos.FindAsync(id);

        if (dbTodo is null)
        {
            throw new IndexOutOfRangeException($"{id}는 존재하지 않습니다.");
        }

        // 엔터티를 컨텍스트에 추가하고 상태를 Modified로 설정
        _todoContext.Entry(dbTodo).State = EntityState.Modified;
        
        // 변경할 속성 설정
        dbTodo.Name = inputTodo.Name;
        dbTodo.IsComplete = inputTodo.IsComplete;
        
        await _todoContext.SaveChangesAsync();
    }

    public async Task RemoveTodo(int id)
    {
        var dbTodo = await _todoContext.Todos.FindAsync(id);

        if (dbTodo is null)
        {
            throw new IndexOutOfRangeException($"{id}는 존재하지 않습니다.");
        }

        _todoContext.Todos.Remove(dbTodo);
        await _todoContext.SaveChangesAsync();
    }
}