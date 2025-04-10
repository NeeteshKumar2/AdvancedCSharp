using System;

public class Bill
{
    public string BillId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    // Constructor to initialize BillId, Quantity, and Price
    public Bill(string billId, int quantity, double price)
    {
        BillId = billId;
        Quantity = quantity;
        Price = price;
    }
}

public class Restaurant
{
    // Method to calculate the total amount including service tax
    public double CalculateAmount(Bill billObj)
    {
        // Calculate the total amount based on quantity and price
        double totalAmount = billObj.Quantity * billObj.Price;

        // Call the extension method to calculate the service tax
        double serviceTax = billObj.CalculateServiceTax(totalAmount);

        // Return the sum of total amount and service tax
        return totalAmount + serviceTax;
    }
}

public static class BillExtension
{
    // Extension method to calculate the service tax
    public static double CalculateServiceTax(this Bill bill, double totalAmount)
    {
        double serviceTax = 0;

        // Compute service tax based on the total amount
        if (totalAmount >= 2000 && totalAmount <= 5000)
        {
            serviceTax = totalAmount * 0.02; // 2% service tax
        }
        else if (totalAmount > 5000)
        {
            serviceTax = totalAmount * 0.05; // 5% service tax
        }

        return serviceTax;
    }
}

// Example usage
public class Program
{
    public static void Main()
    {
        Bill bill = new Bill("B001", 10, 300);
        Restaurant restaurant = new Restaurant();
        double totalAmount = restaurant.CalculateAmount(bill);
        Console.WriteLine($"Total Amount (including service tax): {totalAmount}");
    }
}
