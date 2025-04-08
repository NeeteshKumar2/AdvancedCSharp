class Program
{
    static void Main(string[] args)
    {
        HealthClub healthClub = new HealthClub();

        // Adding employees
        healthClub.AddEmployee("E001");
        healthClub.AddEmployee("E002");

        // Deleting an existing employee
        bool isDeleted = healthClub.DeleteEmployee("E001");
        Console.WriteLine($"Delete E001: {isDeleted}"); // Output: Delete E001: True

        // Trying to delete a non-existent employee
        isDeleted = healthClub.DeleteEmployee("E003");
        Console.WriteLine($"Delete E003: {isDeleted}"); // Output: Delete E003: False
    }
}