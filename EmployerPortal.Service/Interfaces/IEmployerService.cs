using EmployerPortal.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployerPortal.Service.Interfaces
{
    public interface IEmployerService
    {
        List<Employer> GetAllEmployers();

        List<Employee> GetAllEmployeesForEmployer(int employerId);

    }
}
