using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase, IStartGameObserver
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
            return Ok(Program.GameForm.CurrentGameState);
        }


        [HttpPost("BeginPlayersTurn")]
        public ActionResult BeginPlayersTurn([FromBody] GameState enemyGameState)
        {
            Program.GameForm.Invoke(new Action(() =>
            {
                Program.GameForm.BeginPlayersTurn(enemyGameState);
            }));
            return NoContent();
        }

        [HttpPost("SetPlayerData")]
        public ActionResult SetPlayerData([FromBody] GameState myGameState)
        {
            Program.GameForm.Invoke(new Action(() =>
            {
                Program.GameForm.SetPlayerData(myGameState);
            }));
            return NoContent();
        }

        [HttpPost("ChangeLevel")]
        public ActionResult ChangeLevel([FromBody] Game gameInfo)
        {
            Program.GameForm.Invoke(new Action(() =>
            {
                Program.GameForm.ChangeLevel(gameInfo);
            }));
            return NoContent();
        }
    }
}