using System.Diagnostics;
using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class UserService : IUserService
{
    // create a new list that instance of useBase
    public List<UserBase> _users = [];
    
    public void AddUser(UserBase user)
    {
        _users.Add(user);
    }

    public List<UserBase> GetAllUsers()
    {
        try
        {
            return _users;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
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