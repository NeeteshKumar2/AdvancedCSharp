public delegate int CalculatorDelegate(int numberOne, int numberTwo);

public class Calculator
{
    // Method to add two numbers
    public int Add(int numberOne, int numberTwo)
    {
        return numberOne + numberTwo;
    }

    // Method to subtract two numbers
    public int Subtract(int numberOne, int numberTwo)
    {
        return numberOne - numberTwo;
    }

    // Method to multiply two numbers
    public int Multiply(int numberOne, int numberTwo)
    {
        return numberOne * numberTwo;
    }
}

public class Calculation
{
    // Method to perform calculation based on the choice
    public int PerformCalculation(int choice, int numberOne, int numberTwo)
    {
        CalculatorDelegate calculatorDelegate;

        switch (choice)
        {
            case 1:
                calculatorDelegate = new CalculatorDelegate(new Calculator().Add);
                break;
            case 2:
                calculatorDelegate = new CalculatorDelegate(new Calculator().Subtract);
                break;
            case 3:
                calculatorDelegate = new CalculatorDelegate(new Calculator().Multiply);
                break;
            default:
                calculatorDelegate = new CalculatorDelegate(new Calculator().Add);
                break;
        }

        return calculatorDelegate(numberOne, numberTwo);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculation calculation = new Calculation();

        // Performing addition
        int result = calculation.PerformCalculation(1, 10, 5);
        Console.WriteLine($"Addition Result: {result}");

        // Performing subtraction
        result = calculation.PerformCalculation(2, 10, 5);
        Console.WriteLine($"Subtraction Result: {result}");

        // Performing multiplication
        result = calculation.PerformCalculation(3, 10, 5);
        Console.WriteLine($"Multiplication Result: {result}");

        // Performing default addition
        result = calculation.PerformCalculation(4, 10, 5);
        Console.WriteLine($"Default Addition Result: {result}");
    }
}