using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployerPortal.Common.Models;
using EmployerPortal.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployerPortalApp.Controllers
{
    /// <summary>
    /// Secured page loaded after initial login succeeds
    /// </summary>
    [Authorize]
    public class DirectoryController : Controller
    {
        private readonly IEmployerService employerService;       
        public DirectoryController(IEmployerService employerService)
        {
            this.employerService = employerService;          
        }
        
        /// <summary>
        /// Calls service to get all the employers for logged in user
        /// </summary>
        /// <returns></returns>
        public IActionResult Employer()
        {
            var model = new List<Employer>();            
            model = employerService.GetAllEmployers();
            return View(model);
        }

        /// <summary>
        /// Calls service to get the list of employees under the selected employer from grid
        /// </summary>
        /// <param name="employerId"></param>
        /// <returns></returns>
        public IActionResult Employee(int employerId)
        {
            var model = new List<Employee>();           
            model = employerService.GetAllEmployeesForEmployer(employerId);
            return PartialView(model);
        }
    }
}