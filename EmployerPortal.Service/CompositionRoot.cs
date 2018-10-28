using EmployerPortal.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EmployerPortal.Service
{
    public static class CompositionRoot
    {
        public static void AddEmployerService(this IServiceCollection serviceCollection)
        {            
            serviceCollection.AddTransient<IEmployerService>(sp =>
            {
                var httpClient = sp.GetRequiredService<HttpClient>();
                return new EmployerService(httpClient);
            });

        }
    }
}
