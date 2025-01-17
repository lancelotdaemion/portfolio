using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Portfolio.Model;
using Portfolio.Api.Hubs;
using Microsoft.Extensions.Configuration;

namespace Portfolio.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TestController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("api/secret")]
        public string? GetSecret(string secretName)
        {
            return _configuration[secretName];
        }
    }
}