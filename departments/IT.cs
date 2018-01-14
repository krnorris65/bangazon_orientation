// both of type InfoTech AND Department-inheritance denotes an is-a relationship.

using System;
using System.Collections.Generic;

namespace bangazon {
    public class InfoTech: Department, ICardAccess
    {
        
        private Dictionary<string, string> _hardware = new Dictionary<string, string>();

        public InfoTech(string dept_name, string supervisor, int employees): base(dept_name, supervisor, employees)
        {
        }

        public bool CardAccess {get;} = true;

        // Publicly accessible method to add hardware that the IT department manages (where the hardware is located and what type of equipment it is)
        public void AddHardware(string location, string equipment)
        {

            _hardware.Add(location, equipment);

            foreach(KeyValuePair<string, string> hardware in _hardware)
            {
                Console.WriteLine($"{hardware.Value} in {hardware.Key}");
            }
        }
        public override string meet(string time){
            return $"Team meeting is in the 3rd floor conference room at {time}";
        }       


    }
}