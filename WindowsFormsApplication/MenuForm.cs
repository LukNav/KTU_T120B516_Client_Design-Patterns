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
        public static Game CurrentGame { get; private set; }
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
            ToggleWaitingForPlayerUiItems(true);//Show "Waiting for players" label
            
            //Now we wait for server's response that everybody is ready
        }

        public void StartGame(Game game)
        {
            CurrentGame = game;
            SetGameInfo(CurrentGame);//Update game info in UI
            ShowGamePlayersLabels();//Enable visibility of game info in UI
            ToggleWaitingForPlayerUiItems(false);
            Program.MenuForm.GameStartedLabel.Visible = true;
        }
        #region UI controls

        private static void HideLoginItems()
        {
            Program.MenuForm.SubmitNameButton.Visible = false;
            Program.MenuForm.EnterNameLabel.Visible = false;
            Program.MenuForm.NameTextBox.Visible = false;
            Program.MenuForm.ErrorLabel.Visible = false;
        }
        private void ShowGamePlayersLabels()
        {
            Program.MenuForm.Player1Label.Visible = true;
            Program.MenuForm.Player2Label.Visible = true;
            Program.MenuForm.Player1Name.Visible = true;
            Program.MenuForm.Player2Name.Visible = true;
            Program.MenuForm.PlayersLabel.Visible = true;
            Program.MenuForm.Player1FactionColor.Visible = true;
            Program.MenuForm.Player2FactionColor.Visible = true;
        }

        private void ToggleReadyToPlayUIItems(bool isVisible)
        {
            Program.MenuForm.ReadyToPlayButton.Visible = isVisible;
            Program.MenuForm.ReadyToPlayLabel.Visible = isVisible;
        }

        private void SetGameInfo(Game game)
        {
            Program.MenuForm.Player1Name.Text = game.Player1.Name;
            Program.MenuForm.Player1FactionColor.BackColor = Color.FromKnownColor(game.Player1.PlayerColor);
            Program.MenuForm.Player2Name.Text = game.Player2.Name;
            Program.MenuForm.Player2FactionColor.BackColor = Color.FromKnownColor(game.Player2.PlayerColor);

            if (game.Player1.Name == PlayerName)
            {
                Program.MenuForm.Player1Label.Text += " (You)";
                Program.MenuForm.Player2Label.Text += " (Oponnent)";
            }
            else
            {
                Program.MenuForm.Player2Label.Text += " (You)";
                Program.MenuForm.Player1Label.Text += " (Oponnent)";
            }
        }

        private void ToggleWaitingForPlayerUiItems(bool isVisible)
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