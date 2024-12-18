namespace Business.Models;

public class AdminUser : UserBase
{
    private string _roll = "Admin User";
    public override string GetRole()
    {
        return _roll;
    }
}