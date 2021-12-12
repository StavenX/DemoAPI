using DemoAPI.Routes;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DemoAPI.Tests
{
    public class ApiRoutesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ApiRoutesTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact] 
        public async Task GET_RetrievesAllPlayers_ResponseIsHttpOK()
        {
            var response = await _client.GetAsync(ApiRoutes.Players.GetAll);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GET_RetrievesAllScores_ResponseIsHttpOK()
        {
            var response = await _client.GetAsync(ApiRoutes.Scores.GetAll);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GET_RetrievesAllScores_ResponseIsHttpOK()
        {
            var requestMessage = new HttpRequestMessage(ApiRoutes.Players.Add);
            requestMessage.Content = new StringContent("{\"name\":\"John Doe\"}", Encoding.UTF8, "application/json");

            var response = _client.SendAsync(requestMessage);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
