using System.Diagnostics;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class UserService : IUserService
{
    // create an instance of useBase list
    public List<UserBase> _users = [];
    
    public void AddUser(UserBase user)
    {
        _users.Add(user);
    }

    public List<UserBase> GetAllUsers()
    {
        try
        {

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
        return _users;
    }

    public UserBase GetUserById(int id)
    {
        try
        {
            return _users[id];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occured: {ex.Message}");
            return null!;
        }
    }

    public int GetUserCount()
    {
        return _users.Count == 0 ? 0 : _users.Count;
    }
}