// both of type Marketing AND Department-inheritance denotes an is-a relationship.

using System;
using System.Collections.Generic;

namespace bangazon {
    public class Marketing: Department
    {
        private Dictionary<string, int> _promoMaterial = new Dictionary<string, int>();


        public Marketing(string dept_name, string supervisor, int employees): base(dept_name, supervisor, employees)
        {
        }

        // Publicly accessible method to add promotional materials the marketing department uses
        public void AddMaterial(string promo, int quantity)
        {

            _promoMaterial.Add(promo, quantity);

            foreach(KeyValuePair<string, int> material in _promoMaterial)
            {
                Console.WriteLine($"{material.Key}: {material.Value} available");
            }
        }

        public void UseMaterial(string promo, int amount)
        {
            if(_promoMaterial.ContainsKey(promo)) {

                if(_promoMaterial[promo] >= amount){
                    // updates the quantity of the promo material used
                    _promoMaterial[promo] -= amount;

                    //if updating the quantity of the promo material results in the quantity equaling 0, remove it from the dictionary
                    if(_promoMaterial[promo] == 0) {
                        _promoMaterial.Remove(promo);
                    }

                    foreach(KeyValuePair<string, int> material in _promoMaterial)
                    {
                        Console.WriteLine($"Used {amount}. There are now {material.Value} {material.Key} available");
                    }
                } else {
                    // if not enough of the promotional material is available, console writeline the amount that is available
                    Console.WriteLine($"Only {_promoMaterial[promo]} of {promo} is available");
                }
            } else {
                // if the promotional material is not in the dictionary console writeline that it is not available
                Console.WriteLine($"Item({promo}) not available");
            }

        }
        public override string meet(string time){
            return $"Team meeting is in the marketing office at {time}";
        }

        // private double Budget;
        public override void SetBudget(double budget)
        {
            // The marketing department needs more money than most others
            this._budget = budget + 100000.00;
        }

    }
}