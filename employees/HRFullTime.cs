using System;

namespace bangazon {
public class HREmployee: Employee, IFullTime
{
    public HREmployee(string first, string last): base(first, last)
    {
    }
    
    // Private field
    private double _salary;

    // Public property with accessor/mutator
    public double Salary
    {
        get { return _salary; }
        set
        {
            // We pay HR people between $10/hr and $35/hr
            if (value >= 10 && value <= 35)
            {
                //full-time people work 2080 hrs per year
                _salary = value * 2080;
            } else {
                // If the value is not in the required range, throw
                // and exception that the external code and catch
                throw new ArgumentOutOfRangeException("Cannot set salary to value specified");

            }
        }
    }

}

}