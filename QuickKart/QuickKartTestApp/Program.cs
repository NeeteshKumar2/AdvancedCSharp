using QuickKartBL;

namespace QuickKartTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new EliteCustomer("C104", "Robert", "No. 175, 9th Block, Montego",
                            "robert@gmail.com", "9710157996", 15);
            CustomerShippingDetails shippingDetails = new CustomerShippingDetails(customer);
            Console.WriteLine("\n--------------------------------");
            Console.WriteLine("\tShipping Details\t");
            Console.WriteLine("--------------------------------");
            Console.WriteLine(shippingDetails.PrintShippingDetails());
        }
    }
}