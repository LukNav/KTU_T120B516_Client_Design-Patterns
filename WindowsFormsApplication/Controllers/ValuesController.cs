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

        //DAR NEBAIGTAS, SCUFFED AF. - Maksas
        [HttpPost("GetGameState")]
        public ActionResult GetGameState([FromBody] string text)
        {
            Program.GameForm.Invoke(new Action(() =>
            {
                Program.GameForm.GetGameState();
            }));
            return NoContent();
        }

        //DAR NEBAIGTAS, SCUFFED AF. - Maksas
        [HttpPost("UpdateGameState")]
        public ActionResult UpdateGameState([FromBody] string text)
        {
            Program.GameForm.Invoke(new Action(() =>
            {
                Program.GameForm.UpdateGameState();
            }));
            return NoContent();
        }
    }
}