using DemoAPI.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace DemoAPI.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient TestClient;
        public IntegrationTest()
        {
            /*
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(PlayerContext));
                        services.AddDbContext<PlayerContext>(options =>
                        {
                            options.UseInMemoryDatabase("TestDB");
                        });
                    });
                });
            TestClient = appFactory.CreateClient();*/
        }
    }
}
