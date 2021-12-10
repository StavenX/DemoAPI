using DemoAPI.Contracts;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoAPI.IntegrationTests
{
    public class PlayerControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            var response = await TestClient.GetAsync(ApiRoutes.Players.GetAll);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
