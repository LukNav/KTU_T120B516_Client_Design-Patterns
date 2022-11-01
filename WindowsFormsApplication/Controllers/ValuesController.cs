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
        [HttpGet("GetGameState")]
        public ActionResult<GameState> GetGameState()
        {
            return Ok(Program.GameForm.GetGameState());
        }

        //DAR NEBAIGTAS, SCUFFED AF. - Maksas
        [HttpPost("UpdateGameState")]
        public ActionResult UpdateGameState([FromBody] GameState gameState)
        {
            Program.GameForm.Invoke(new Action(() =>
            {
                Program.GameForm.LoadGameState(gameState);
            }));
            return NoContent();
        }
    }
}