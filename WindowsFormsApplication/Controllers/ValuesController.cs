using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace WindowsFormsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ValuesController(IHttpClientFactory httpClientFactory)
        {

        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            string text = "";
            Program.MainForm.Invoke(new Action(() =>
            {
                text = Program.MainForm.NameTextBox.Text;
            }));
            return text;
        }

        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            Program.MainForm.Invoke(new Action(() =>
            {
                Program.MainForm.NameTextBox.Text = id;
            }));
            return Ok();
        }
    }
}