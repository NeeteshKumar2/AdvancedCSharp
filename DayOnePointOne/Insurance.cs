public class Insurance
{
    public string InsuranceId { get; set; }
    public string InsuranceName { get; set; }
    public int InsuranceTerm { get; set; }
    public double InsuranceAmount { get; set; }
    public double DoublePremium { get; set; }

    public Insurance(string insuranceId, string insuranceName, int insuranceTerm, double insuranceAmount, double doublePremium)
    {
        InsuranceId = insuranceId;
        InsuranceName = insuranceName;
        InsuranceTerm = insuranceTerm;
        InsuranceAmount = insuranceAmount;
        DoublePremium = doublePremium;
    }
}