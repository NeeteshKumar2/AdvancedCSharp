using System;
using System.Collections.Generic;

public class HealthClub
{
    public List<string> EmployeeIdList { get; set; } = new List<string>();

    public void AddEmployee(string employeeId)
    {
        EmployeeIdList.Add(employeeId);
    }

    public bool DeleteEmployee(string employeeId)
    {
        if (EmployeeIdList.Contains(employeeId))
        {
            EmployeeIdList.Remove(employeeId);
            return true;
        }
        return false;
    }
}