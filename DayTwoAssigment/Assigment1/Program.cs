

public delegate void ApproveClaimDelegate(ref Claim claim);

public class Claim
{
    public int ClaimId { get; set; }
    public int NumberOfProofs { get; set; }
    public int Amount { get; set; }
    public string CommentUW { get; set; }
    public string CommentBM { get; set; }

    public Claim(int claimId, int numberOfProofs, int amount)
    {
        ClaimId = claimId;
        NumberOfProofs = numberOfProofs;
        Amount = amount;
        CommentUW = "NA";
        CommentBM = "NA";
    }

    public void ApproveClaimUW(ref Claim claim)
    {
        if (claim.NumberOfProofs >= 3)
        {
            claim.CommentUW = "Approved";
        }
        else
        {
            claim.CommentUW = "Rejected";
        }
    }

    public void ApproveClaimBM(ref Claim claim)
    {
        if (claim.CommentUW == "Approved")
        {
            claim.CommentBM = "Approved";
        }
        else if (claim.CommentUW == "Rejected")
        {
            claim.CommentBM = "Rejected";
        }
        else
        {
            claim.CommentBM = "NA";
        }
    }
}


public class Assistant
{
    public void ApproveClaim(string role, ref Claim claim)
    {
        ApproveClaimDelegate approveClaimDelegate = null;

        if (role == "UnderWriter")
        {
            approveClaimDelegate = new ApproveClaimDelegate(claim.ApproveClaimUW);
        }
        else if (role == "BankManager")
        {
            approveClaimDelegate = new ApproveClaimDelegate(claim.ApproveClaimBM);
        }
        else if (role == "InsuranceManager")
        {
            approveClaimDelegate = new ApproveClaimDelegate(claim.ApproveClaimUW);
            approveClaimDelegate += new ApproveClaimDelegate(claim.ApproveClaimBM);
        }

        approveClaimDelegate?.Invoke(ref claim);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Claim claim = new Claim(1, 4, 5000);
        Assistant assistant = new Assistant();

        assistant.ApproveClaim("UnderWriter", ref claim);
        Console.WriteLine($"UnderWriter Comment: {claim.CommentUW}");

        assistant.ApproveClaim("BankManager", ref claim);
        Console.WriteLine($"BankManager Comment: {claim.CommentBM}");

        Claim claim2 = new Claim(2, 2, 3000);
        assistant.ApproveClaim("InsuranceManager", ref claim2);
        Console.WriteLine($"UnderWriter Comment: {claim2.CommentUW}");
        Console.WriteLine($"BankManager Comment: {claim2.CommentBM}");
    }
}