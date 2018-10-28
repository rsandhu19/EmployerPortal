using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployerPortal.Tests.Unit
{
    public class FakeHttpMessageHandler : DelegatingHandler
    {
        private HttpResponseMessage fakeResponse;

        public FakeHttpMessageHandler(HttpResponseMessage responseMessage)
        {
            fakeResponse = responseMessage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(fakeResponse);
        }
    }
}
