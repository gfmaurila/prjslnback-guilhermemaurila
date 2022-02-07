using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Prjslnback.API;
using Prjslnback.API.ViewModels;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace Prjslnback.Tests.Projects.Services
{
    public class AuthTests
    {
        private readonly HttpClient _client;
        
        public AuthTests()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var server = new TestServer(new WebHostBuilder().UseConfiguration(configuration).UseStartup<Startup>());
            _client = server.CreateClient();
        }

        #region Auth
        [Fact]
        public async Task TestAuth()
        {
            var loginViewModel = new LoginViewModel() {
                Login = "gfmaurila",
                Password = "master"
            };

            var json = JsonConvert.SerializeObject(loginViewModel);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync("/api/v1/auth/login", data).Result;

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        #endregion
    }
}
