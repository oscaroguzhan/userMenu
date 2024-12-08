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
                Console.WriteLine("-------- Welcome to ShoppingList!  ------------");
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
            Console.WriteLine(" --------- Choose an option: ------------ ");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Product");
            Console.WriteLine("3. Delete Product");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-----------------------------------------");

            switch (Console.ReadLine())
            {
                case "1":
                    AddProduct();
                    break;
                case "4":
                    isProgramRunning = false;
                    break;
            }
            
        } while (isProgramRunning);
        
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