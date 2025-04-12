using System;

public class PC
{
    private static int counter = 0;
    private const int maxPC = 2;
    private bool isPCAllocated = false;

    // Method to allocate a PC
    public bool AllocatePC()
    {
        if (counter < maxPC)
        {
            if (!isPCAllocated)
            {
                isPCAllocated = true;
                Console.WriteLine("PC allocated.");
                counter++;
                return true;
            }
        }
        return false;
    }

    // Method to deallocate a PC
    public void DeAllocatePC(string method)
    {
        isPCAllocated = false;
        counter--;
        Console.WriteLine($"PC deallocated by {method}.");
    }
}

public class PCUser : IDisposable
{
    private PC pc;

    // Method to request a PC
    public bool RequestPC(PC pc)
    {
        this.pc = pc;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        return pc.AllocatePC();
    }

    // Method to release a PC
    public void ReleasePC(string method)
    {
        pc.DeAllocatePC(method);
        GC.SuppressFinalize(this);
    }

    // Destructor
    ~PCUser()
    {
        pc.DeAllocatePC("allocator");
    }

    // Dispose method
    public void Dispose()
    {
        ReleasePC("force");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        PC pc1 = new PC();
        PC pc2 = new PC();

        // User1 requests PC
        PCUser user1 = new PCUser();
        user1.RequestPC(pc1);

        // User1 forgets to release PC
        user1 = null;

        // User2 requests PC and PC is deallocated forcefully
        using (PCUser user2 = new PCUser())
        {
            user2.RequestPC(pc2);
        }

        PCUser user3 = new PCUser();
        // User3 requests PC and Allocator deallocates PC1 used by user1
        user3.RequestPC(pc1);
        // User3 releases the PC after use
        user3.ReleasePC("user3");
    }
}
