using Business.Services;
using Domain.Factories;

using Presentation;

namespace JSONBaseradUserMenuApp;

public class MenuService
{
    // create an instance of user service
    private readonly UserService _userService = new();

    public void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(" Welcome to the user menu! What would you like to do? ");
            Console.WriteLine("---------------------------- ----------------------");
            Console.WriteLine($"{"1. ", -3 } Create a user");
            Console.WriteLine($"{"2. ", -3 } Show users");
            Console.WriteLine($"{"3. ", -3 } Exit");
            Console.WriteLine("-------------------------- ----------------------");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine()!;
        
            switch( choice.ToLower())
            {
                case "1":
                    CreateUserDialog();
                    break;
                case "2":
                    ShowUsers();
                    break;
                case "3":
                    ExitOption();
                    break;
                default:
                    InvalidOption();
                    break;
            };
        }
    }

    private static void InvalidOption()
    {
        Console.WriteLine("Invalid option. Please try again.");
        Console.ReadKey();
    }

    private static void ExitOption()
    {
        Console.Clear();
        Console.Write("Are you sure you want to exit? (y/n): ");
        var choice = Console.ReadLine()!.ToLower();
        if (!string.Equals(choice, "y", StringComparison.OrdinalIgnoreCase)) return;
        Console.WriteLine("Thanks for using the app...");
        Environment.Exit(0);
    }

    private void CreateUserDialog()
    {
        Console.Clear();
        UserRegistrationForm user = UserFactory.Create();

        Console.WriteLine("-------------------------");
        
        Console.Write("Enter your first name: ");
        user.FirstName = Console.ReadLine()!;
        Console.Write("Enter your last name: ");
        user.LastName = Console.ReadLine()!;
        Console.Write("Enter your Email: ");
        user.Email = Console.ReadLine()!;
        Console.WriteLine("---------------------");
        _userService.AddUser(user);
    }

    private void ShowUsers()
    {
        Console.Clear();
        Console.WriteLine("-------- All users  --------");
        var users = _userService.GetUsers();
        foreach (var user in users)
        {
            Console.WriteLine($"UserId: {user.Id}");
            Console.WriteLine($"First name: {user.FirstName}");
            Console.WriteLine($"Last name: {user.LastName}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine("---------------------");
        }
        Console.ReadKey();
    }
}