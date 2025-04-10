using System;
using System.Web;

public static class Formatter
{
    // Constructor
    static Formatter()
    {
        // Any initialization if needed
    }

    // Extension method to capitalize letters according to the given conditions
    public static string CapitalizeLetter(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        char[] array = value.ToLower().ToCharArray();
        bool capitalizeNext = true;

        for (int i = 0; i < array.Length; i++)
        {
            if (capitalizeNext && char.IsLetter(array[i]))
            {
                array[i] = char.ToUpper(array[i]);
                capitalizeNext = false;
            }
            else if (array[i] == ' ' || array[i] == '.')
            {
                capitalizeNext = true;
            }
        }

        return new string(array);
    }

    // Extension method to encode URL according to the given conditions
    public static string UrlEncode(this string input)
    {
        return HttpUtility.UrlEncode(input).Replace("+", "%20");
    }
}

public class Interview
{
    public string Name { get; set; }
    public int Age { get; set; }
    public long PhoneNumber { get; set; }
    public string JobProfile { get; set; }
    public string PortfolioUrl { get; set; }
    public string Suggestion { get; set; }

    // Constructor to initialize properties
    public Interview(string name, string jobProfile, string portfolioUrl, string suggestion, int age, long phoneNumber)
    {
        Name = name.CapitalizeLetter();
        JobProfile = jobProfile.CapitalizeLetter();
        PortfolioUrl = portfolioUrl.UrlEncode();
        Suggestion = suggestion;
        Age = age;
        PhoneNumber = phoneNumber;
    }
}

// Example usage
public class Program
{
    public static void Main()
    {
        Interview interview = new Interview("ajaY malik. k", "software engineer", "http://www.google.com/this is my sample", "Great interview!", 25, 9876543210);
        Console.WriteLine($"Name: {interview.Name}");
        Console.WriteLine($"Job Profile: {interview.JobProfile}");
        Console.WriteLine($"Portfolio URL: {interview.PortfolioUrl}");
        Console.WriteLine($"Suggestion: {interview.Suggestion}");
        Console.WriteLine($"Age: {interview.Age}");
        Console.WriteLine($"Phone Number: {interview.PhoneNumber}");
    }
}
