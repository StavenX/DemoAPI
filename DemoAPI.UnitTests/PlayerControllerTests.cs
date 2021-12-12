using DemoAPI.Routes;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DemoAPI.Tests
{
    public class PlayerControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public PlayerControllerTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact] 
        public async Task GET_RetrievesAllPlayers_ResponseIsHttpOK()
        {
            var response = await _client.GetAsync(ApiRoutes.Players.GetAll);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
