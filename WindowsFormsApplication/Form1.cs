using System.Text.Json;
using Microsoft.Net.Http.Headers;
using WindowsFormsApplication.Controllers;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SubmitNameButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Program.MainForm.NameTextBox.Text))
                CreateClient(Program.MainForm.NameTextBox.Text);
        }

        private void CreateClient(string name)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{Program.ServerIp}/Player/Create/{name}")
            {
                Headers =
                {
                    { HeaderNames.Accept, "*/*" },
                    { HeaderNames.UserAgent, "ButtNet" }
                }
            };

            
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                var httpResponseMessage = httpClient.Send(httpRequestMessage).HandleResponse();

                var contentStream = httpResponseMessage.Content.ReadAsStringAsync().Result;
                responseImage = JsonSerializer.Deserialize<ImageFile>(contentStream, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return responseImage;
        }
    }
}