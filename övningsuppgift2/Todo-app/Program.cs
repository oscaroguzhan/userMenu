using Todo_app.Models;
using System.Data;
namespace Todo_app;

internal class Program
{
    // internal varibler 
    static bool isProgramRunning = true;

    static List<Todo> todos = new List<Todo>()
    {
        new Todo()
        {
            Id = 1,
            Title = "Learn C# service pattern ",
            IsComplete = false
        },
        new Todo()
        {
            Id = 2,
            Title = " Complete todo app ",
            IsComplete = false
        }
    };
    
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            
            Console.WriteLine("Welcome to Task Manager App");
            Console.WriteLine("---------------------------");
            
            Console.WriteLine($"{"1.", -3} Add a new task");
            Console.WriteLine($"{"2.", -3} Remove a task");
            Console.WriteLine($"{"3.", -3} Update a task");
            Console.WriteLine($"{"4.", -3} Skriv ut all tasks");
            Console.WriteLine($"{"5.", -3} Exit the program");
            Console.WriteLine("--------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your choice: ");
            
            char choice = Console.ReadKey().KeyChar;
            
            Console.WriteLine(choice);

            switch (choice)
            {
                case '1':
                    ListTodos();
                    break;
            }
        } while (isProgramRunning);
        
       
    }

    private static void ListTodos()
    {
        List<Todo> finishedTodos = new List<Todo>();
        if (finishedTodos == null) throw new ArgumentNullException(nameof(finishedTodos));
        todos.ForEach(x =>
        {
            if (x.IsComplete)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                finishedTodos.Add(x);
            }
            else
            {
                Console.WriteLine($"Task {x.Id} : {x.Title} is not completed");
            }
        });
        if (finishedTodos.Count <= 0) return;
        {
            Console.WriteLine("Completed tasks: ");
            finishedTodos.ForEach(x => Console.WriteLine($"XO - {x.Title}"));
        }
        
    }
}