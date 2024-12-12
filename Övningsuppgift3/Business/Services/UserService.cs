using Business.Helpers;
using Data.Services;
using Domain.Factories;
using Domain.Models;
using Presentation;


namespace Business.Services;

public class UserService
{
    // create a list of user 
    private List<User> _users = [];
    
    private readonly FileService _fileService = new();

    public void AddUser(UserRegistrationForm form)
    {
        var user = UserFactory.CreateUser(form);
        user.Id = UniqueIdentifierGenerator.Generate();
        _users.Add(user);
        _fileService.SaveListToFile(_users);
        
    }

    public IEnumerable<User> GetUsers()
    {
        _users = _fileService.LoadListFromFile();
        return _users;
    }
}