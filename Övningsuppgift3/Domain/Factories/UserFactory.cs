using Domain.Models;
using Presentation;

namespace Domain.Factories;

public static class UserFactory
{
    public static UserRegistrationForm Create()
    {
        return new UserRegistrationForm();
    }
    public static User CreateUser(UserRegistrationForm form)
    {
        return new User
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email
        };
    }
}