using System;
using System.Collections.Generic;
using System.Linq;
//using Features.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;                 //Last argument in the List is the return type. It can receive upto 16 Arguments.
            Func<int, int, int> add = (x, y) => x + y;

            Func<int, int, int> add2 = (x, y) =>            //Can also include a Body for the Function, but note that when we include curly Braces i.e.e Body we have
            {                                               //Include the return Statement.    
                int temp = x + y;
                return temp;
            };
            Action<int> write = x => Console.WriteLine(x);

            write(square(add(5, 3)));

            Employee[] developers = new Employee[]
            {
                new Employee{ Id = 1, Name = "Scott" },
                new Employee{ Id = 2, Name = "Chris" },
                new Employee{ Id = 8, Name = "Nesser" },
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
                new Employee{ Id = 6, Name = "Stark"},
                new Employee{ Id = 7, Name = "Ben"}
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

            //This is used to display Names that start only with S -> Named Method in the Where of LINQ
            Console.WriteLine("Names Starting with S in Developer Dept::");
            foreach (var employee in developers.Where(NameStartsWithS))
            {
                Console.WriteLine(employee.Name);
            }

            //This is used to display Names that start only with R -> Anonymous Method in the Where of LINQ
            Console.WriteLine("Names Starting with R in Advertising Dept::");
            foreach (var employee in advertising.Where(
                delegate(Employee employee)
                { return employee.Name.StartsWith("R"); }
                ))
            {
                Console.WriteLine(employee.Name);
            }


            //This is used to display Names that start only with S -> Lambda Expression in the Where of LINQ
            Console.WriteLine("Names Starting with S in Management Dept::");
            foreach (var employee in management.Where(e => e.Name.StartsWith("S")))                
            {
                Console.WriteLine(employee.Name);
            }

            Console.WriteLine("Sorting of All Employees in the Developer Dept (Name Length is 5 Letters only) by Ascending Order ");
            foreach (var employee in developers.Where(e => e.Name.Length == 5)
                                               .OrderBy(e => e.Name))
            {
                Console.WriteLine(employee.Name);
            }

            Console.ReadKey();
        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }
    }
}
