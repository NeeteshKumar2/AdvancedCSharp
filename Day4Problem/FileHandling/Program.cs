using System;
using System.IO;

public class Product
{
    private static int counter = 1001;
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public int CategoryID { get; set; }
    public double Price { get; set; }
    public int QuantityAvailable { get; set; }

    // Default constructor to initialize the counter
    public Product()
    {
        counter = 1001;
    }

    // Parameterized constructor to initialize product details
    public Product(string productName, int categoryID, double price, int quantityAvailable)
    {
        ProductID = "P" + counter++;
        ProductName = productName;
        CategoryID = categoryID;
        Price = price;
        QuantityAvailable = quantityAvailable;
    }
}

public class Program
{
    private static string fileName = "C:\\AdvancedCSharp\\AdvancedCSharp\\Day4Problem\\Products.txt";

    // Method to add a new product
    public static void AddProduct()
    {
        // Read product details from the console
        Console.Write("Enter Product Name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter Category ID: ");
        int categoryID = int.Parse(Console.ReadLine());
        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine());
        Console.Write("Enter Quantity Available: ");
        int quantityAvailable = int.Parse(Console.ReadLine());

        // Create a new product object
        Product product = new Product(productName, categoryID, price, quantityAvailable);

        // Open the file to write the product details
        using (StreamWriter writer = new StreamWriter(fileName, true))
        {
            writer.WriteLine("{0},{1},{2},{3},{4}", product.ProductID, product.ProductName, product.CategoryID, product.Price, product.QuantityAvailable);
        }

        Console.WriteLine("Product added successfully!");
    }

    // Method to display all product details
    public static void DisplayDetails()
    {
        if (File.Exists(fileName))
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] details = line.Split(',');
                    Console.WriteLine("Product ID: {0}", details[0]);
                    Console.WriteLine("Product Name: {0}", details[1]);
                    Console.WriteLine("Category ID: {0}", details[2]);
                    Console.WriteLine("Price: {0}", details[3]);
                    Console.WriteLine("Quantity Available: {0}", details[4]);
                    Console.WriteLine();
                }
            }
        }
        else
        {
            Console.WriteLine("No products found.");
        }
    }

    // Method to search for a product by ProductID
    public static void SearchProduct()
    {
        if (File.Exists(fileName))
        {
            Console.Write("Enter Product ID to search: ");
            string searchID = Console.ReadLine();
            bool found = false;

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] details = line.Split(',');
                    if (details[0] == searchID)
                    {
                        Console.WriteLine("Product ID: {0}", details[0]);
                        Console.WriteLine("Product Name: {0}", details[1]);
                        Console.WriteLine("Category ID: {0}", details[2]);
                        Console.WriteLine("Price: {0}", details[3]);
                        Console.WriteLine("Quantity Available: {0}", details[4]);
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Product not found.");
            }
        }
        else
        {
            Console.WriteLine("No products found.");
        }
    }

    // Main method to display menu and perform operations
    public static void Main(string[] args)
    {
        int option;
        do
        {
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Display Details");
            Console.WriteLine("3. Search Product");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    AddProduct();
                    break;
                case 2:
                    DisplayDetails();
                    break;
                case 3:
                    SearchProduct();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (option != 4);
    }
}
