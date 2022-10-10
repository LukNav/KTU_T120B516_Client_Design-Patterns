using System.Text.Json;
using Microsoft.Net.Http.Headers;
using WindowsFormsApplication.Controllers;
using WindowsFormsApplication.Helpers;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication
{
    public partial class MenuForm : Form
    {
        public static string PlayerName { get; private set; }
        public MenuForm()
        {
            InitializeComponent();
        }

        private void SubmitNameButton_Click(object sender, EventArgs e)
        {
            PlayerName = Program.MenuForm.NameTextBox.Text;
            if (!string.IsNullOrEmpty(PlayerName))//if anything is entered in the name textbox
            {
                if (TryCreateClient(PlayerName, Program.LocalHostPort) == true)//try sending request to server and create a new player
                {
                    HideLoginItems();//Hide Ui login labels
                    ToggleReadyToPlayUIItems(true);//Show Ready to play button and label in UI
                }
                else
                    return;
            }
            else
                Program.MenuForm.ErrorLabel.Text = "Please enter a Name and then click Start Session";
        }

        private void ReadyButton_Click(object sender, EventArgs e)
        {
            SetPlayerAsReady(PlayerName);//Set Player as ready in Server
            ToggleReadyToPlayUIItems(false);//Hide Ready button
            ShowWaitingForPlayerLabel(true);//Show "Waiting for players" label
            
            //Now we wait for server's response that everybody is ready
        }

        public void StartGame(Game game)
        {
            Program.MenuForm.Visible = false;
            Program.GameForm.Visible = true;
            Program.GameForm.StartGame(game);
        }
        #region UI controls

        private void HideLoginItems()
        {
            Program.MenuForm.SubmitNameButton.Visible = false;
            Program.MenuForm.EnterNameLabel.Visible = false;
            Program.MenuForm.NameTextBox.Visible = false;
            Program.MenuForm.ErrorLabel.Visible = false;
        }

        private void ToggleReadyToPlayUIItems(bool isVisible)
        {
            Program.MenuForm.ReadyToPlayButton.Visible = isVisible;
            Program.MenuForm.ReadyToPlayLabel.Visible = isVisible;
        }

        private void ShowWaitingForPlayerLabel(bool isVisible)
        {
            Program.MenuForm.WaitingForPlayersLabel.Visible = isVisible;
        }

        #endregion

        #region HttpRequests

        private bool TryCreateClient(string name, string localhostPort)
        {
            string serverUrl = $"{Program.ServerIp}/Player/Create/{name}/{localhostPort}";

            HttpResponseMessage httpResponseMessage = HttpRequests.GetRequest(serverUrl);
            string responseMessage = httpResponseMessage.Message();

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                Program.MenuForm.ErrorLabel.Text = responseMessage;

            return false;
        }

        //private Game GetGameInfo()
        //{
        //    string serverUrl = $"{Program.ServerIp}/Game";
        //    HttpResponseMessage httpResponseMessage = HttpRequests.GetRequest(serverUrl);
        //    return httpResponseMessage.Deserialize<Game>();
        //}

        private void SetPlayerAsReady(string name)
        {
            string serverUrl = $"{Program.ServerIp}/Player/SetAsReady/{name}";
            HttpRequests.GetRequest(serverUrl);
        }

        #endregion

        private void MenuForm_Load(object sender, EventArgs e)
        {
            this.Name = $"Menu: {Program.LocalHostPort}";
            this.Text = $"Menu: {Program.LocalHostPort}";
        }

        private void DebugButton_Click(object sender, EventArgs e)
        {
            string serverUrl = $"{Program.ServerIp}/Debug/StartGameSolo/{Program.LocalHostPort}";
            HttpRequests.GetRequest(serverUrl);
        }
    }
}