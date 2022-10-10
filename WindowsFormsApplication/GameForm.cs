using System.Text.Json;
using Microsoft.Net.Http.Headers;
using WindowsFormsApplication.Controllers;
using WindowsFormsApplication.Helpers;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication
{
    public partial class GameForm : Form
    {
        public static string PlayerName { get; private set; }
        public static Game CurrentGame { get; private set; }
        public GameForm()
        {
            InitializeComponent();
        }

        public void StartGame(Game game)
        {
            Program.MenuForm.Visible = false;
            Program.GameForm.Visible = true;
            CurrentGame = game;
            SetGameInfo(CurrentGame);//Update game info in UI
        }
        #region UI controls

       

        private void SetGameInfo(Game game)
        {
            UpdatePlayersColorsAndNames(game);
            UpdateSpawnablePawns(game.GameLevel);
        }

        private void UpdateSpawnablePawns(GameLevel gameLevel)
        {
            Pawn1Picture.Image = FileUtils.GetImage(gameLevel.Pawn1.ImageName);
            Pawn2Picture.Image = FileUtils.GetImage(gameLevel.Pawn2.ImageName);
            Pawn3Picture.Image = FileUtils.GetImage(gameLevel.Pawn3.ImageName);
        }

        private static void UpdatePlayersColorsAndNames(Game game)
        {
            Program.GameForm.Player1Name.Text = game.Player1.Name;
            Program.GameForm.Player1FactionColor.BackColor = Color.FromKnownColor(game.Player1.PlayerColor);
            Program.GameForm.Player2Name.Text = game.Player2.Name;
            Program.GameForm.Player2FactionColor.BackColor = Color.FromKnownColor(game.Player2.PlayerColor);

            if (game.Player1.Name == PlayerName)
            {
                Program.GameForm.Player1Label.Text += " (You)";
                Program.GameForm.Player2Label.Text += " (Oponnent)";
            }
            else
            {
                Program.GameForm.Player2Label.Text += " (You)";
                Program.GameForm.Player1Label.Text += " (Oponnent)";
            }
        }

        #endregion

        #region HttpRequests

        private Game GetGameInfo()
        {
            string serverUrl = $"{Program.ServerIp}/Game";
            HttpResponseMessage httpResponseMessage = HttpRequests.GetRequest(serverUrl);
            return httpResponseMessage.Deserialize<Game>();
        }

        #endregion

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.Size= new Size(1200, 1200);
            int tileWidth = 30;
            int tileHeight = 30;
            int tileRows = 30;
            int tileCols = 30;

            using (Bitmap sourceBmp = new Bitmap("D:\\900x900.jpg"))
            {
                Size s = new Size(tileWidth, tileHeight);
                Rectangle destRect = new Rectangle(Point.Empty, s);
                for (int row = 0; row < tileRows; row++)
                    for (int col = 0; col < tileCols; col++)
                    {
                        PictureBox p = new PictureBox();
                        p.Size = s;
                        Point loc = new Point(tileWidth * col, tileHeight * row);
                        Rectangle srcRect = new Rectangle(loc, s);
                        Bitmap tile = new Bitmap(tileWidth, tileHeight);
                        Graphics G = Graphics.FromImage(tile);
                        G.DrawImage(sourceBmp, destRect, srcRect, GraphicsUnit.Pixel);
                        p.Image = tile;
                        p.Location = loc;
                        p.Tag = loc;
                        p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
                        p.Text = $"Col:{col} x Row:{row}";
                        // p.MouseDown += p_MouseDown;
                        // p.MouseUp += p_MouseUp;
                        // p.MouseMove += p_MouseMove;
                        this.Controls.Add(p);
                    }
            }
        }

        private bool _ignoreEventOnCheckedChanged = false;
        private void Pawn1RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEventOnCheckedChanged 
               && Pawn1RadioButton.Checked == false && Pawn2RadioButton.Checked == true 
               || 
               _ignoreEventOnCheckedChanged 
               && Pawn1RadioButton.Checked == false && Pawn3RadioButton.Checked == true)
                return;

            _ignoreEventOnCheckedChanged=true;
            Pawn2RadioButton.Checked=false;
            Pawn3RadioButton.Checked=false;
            _ignoreEventOnCheckedChanged=false;
        }

        private void Pawn2RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEventOnCheckedChanged
               && Pawn2RadioButton.Checked == false && Pawn1RadioButton.Checked == true
               ||
               _ignoreEventOnCheckedChanged
               && Pawn2RadioButton.Checked == false && Pawn3RadioButton.Checked == true)
                return; ;

            _ignoreEventOnCheckedChanged=true;
            Pawn1RadioButton.Checked=false;
            Pawn3RadioButton.Checked=false;
            _ignoreEventOnCheckedChanged=false;
        }

        private void Pawn3RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (_ignoreEventOnCheckedChanged
               && Pawn3RadioButton.Checked == false && Pawn2RadioButton.Checked == true
               ||
               _ignoreEventOnCheckedChanged
               && Pawn3RadioButton.Checked == false && Pawn1RadioButton.Checked == true)
                return;

            _ignoreEventOnCheckedChanged=true;
            Pawn1RadioButton.Checked=false;
            Pawn2RadioButton.Checked=false;
            _ignoreEventOnCheckedChanged=false;
        }
    }
}