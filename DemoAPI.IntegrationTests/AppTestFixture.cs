using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.IntegrationTests
{
    public class AppTestFixture : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {

        }
    }
}
