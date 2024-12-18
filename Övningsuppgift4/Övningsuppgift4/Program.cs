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
    Console.WriteLine($"{"2.", -3} Find User by id");
    Console.WriteLine($"{"3.", -3} List all users");
    Console.WriteLine($"{"4.", -3} Exit");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine();
    Console.Write("Enter your choice: ");
    var choice = Console.ReadKey().KeyChar.ToString()!;

    switch (choice)
    {
        case "1":
            {
                // instantiate a new empty user
                UserBase user;
            
                Console.Clear();
                Console.WriteLine("Which type of user do you want to add? (Admin/Standard):");
                Console.WriteLine("-------------------");
                Console.WriteLine("[1] Admin User");
                Console.WriteLine("[2] Standard User");
                Console.WriteLine("-------------------");
                Console.Write("Enter your choice: ");
                switch (Console.ReadKey().KeyChar.ToString())
                {
                    case "1":
                        user = new AdminUser();
                        break;
                    default:
                        user = new RegularUser();
                        break;
                }
            
                Console.Write("\n");
                Console.Write("Enter username: ");
                user.Name = Console.ReadLine()!;
                user.Id = userService.GetUserCount() +1;
                userService.AddUser(user);
            
                Console.WriteLine($"User {user.Name} as a {user.GetRole()} with user id {user.Id} has added successfully ");
                Thread.Sleep(1500);
                break;
            }
        case "2":                                                                                        
        {                                                                                            
            Console.Clear();                                                                         
            Console.Write("Enter user id: ");
            Console.WriteLine();
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out var index))                                    
            {
                Console.WriteLine();
                var user = userService.GetUserById(index-1);
                Console.WriteLine($" Id {user.Id}");
                Console.WriteLine($"Roll: {user.GetRole()}");
                Console.WriteLine($"Name: {user.Name}");
                Console.ReadKey();                                                                       
            }                                                                                        
            break;                                                                                   
        }                                                                                            
        case "3":
            {// Get users
                var users = userService.GetAllUsers();
                // If null or 0 then return to main menu
                if(users == null || users.Count == 0)
                {
                    Console.WriteLine($"No users in list, returning");
                    Thread.Sleep(1500);
                    break;
                }
                Console.Clear();
                Console.WriteLine("-------------------");
                foreach (var _user in users)                                                               
                {                                                                                          
                    Console.WriteLine($"Id {_user.Id}");
                    Console.WriteLine($"Roll: {_user.GetRole()}");
                    Console.WriteLine($"Name: {_user.Name}");
                    Console.WriteLine();
                }                                                                                          
                Console.WriteLine("Press any key to continue");                                            
                Console.ReadKey();                                                                         
                break;                                                                                     
            }
        case "4":
            Console.Clear();
            Console.WriteLine("Are you sure you want to exit? (Y/N)");
            if (Console.ReadKey().KeyChar.ToString().ToLower() == "y")
            {
                Console.WriteLine();
                Console.WriteLine("Thank you for using the application...");
                Environment.Exit(0);
            }
            break;
    }

} while (true);