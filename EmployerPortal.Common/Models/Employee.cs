using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerPortal.Common.Models
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public string WorkPhone { get; set; }

        public bool IsContractor { get; set; }
    }
}
