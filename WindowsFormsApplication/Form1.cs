using System.Text.Json;
using Microsoft.Net.Http.Headers;
using WindowsFormsApplication.Controllers;
using WindowsFormsApplication.Helpers;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public static string PlayerName { get; private set; }
        public static Game CurrentGame { get; private set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void SubmitNameButton_Click(object sender, EventArgs e)
        {
            PlayerName = Program.MainForm.NameTextBox.Text;
            if (!string.IsNullOrEmpty(PlayerName))//if anything is entered in the name textbox
            {
                if (TryCreateClient(PlayerName) == true)//try sending request to server and create a new player
                {
                    HideLoginItems();//Hide Ui login labels
                    ToggleReadyToPlayUIItems(true);//Show Ready to play button and label in UI
                }
                else
                    return;
            }
            else
                Program.MainForm.ErrorLabel.Text = "Please enter a Name and then click Start Session";
        }

        private void ReadyButton_Click(object sender, EventArgs e)
        {
            SetPlayerAsReady(PlayerName);//Set Player as ready in Server
            ToggleReadyToPlayUIItems(false);//Hide Ready button
            ToggleWaitingForPlayerUiItems(true);//Show "Waiting for players" label
            
            //Now we wait for server's response that everybody is ready

            //CurrentGame = GetGameInfo();//Get current Game info from Server
            //SetGameInfo(CurrentGame);//Update game info in UI
            //ShowGamePlayersLabels();//Enable visibility of game info in UI
        }
        #region UI controls

        private static void HideLoginItems()
        {
            Program.MainForm.SubmitNameButton.Visible = false;
            Program.MainForm.EnterNameLabel.Visible = false;
            Program.MainForm.NameTextBox.Visible = false;
        }
        private void ShowGamePlayersLabels()
        {
            Program.MainForm.Player1Label.Visible = true;
            Program.MainForm.Player2Label.Visible = true;
            Program.MainForm.Player1Name.Visible = true;
            Program.MainForm.Player2Name.Visible = true;
        }

        private void ToggleReadyToPlayUIItems(bool isVisible)
        {
            Program.MainForm.ReadyToPlayButton.Visible = isVisible;
            Program.MainForm.ReadyToPlayLabel.Visible = isVisible;
        }

        private void SetGameInfo(Game game)
        {

            Program.MainForm.Player1Name.Text = game.Player1.Name;
            Program.MainForm.Player2Name.Text = game.Player2.Name;
        }

        private void ToggleWaitingForPlayerUiItems(bool isVisible)
        {
            Program.MainForm.WaitingForPlayersLabel.Visible = isVisible;
        }

        #endregion

        #region HttpRequests

        private bool TryCreateClient(string name)
        {
            string serverUrl = $"{Program.ServerIp}/Player/Create/{name}";

            HttpResponseMessage httpResponseMessage = HttpRequests.GetRequest(serverUrl);
            string responseMessage = httpResponseMessage.Message();

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                Program.MainForm.ErrorLabel.Text = responseMessage;

            return false;
        }

        private Game GetGameInfo()
        {
            string serverUrl = $"{Program.ServerIp}/Game";
            HttpResponseMessage httpResponseMessage = HttpRequests.GetRequest(serverUrl);
            return httpResponseMessage.Deserialize<Game>();
        }

        private void SetPlayerAsReady(string name)
        {
            string serverUrl = $"{Program.ServerIp}/Player/SetAsReady/{name}";
            HttpRequests.GetRequest(serverUrl);
        }

        #endregion
    }
}