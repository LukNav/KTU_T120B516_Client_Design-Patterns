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
            if (!string.IsNullOrEmpty(Program.MainForm.NameTextBox.Text))//if anything is entered
            {
                if(TryCreateClient(Program.MainForm.NameTextBox.Text) == true)
                {
                    Program.MainForm.SubmitNameButton.Visible = false;
                    Program.MainForm.EnterNameLabel.Visible = false;
                    Program.MainForm.NameTextBox.Visible = false;
                }
            }
            else
            {
                Program.MainForm.ErrorLabel.Text = "Please enter a Name and then click Start Session";
            }

        }

        private bool TryCreateClient(string name)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"{Program.ServerIp}/Player/Create/{name}")
            {
                Headers =
                {
                    { HeaderNames.Accept, "*/*" },
                    { HeaderNames.UserAgent, "Client" }
                }
            };

            using (var httpClient = new HttpClient())
            {
                var httpResponseMessage = httpClient.Send(httpRequestMessage);

                var responseMessage = httpResponseMessage.Content.ReadAsStringAsync().Result;
                //var responseMessage = JsonSerializer.Deserialize<string>(contentStream, new JsonSerializerOptions
                //{
                //    PropertyNameCaseInsensitive = true
                //});

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                else
                    Program.MainForm.ErrorLabel.Text = responseMessage;

            }

            return false;
        }
    }
}