using System;
using System.Collections.Generic;

namespace bangazon {
    public class Employee
    {
        private string _firstName;
        private string _lastName;

        public string FullName {get {return _firstName + " " + _lastName;}}

        public Employee(string first, string last){
            _firstName = first;
            _lastName = last;
        }

        //all employees are given this general list. Items can be added or removed based on each employee's preferences
        public List<string> restaurants {get; set; } = new List<string>(){
            "Applebees",
            "TGIFridays",
            "McDonalds",
            "Taco Bell"
        };

        public List<Employee> companions {get; set; } = new List<Employee>();

        private string whereToEat(){
            // new instance of random class
            Random random = new Random();
            // number of items in the list minus one to indicate the maxIndex
            int maxIndex = (restaurants.Count) - 1;
            // returns a restaurant at a random index
            return restaurants[random.Next(maxIndex)];
        }

        private string whoToEatWith(List<Employee> companions){
            List<string> friends = new List<string>();

            //for each companion add their first name to the friends list
            foreach(Employee person in companions){
                friends.Add(person._firstName);
            }
            
            if(friends.Count == 0){
                //if employee has no friends then return "no one"
                return "no one";
            } else if(friends.Count == 1){
                // if employee has one friend then return just that one person
                return friends[0];
            } else {
                // if employee has multiple friends then return string of their names separated with a comma and an "and" before the last one
                return string.Join(", ", friends.ToArray(), 0, friends.Count - 1) + " and " + friends[friends.Count - 1];
            }

        }

        public void eat(){
            // Will select a random restaurant name from a list of strings, print to console that the employee is at that restaurant, and also return the restaurant.
            string eatHere = whereToEat();

            Console.WriteLine($"{_firstName} is eating lunch at {eatHere}");

        }

        public void eat(string food) {
            // Will output that the employee ate that specific food at the office.
            Console.WriteLine($"{_firstName} ate {food} at the office");
        }

        public void eat(List<Employee> companions){
            // Will select a random restaurant name from a list of strings, print to console that the employee is at that restaurant, and also output the first name of each employee in the specified list.
            string eatHere = whereToEat();
            string eatWith = whoToEatWith(companions);

            Console.WriteLine($"{_firstName} is eating lunch at {eatHere} with {eatWith}");
        }

        public void eat(string food, List<Employee> companions) {
            // Will select a random restaurant name from a list of strings, print to console that the employee at that restaurant, and ordered the specified food, with the first name of the teammates specified in the list.
            string eatHere = whereToEat();
            string eatWith = whoToEatWith(companions);

            Console.WriteLine($"{_firstName} is eating {food} at {eatHere} with {eatWith}");
        }
    }
}