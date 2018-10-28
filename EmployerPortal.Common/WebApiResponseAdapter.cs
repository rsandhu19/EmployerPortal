using EmployerPortal.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployerPortal.Common
{
    /// <summary>
    /// Maps Service Response to corresponding Models
    /// </summary>
    public static class WebApiResponseAdapter
    {
        public static List<Employer> ConvertApiResponseToEmployer(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<Employer>>(json);
        }

        public static List<Employee> ConvertApiResponseToEmployee(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<Employee>>(json);
        }
    }
}
