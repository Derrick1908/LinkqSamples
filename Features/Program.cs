using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach (var person in developers)
            {
                Console.WriteLine(person.Id + ":" + person.Name);
            }

            foreach (var person in sales)
            {
                Console.WriteLine(person.Id + ":" + person.Name);
            }

            IEnumerator<Employee> enumerator = advertising.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Id + ":" + enumerator.Current.Name);
            }

            enumerator = management.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Id + ":" + enumerator.Current.Name);
            }
            Console.ReadKey();
        }
    }
}
