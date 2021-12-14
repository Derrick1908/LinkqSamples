using System;
using System.Collections.Generic;
using Features.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] developers = new Employee[]
            {
                new Employee{ Id = 1, Name = "Scott" },
                new Employee{ Id = 2, Name = "Chris" }
            };

            IEnumerable<Employee> advertising = new Employee[]
            {
                new Employee{ Id = 4, Name = "Evans" },
                new Employee{ Id = 5, Name = "Ridley" }
            };

            List<Employee> sales = new List<Employee>()
            {
                new Employee{ Id = 3, Name = "Alex" }
            };

            IEnumerable<Employee> management = new List<Employee>()
            {
                new Employee{ Id = 6, Name = "Stark"}
            };

            Console.WriteLine($"Number of Employees in Developers Dept : {developers.Count()}");        //Using the Extension Method that we have defined. If we use Linq directive also, it will give an error becoz of Ambiguous Call.
            foreach (var person in developers)
            {
                Console.WriteLine("Id "+ person.Id + ": " + person.Name);
            }

            Console.WriteLine($"Number of Employees in Sales Dept : {sales.Count()}");   
            foreach (var person in sales)
            {
                Console.WriteLine("Id " + person.Id + ": " + person.Name);
            }

            Console.WriteLine($"Number of Employees in Advertising Dept : {advertising.Count()}"); 
            IEnumerator<Employee> enumerator = advertising.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("Id " + enumerator.Current.Id + ": " + enumerator.Current.Name);
            }

            Console.WriteLine($"Number of Employees in Management Dept : {management.Count()}");
            enumerator = management.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("Id " + enumerator.Current.Id + ": " + enumerator.Current.Name);
            }
            Console.ReadKey();
        }
    }
}
