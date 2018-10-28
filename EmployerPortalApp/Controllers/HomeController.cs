using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EmployerPortal.Common.Models;
using EmployerPortal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployerPortalApp.Models;

namespace EmployerPortalApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // redirect to secure employer portal page
            return RedirectToAction("Employer", "Directory");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Employer()
        //{
        //    var model = new List<Employer>();
        //    var service = new EmployerService();
        //    model = service.GetAllEmployers();
        //    return View(model);
        //}

        //public IActionResult Employee(int id)
        //{
        //    var model = new List<Employee>();
        //    var service = new EmployerService();
        //    model = service.GetAllEmployeesForEmployer(id);
        //    return PartialView(model);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
