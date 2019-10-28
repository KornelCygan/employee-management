﻿using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Contracts;

namespace EmployeeManagement.Models
{
    public class FullTimeEmployee: IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public string GetEmailAddress()
        {
           return $"{FirstName}{LastName}@mail.pl";
        }

        public decimal CalculateCost()
        {
            return Salary * 1.5m;
        }

        public string GetEmploymentType()
        {
            return "Full Time";
        }
    }
}
