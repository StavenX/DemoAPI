using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DemoAPI.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            TestClient = appFactory.CreateClient();
        }
    }
}
