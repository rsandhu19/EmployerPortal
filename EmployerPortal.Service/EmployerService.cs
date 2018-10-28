using EmployerPortal.Common;
using EmployerPortal.Common.Models;
using EmployerPortal.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace EmployerPortal.Service
{

    public class EmployerService : IEmployerService
    {     
        private readonly string employerApiUrl = "v1/employer";
        private readonly HttpClient httpClient;

        public EmployerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
           
        }

        public List<Employer> GetAllEmployers()
        {
            var employers = new List<Employer>();

            try
            {

                using (var response = httpClient.GetAsync($"{employerApiUrl}").Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // Service Response schema to be validated before converting into objects
                        employers = WebApiResponseAdapter.ConvertApiResponseToEmployer(response);
                    }
                    else
                    {
                        // In read- world following to be written via Logger (injected into constructor)
                        Console.WriteLine($"Call to get all employers failed with status code {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting employer list with exception : {ex}");
            }

            return employers;

        }

        public List<Employee> GetAllEmployeesForEmployer(int employerId)
        {
            var employees = new List<Employee>();

            try
            {
                
                using (var response = httpClient.GetAsync($"{employerApiUrl}/{employerId}").Result)
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        // Response schema to be validated before converting into objects
                        employees = WebApiResponseAdapter.ConvertApiResponseToEmployee(response);
                    }
                    else
                    {
                        Console.WriteLine($"Call to get all employers failed with status code {response.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting employees list for employers {employerId} with exception : {ex}");
            }
            return employees;

        }

     
        
    }
}
