// both of type HumanResources AND Department-inheritance denotes an is-a relationship.

using System;
using System.Collections.Generic;

namespace bangazon {
    public class HumanResources: Department, ICardAccess
    {
        
        private Dictionary<string, string> _policies = new Dictionary<string, string>();

        /*
            Since the parent class defined a constructor with three
            arguments, the derived class must also define a constructor
            with the same signature, or arity, as the parent.

            Then, we can just pass those argument value directly to the
            parent class with the `base` keyword.
        */
        public HumanResources(string dept_name, string supervisor, int employees): base(dept_name, supervisor, employees)
        {
        }

        public bool CardAccess { get;} = true;

        // Publicly accessible method to add an HR policy
        public void AddPolicy(string title, string text)
        {

            _policies.Add(title, text);

            foreach(KeyValuePair<string, string> policy in _policies)
            {
                Console.WriteLine($"{policy.Value}");
            }
        }
        public override string meet(string time){
            return $"Team meeting is in the HR meeting room at {time}";
        }

        public override void SetBudget(double budget)
        {
            // The hr department needs less money than most others
            this._budget =  budget - 5000.00;
        }
        
        // moved to Department class so that it can be inherited by all departments
        // public string toString() 
        // {
        //     return $"{name} {supervisor} {employee_count}";
        // }

    }
}