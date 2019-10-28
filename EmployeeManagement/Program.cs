using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Contracts;
using EmployeeManagement.Models;

namespace EmployeeManagement
{
    class Program
    {
        // this is the list 
        private static List<IEmployee> employees = new List<IEmployee>();

        static void Main(string[] args)
        {
            ConsoleKeyInfo adminAction;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Action?");
                Console.WriteLine("Add / Remove / View");

                adminAction = Console.ReadKey();

                switch (adminAction.KeyChar)
                {
                    case 'a':
                        {
                            Console.WriteLine();
                            Console.WriteLine("First Name:");
                            var firstName = Console.ReadLine();
                            Console.WriteLine("Last Name:");
                            var lastName = Console.ReadLine();
                            Console.WriteLine("Salary:");
                            decimal salary = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("Type of employee: Contractor or Full Time");
                            var type = Console.ReadLine();
                            AddEmployee(firstName, lastName, salary, type);
                        }
                        break;
                    case 'r':
                        {
                            Console.WriteLine();
                            Console.WriteLine("First Name:");
                            var firstName = Console.ReadLine();
                            Console.WriteLine("Last Name:");
                            var lastName = Console.ReadLine();
                            RemoveEmployee(firstName, lastName);
                        }
                        break;

                    case 'v':
                        {
                            Console.WriteLine();
                            ViewEmployees();
                        }
                        break;
                }
            }
            while (adminAction.Key != ConsoleKey.Escape );
            
        }

        private static void AddEmployee(string FirstName, string LastName, decimal Salary, string Type)
        {
            if (Type == "Full Time")
            {
                var newEmployee = new FullTimeEmployee()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Salary = Salary,
                };

                employees.Add(newEmployee);
            }

            if (Type == "Contractor")
            {
                var newEmployee = new ContractorEmployee()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Salary = Salary,
                };

                employees.Add(newEmployee);
            }
        }

        private static void RemoveEmployee(string FirstName, string LastName)
        {
            // should remove an employee from the employees list
            employees.RemoveAll(x => x.FirstName == FirstName && x.LastName == LastName);
        }

        private static void ViewEmployees()
        {
            for(var i = 0; i < employees.Count; i++)
            {
                var employee = employees.ElementAt(i);
                Console.WriteLine($"{i+1}.");
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
                Console.WriteLine(employee.GetEmailAddress());
                Console.WriteLine($"Salary:{employee.Salary}");
                Console.WriteLine($"Employment cost:{employee.CalculateCost()}");
                Console.WriteLine($"Employment type: {employee.GetEmploymentType()}");
            }
        }
    }
}
