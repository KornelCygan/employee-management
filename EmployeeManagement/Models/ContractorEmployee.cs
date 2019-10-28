using EmployeeManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models
{
    class ContractorEmployee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public decimal CalculateCost()
        {
            return Salary * 1.3m;
        }

        public string GetEmailAddress()
        {
            return $"{FirstName}{LastName}@mail.pl";
        }

        public string GetEmploymentType()
        {
            return "Contractor";
        }
    }
}
