using System;

namespace bangazon {
    public class MarketingPTEmployee: Employee, IPartTime
    {
        public MarketingPTEmployee(string first, string last): base(first, last)
        {
        }
        private double _hourlyRate;

        public double HourlyRate 
        { 
            get { return _hourlyRate; } 
            set {
                // We pay Marketing people between $9/hr and $28/hr
                if (value >= 9 && value <= 28)
                {
                    //full-time people work 2080 hrs per year
                    _hourlyRate = value ;
                } else {
                    // If the value is not in the required range, throw
                    // and exception that the external code and catch
                    throw new ArgumentOutOfRangeException("Cannot set hourly rate to value specified");

                }
            }
        } 

        public double PayForHours(double hours){
            return hours * _hourlyRate;
        }
    }
}
