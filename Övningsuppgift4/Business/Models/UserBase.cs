namespace Business.Models;

public abstract class UserBase
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    
    public abstract string GetRole();
    
}