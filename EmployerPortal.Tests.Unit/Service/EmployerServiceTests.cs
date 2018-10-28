using EmployerPortal.Common.Models;
using EmployerPortal.Service;
using EmployerPortal.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployerPortal.Tests.Unit.Service
{
    [TestClass]
    public class EmployerServiceTests
    {
        private IEmployerService employerService;
               
        public EmployerServiceTests()
        {
                                
        }
       
        [TestMethod]
        public void WhenCalled_GetAllEmployers_ReturnsValidListOfEmployers()
        {
            //Arrange
            var employers = new List<Employer>
            {
                new Employer
                {
                    EmployerName = "Test"
                }
            };

            var httpClient = CreateHttpClient(HttpStatusCode.OK,employers);
            employerService = new EmployerService(httpClient);

            // ACT
           
            var actualResult = employerService.GetAllEmployers();

            //Assert

            Assert.AreEqual(1, actualResult.Count);
        }

        [TestMethod]
        public void WhenCalled_GetAllEmployers_ReturnsEmptyEmployerList()
        {
            //Arrange
           

            var httpClient = CreateHttpClient(HttpStatusCode.Unauthorized, new List<Employer>());
            employerService = new EmployerService(httpClient);

            // ACT

            var actualResult = employerService.GetAllEmployers();

            //Assert

            Assert.AreEqual(0, actualResult.Count);
        }

        [TestMethod]
        public void WhenValidInputProvided_GetAllEmployeesForEmployer_ReturnsValidListOfEmployees()
        {
            //Arrange
            var employees = new List<Employee>
            {
                new Employee
                {
                    FirstName = "Test"
                }
            };

            var httpClient = CreateHttpClient(HttpStatusCode.OK, employees);
            employerService = new EmployerService(httpClient);

            // ACT

            var actualResult = employerService.GetAllEmployeesForEmployer(10001);

            //Assert

            Assert.AreEqual(1, actualResult.Count);
            
        }

        [TestMethod]
        public void WhenInValidInputProvided_GetAllEmployeesForEmployer_ReturnsEmptyListOfEmployees()
        {
            //Arrange
          

            var httpClient = CreateHttpClient(HttpStatusCode.BadRequest, new List<Employee>());
            employerService = new EmployerService(httpClient);

            // ACT

            var actualResult = employerService.GetAllEmployeesForEmployer(-1);

            //Assert

            Assert.AreEqual(0, actualResult.Count);

        }

        [TestMethod]
        public void WhenServiceReturnsUnexpectedResponse_GetAllEmployeesForEmployer_ReturnsEmptyListOfEmployees()
        {
            //Arrange          

            var httpClient = CreateHttpClient(HttpStatusCode.Unauthorized, new List<Employee>());
            employerService = new EmployerService(httpClient);

            // ACT

            var actualResult = employerService.GetAllEmployeesForEmployer(1009);

            //Assert

            Assert.AreEqual(0, actualResult.Count);

        }

        private HttpClient CreateHttpClient(HttpStatusCode statusCode,object response)
        {
            var message = new FakeHttpMessageHandler(new HttpResponseMessage()
            {
                StatusCode = statusCode,
                Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, "application/json")
            });

            var httpClient = new HttpClient(message)
            {
                BaseAddress = new Uri("http://test.com/")
            };

            return httpClient;

        }
    }
}
