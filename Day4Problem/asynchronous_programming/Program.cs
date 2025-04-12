using System;
using System.Threading;

public class Program
{
    // Simulate delay involved in a movie download using Thread.Sleep()
    static string MovieDownload()
    {
        Console.WriteLine("Download started...");
        Thread.Sleep(5000); // Simulate download delay
        Console.WriteLine("Download finished...");
        return "1024 MB downloaded";
    }

    // Method to read the review
    static void ReadReview()
    {
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Review: This is a movie review!");
        Console.WriteLine("-------------------------------");
    }

    // Main method
    public static void Main()
    {
        Console.WriteLine(MovieDownload());
        Console.WriteLine("Your download is in progress. Do you want to read the review? {Y/N}");
        if (Console.ReadKey(true).KeyChar == 'y' || Console.ReadKey(true).KeyChar == 'Y')
        {
            ReadReview();
        }
        Console.WriteLine("Goodbye.");
    }
}
