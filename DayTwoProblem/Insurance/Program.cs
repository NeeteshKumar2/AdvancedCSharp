using System; 

namespace InsurancePolicy;




class Insurance
{
    public double Intrest { get; set; }
    public int MaxAge { get; set; }
    public int MinAge { get; set; }
    public string PolicyId { get; set; }
    public string PolicyName { get; set; }
    public double PremiumAmt { get; set; }
    public int Term { get; set; }

    public Insurance(double intrest, int maxAge, int minAge, double premiumAmt, int term, string policyName)
    {
        
        //This property sets the interest value if it is greater than 0, otherwise sets it to 8 by default
        if (intrest > 0) { Intrest = intrest; }
        else { Intrest = 8; }
        //This property sets the maximum age if it is greater than 0 and less than 75, otherwise sets it to 55 by default
        if (maxAge > 0 && maxAge < 75){ MaxAge = maxAge;}
        else{MaxAge = 55;}
        //This property sets the minimum age if it is greater than 18, otherwise sets it to 25 by default
        if (minAge >18) { MinAge = minAge; }
        else { MinAge = 25; }
        //This property sets the premium amount to value if it is greater than 0, otherwise sets it to 30000 by default.
        if (premiumAmt > 0) { PremiumAmt = premiumAmt; }
        else { PremiumAmt = 30000; }
        //This property sets the term to value if it is greater than 0, otherwise sets it to 6 years by default
        if (term > 0){  Term = term; }
        else {  Term = 6; }
        PolicyName = policyName;

    }

}


class Agent
{
    public List<Insurance> ListOfInsurance;

    public Agent()
    {
        // Insurance(double intrest, int maxAge, int minAge, double premiumAmt, int term)
        ListOfInsurance = new List<Insurance> {
        new Insurance(8.0, 50,28,30000,6,"Saving Insurance"),
        new Insurance(7.8, 30,29,45000,6,"Life Plan Insurance"),
        new Insurance(9.0, 35,17,40000,9, "Gadget Insuranve"),
        new Insurance(10.0, 45,36,60000,12,"Bike Insurance")
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        Agent agent = new Agent();
        foreach(var Insurance in agent.ListOfInsurance)
        {
            Console.WriteLine($"Poicy Name : {Insurance.PolicyName},  Intrest : {Insurance.Intrest}, MaxAge: {Insurance.MaxAge}, MinAge : {Insurance.MinAge}, PremiumAmount : {Insurance.PremiumAmt}, Term : {Insurance.Term} ");
        }

    }


}