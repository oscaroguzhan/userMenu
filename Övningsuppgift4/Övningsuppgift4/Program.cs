using Business.Interfaces;
using Business.Models;
using Business.Services;


// create an instance of userService
IUserService userService = new UserService();

do
{
    Console.Clear();
    Console.WriteLine("Welcome to the user management menu");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine($"{"1.", -3} Add a new user");
    Console.WriteLine($"{"2.", -3} List all users");
    Console.WriteLine($"{"3.", -3} Find User by id");
    Console.WriteLine($"{"4.", -3} Exit");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine();
    Console.Write("Enter your choice: ");
    var choice = Console.ReadLine()!;

    switch (choice.ToLower())
    {
        case "1":
            // instantiate a new empty user
            UserBase user;
            
            Console.Clear();
            Console.WriteLine("Which type of user do you want to add? (Admin/Standard):");
            Console.WriteLine("-------------------");
            Console.WriteLine("[1] Admin User");
            Console.WriteLine("[2] Standard User");
            Console.Write("Enter your choice: ");
            var option = Console.ReadKey().KeyChar.ToString();
            switch (option)
            {
                case "1":
                    user = new AdminUser();
                    break;
               default:
                    user = new RegularUser();
                   break;
            }
            
            Console.WriteLine();
            Console.Write("Enter username: ");
            user.Name = Console.ReadLine()!;
            user.Id = userService.GetUserCount() + 1;
            userService.AddUser(user);

            Console.WriteLine($"User {user.Name} as a {user.GetRole()} with user id {user.Id} has added successfully ");
            Thread.Sleep(1500);
            
            break;
    }
} while (true);