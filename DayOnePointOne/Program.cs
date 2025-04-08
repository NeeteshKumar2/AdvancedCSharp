class Program
{
    static void Main(string[] args)
    {
        Agent agent = new Agent();

        // Adding policies
        agent.AddPolicy(new Insurance("001", "Health Insurance", 10, 500000, 10000));
        agent.AddPolicy(new Insurance("002", "Life Insurance", 20, 1000000, 20000));

        // Searching for a policy
        var policy = agent.SearchPolicy("001");
        if (policy != null)
        {
            Console.WriteLine($"Found policy: {policy.InsuranceName}");
        }
        else
        {
            Console.WriteLine("Policy not found.");
        }

        // Deleting a policy
        agent.DeletePolicy("001");

        // Verifying deletion
        policy = agent.SearchPolicy("001");
        if (policy == null)
        {
            Console.WriteLine("Policy successfully deleted.");
        }
    }
}