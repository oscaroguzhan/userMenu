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
            Environment.Exit(0);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" --------- What would you like to do? --------: ");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-----------------------------------------");
        }
        
    }

    private static void RemoveProduct()
    {
        Console.Clear();
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].ProductName}");
        }
        Console.WriteLine("Which one do you want to remove? : ");
        var option = Console.ReadLine()!;
        Console.WriteLine("Press any key to continue...");
        int.TryParse(option, out int indexOutput);
        indexOutput--;
        if (indexOutput >= 0 && indexOutput <= products.Count)
        {
            products.RemoveAt(indexOutput);
        }
        else
        {
            Console.WriteLine("Invalid input. Press any key to return to the Main Menu...");
            
        }
    }

    private static void UpdateProduct()
    {
            Console.Clear();
            // Display the current list of products
            Console.WriteLine("Here are the available products:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i].ProductName} - {products[i].ProductPrice:F2} kr");
            }
    
            // Ask the user to select a product to update
            Console.WriteLine("Enter the number of the product you want to update:");
            var input = Console.ReadLine()!;
            int.TryParse(input, out int productIndex);
            productIndex--; // Convert to zero-based index

            if (productIndex >= 0 && productIndex < products.Count)
            {
                // Ask for updated details
                Console.Write("Enter the new product name (leave blank to keep the same): ");
                var newName = Console.ReadLine()!;

                Console.Write("Enter the new product price (leave blank to keep the same): ");
                var newPriceInput = Console.ReadLine()!;

                // Update the product details
                if (!string.IsNullOrEmpty(newName))
                {
                    products[productIndex].ProductName = newName;
                }

                if (double.TryParse(newPriceInput, out double newPrice) && newPrice >= 0)
                {
                    products[productIndex].ProductPrice = newPrice;
                }

                Console.WriteLine("Product updated successfully!");
                Console.WriteLine("Press any key to return to the Main Menu...");
            }
            else
            {
                Console.WriteLine("Invalid selection. Press any key to return to the Main Menu...");
            }

            Console.ReadKey();
    }

    private static void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("Invalid option, please try again!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void AddProduct()
    {
        // get instance of the product object
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
            Console.WriteLine("Press any key to continue...");
        } ;
    }
}