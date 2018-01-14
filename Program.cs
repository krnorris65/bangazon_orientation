using System;
using System.Collections.Generic;

namespace bangazon
{
    // Parent class for all departments
    public class Department
    {
        private string _name;
        private string _supervisor;
        private int _employee_count;
        protected double _budget;

        public string DeptName {get {return _name;}}

        // Constructor method
        public Department(string name, string supervisor, int employeeCount)
        {
            _name = name;
            _supervisor = supervisor;
            _employee_count = employeeCount;
        }

        public string toString() 
        {
            return $"Department: {_name} Supervisor: {_supervisor} # of Employees: {_employee_count} Budget: {_budget}";
        }
        // needed if toString was in the indiviudal departments
            // public string name {get {return _name;}}
            // public string supervisor {get {return _supervisor;}}
            // public int employee_count {get {return _employee_count;}}

        public virtual string meet(string time){
            return $"Team meeting is in the main conference room at {time}";
        }

        public virtual void SetBudget(double budget) {
            _budget = budget;
        }
        private List<Employee> _employee = new List<Employee>();

        public List<Employee> EmployeeList {get {return _employee;}}

        public void AddEmployee(Employee employee){
            _employee.Add(employee);
        }

        public void RemoveEmployee(Employee employee){
            _employee.Remove(employee);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>();

            HumanResources hr = new HumanResources("HR", "Bob", 5);
            InfoTech it = new InfoTech("IT", "John", 3);
            Marketing marketing = new Marketing("Marketing", "Anna", 10);
            

            departments.Add(hr);
            departments.Add(it);
            departments.Add(marketing);

            //methods of each department
            // hr.AddPolicy("Smoking", "No smoking inside the building");
            // it.AddHardware("Marketing", "laptop");
            // marketing.AddMaterial("Brochures", 100);

            // marketing.UseMaterial("Flyers", 30);
            // marketing.UseMaterial("Brochures", 25);

            // sets base budget
            double baseBudget = 75000.00;

            //creates new employees
            Employee bob = new Employee("Bob", "Jones");
            Employee jessica = new Employee("Jessica", "Doe");
            MarketingPTEmployee george = new MarketingPTEmployee("George", "Lane");
            HREmployee fred = new HREmployee("Fred", "Dark");

            //adds employees that bob eats lunch with to bob's companion list
            bob.companions.Add(jessica);
            bob.companions.Add(george);

            // bob.eat("burgers", bob.companions);

            fred.Salary = 20;
            Console.WriteLine("fred salary: $" + fred.Salary);

            george.HourlyRate = 13;
            Console.WriteLine("george weekly pay: $" + george.PayForHours(20));


            hr.AddEmployee(fred);
            marketing.AddEmployee(jessica);
            hr.AddEmployee(bob);
            it.AddEmployee(george);

            
            foreach(Department d in departments)
            {
                Console.WriteLine($"Department: {d.DeptName}");
                foreach(Employee e in d.EmployeeList){
                    Console.WriteLine($"    {e.FullName}");
                }
            }

            foreach(Department d in departments)
            {
                d.SetBudget(baseBudget);
                Console.WriteLine($"{d.toString()}");
            }


        }
    }
}
