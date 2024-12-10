using ShoppingList.Models;

namespace ShoppingList;

internal class Program
{
    // create a list to save products
    public static List<Product> products = new List<Product>()
    {
        new Product()
        {
            ProductName = "Apple",
            ProductPrice = 20
        },
        new Product()
        {
            ProductName = "Bananas",
            ProductPrice = 25
        },
        new Product()
        {
            ProductName = "Coffee",
            ProductPrice = 30
        },
        new Product()
        {
            ProductName = "Kiwi",
            ProductPrice = 15
        },
    };
    
    static void Main(string[] args)
    {
        // variabler
        bool isProgramRunning = true;
        double totalPrice = 0;
        do
        {
            totalPrice = 0;
            Console.Clear();
            if (products.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("-------- Your ShoppingList!  ------------");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.ProductName} - {product.ProductPrice:F2} kr ");
                    totalPrice += product.ProductPrice;
                }
                Console.WriteLine($"Total price {totalPrice:F2} kr ");
                Console.WriteLine("-------------------------------------------------");
            }
            else
            {
                Console.WriteLine("There are no products yet!");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" --------- What would you like to do? --------: ");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateProduct();
                    break;
                case "3":
                    RemoveProduct();
                    break;

                case "4":
                    ExitOption();
                    break;
                default:
                    InvalidOption();
                    break;
            }

            Console.ReadKey();
        } while (isProgramRunning);
        
    }

    private static void ExitOption()
    {
        Console.WriteLine("Do you want to exit? (Y/N): ");
        var option = Console.ReadLine()!.ToLower();
        if (option.Equals("Y", StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Thank you for using the ShoppingList!");
            Console.WriteLine("See you again!");
        }
        Environment.Exit(0);
    }

    private static void RemoveProduct()
    {
        
    }

    private static void UpdateProduct()
    {
        
    }

    private static void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("Invalid option, please try again!");
        
    }

    private static void AddProduct()
    {
        Product product = new Product();
        Console.Clear();
        Console.Write("Enter Product Name: ");
        var productName = Console.ReadLine()!;
        Console.Write("Enter Product Price: ");
        var inputPrice = double.Parse(Console.ReadLine()!);
        product.ProductName = productName;
        product.ProductPrice += inputPrice;
        if (string.IsNullOrEmpty(productName))
        {
            Console.WriteLine("Product name is required!");
        }
        else
        {
            products.Add(product);
        } ;

        
       

       
    }
}