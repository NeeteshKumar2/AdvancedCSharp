public delegate void GetBonus(double amount);

public class BankAccount
{
    public double Balance { get; private set; }

    // Method to credit amount to the bank account
    public void Credit(double amount)
    {
        Balance += amount;
    }

    // Method to debit amount from the bank account
    public bool Debit(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}


public class Employee
{
    public BankAccount BankAccount { get; private set; }
    public double PensionFundBalance { get; private set; }
    public int NumberOfShares { get; private set; }

    public Employee()
    {
        BankAccount = new BankAccount();
    }

    // Method to credit amount to the bank account
    public void SetBankAccountCredit(double amount)
    {
        BankAccount.Credit(amount);
    }

    // Method to credit amount to the pension fund balance
    public void SetPensionFundCredit(double amount)
    {
        PensionFundBalance += amount;
    }

    // Method to increment the number of shares
    public void SetNumberOfShares(double amount)
    {
        NumberOfShares += (int)(amount / 100);
    }

    // Method to give bonus based on the bonus option
    public void GiveBonus(int bonusOption, double amount)
    {
        GetBonus getBonusDelegate;

        switch (bonusOption)
        {
            case 1:
                getBonusDelegate = new GetBonus(SetBankAccountCredit);
                break;
            case 2:
                getBonusDelegate = new GetBonus(SetPensionFundCredit);
                break;
            case 3:
                getBonusDelegate = new GetBonus(SetNumberOfShares);
                break;
            default:
                getBonusDelegate = new GetBonus(SetBankAccountCredit);
                break;
        }

        getBonusDelegate(amount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee();

        // Giving bonus by crediting to bank account
        employee.GiveBonus(1, 5000);
        Console.WriteLine($"Bank Account Balance: {employee.BankAccount.Balance}");

        // Giving bonus by crediting to pension fund balance
        employee.GiveBonus(2, 3000);
        Console.WriteLine($"Pension Fund Balance: {employee.PensionFundBalance}");

        // Giving bonus by increasing number of shares
        employee.GiveBonus(3, 2000);
        Console.WriteLine($"Number of Shares: {employee.NumberOfShares}");

        // Giving bonus with default option (crediting to bank account)
        employee.GiveBonus(4, 1000);
        Console.WriteLine($"Bank Account Balance: {employee.BankAccount.Balance}");
    }
}
