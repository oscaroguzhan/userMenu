namespace Business.Models;

public class RegularUser : UserBase
{
    private string _roll = "Regular User";
    
    public override string GetRole()
    {
        return _roll;
    }
}