public class Agent
{
    public List<Insurance> InsuranceList { get; set; } = new List<Insurance>();

    public void AddPolicy(Insurance insurance)
    {
        if (InsuranceList == null)
        {
            InsuranceList = new List<Insurance>();
        }

        if (!InsuranceList.Any(i => i.InsuranceId == insurance.InsuranceId))
        {
            InsuranceList.Add(insurance);
        }
    }

    public Insurance SearchPolicy(string insuranceId)
    {
        return InsuranceList.FirstOrDefault(i => i.InsuranceId == insuranceId);
    }

    public void DeletePolicy(string insuranceId)
    {
        var insurance = SearchPolicy(insuranceId);
        if (insurance != null)
        {
            InsuranceList.Remove(insurance);
        }
    }
}