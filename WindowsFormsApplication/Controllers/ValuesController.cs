using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ValuesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("health")]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Healthy";
        }

        [HttpPost("StartGame")]
        public ActionResult StartGame([FromBody] Game gameInfo)
        {
            Program.MenuForm.Invoke(new Action(() =>
            {
                Program.MenuForm.StartGame(gameInfo);
            }));
            return NoContent();
        }
    }
}