namespace Todo_app.Models;

public class Todo
{
    public int Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    public bool IsComplete { get; set; }    
}