namespace Business.Models;

public abstract class UserBase
{
    private int Id { get; set; } 
    private string Name { get; set; } = string.Empty;
    
    public abstract string GetRole();
    
}