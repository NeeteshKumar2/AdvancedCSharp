using System;
using System.Security.Cryptography.X509Certificates;

namespace ChocolateProblem;
class Chocolate
{
    public string CompanyName { get; set; }
    public string ChoName { get; set; }
    public double ChoNetWeight { get; set; }
    public double ChoPrice { get; set; }
    public Chocolate(string Company, string Name, double NetWeight, double Price)
    {
        
        CompanyName = Company;
        ChoName = Name;
        ChoNetWeight = NetWeight;
        ChoPrice = Price;

    }
 
}

class ChocolateBox
{
   public List<Chocolate> AvailableChocolate { get; set; }

    public ChocolateBox()
        {
        AvailableChocolate = new List<Chocolate>
        { 
        
            new Chocolate("Marsh", "Bounty", 28.5, 40),
            new Chocolate("Nestle", "KITKAT", 90, 100),
            new Chocolate("Mondolz", "Tobelrone", 35, 70.5),
            new Chocolate("Marsh", "Sniker", 240, 250),

        };

    }
}

class Program
{
    static void Main(string[] args)
    {
        ChocolateBox chocolateBox = new ChocolateBox();

        foreach(var chocolate in chocolateBox.AvailableChocolate)
        {
            Console.WriteLine($"Company : {chocolate.CompanyName} , Chocolate Name: {chocolate.ChoName} , NetWeight : {chocolate.ChoNetWeight} Price : {chocolate.ChoPrice}");
        }

    }
}