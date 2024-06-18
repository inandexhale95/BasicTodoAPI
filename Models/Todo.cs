namespace WebAPI.Models;

public class Todo
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }

    public override string ToString() => $"Todo(Id={Id}, Name={Name}, IsComplete={IsComplete})";
}