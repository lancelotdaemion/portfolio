using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Portfolio.Model;
using Portfolio.Api.Hubs;
using Microsoft.Extensions.Configuration;

namespace Portfolio.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class KeyVaultController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public KeyVaultController(IConfiguration configuration) {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("secret")]
        public string? Secret(string secretName)
        {
            return _configuration[secretName];
        }
    }
}