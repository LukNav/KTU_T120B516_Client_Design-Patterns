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
        private Pawn _selectedSpawnablePawn;

        public GameForm()
        {
            InitializeComponent();
        }

        public void StartGame(Game game)
        {
            Program.MenuForm.Visible = false;
            Program.GameForm.Visible = true;
            CurrentGame = game;
            _selectedSpawnablePawn = CurrentGame.GameLevel.Pawn1;
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
            this.Name = $"Game: {Program.LocalHostPort}";
            this.Text = $"Game: {Program.LocalHostPort}";

            this.Size= new Size(630, 630);
            int tileWidth = 70;
            int tileHeight = 70;
            int tileRows = 9;
            int tileCols = 9;

            Size s = new Size(tileWidth, tileHeight);
            Rectangle destRect = new Rectangle(Point.Empty, s);
            for (int row = 0; row < tileRows; row++)
            {
                for (int col = 0; col < tileCols; col++)
                {
                    PictureBox p = new PictureBox();
                    p.Size = s;
                    Point loc = new Point(tileWidth * col, tileHeight * row);
                    Rectangle srcRect = new Rectangle(loc, s);
                    Bitmap tile = new Bitmap(tileWidth, tileHeight);
                    Graphics G = Graphics.FromImage(tile);
                    G.DrawImage(FileUtils.GetImage("GrassTile.png"), destRect, srcRect, GraphicsUnit.Pixel);
                    p.Image = tile;
                    p.Location = loc;
                    p.Tag = loc;
                    p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
                    this.Controls.Add(p);
                }
            }

            //this.Size= new Size(1200, 1200);
            //int tileWidth = 30;
            //int tileHeight = 30;
            //int tileRows = 30;
            //int tileCols = 30;

            //using (Bitmap sourceBmp = new Bitmap("D:\\900x900.jpg"))
            //{
            //    Size s = new Size(tileWidth, tileHeight);
            //    Rectangle destRect = new Rectangle(Point.Empty, s);
            //    for (int row = 0; row < tileRows; row++)
            //        for (int col = 0; col < tileCols; col++)
            //        {
            //            PictureBox p = new PictureBox();
            //            p.Size = s;
            //            Point loc = new Point(tileWidth * col, tileHeight * row);
            //            Rectangle srcRect = new Rectangle(loc, s);
            //            Bitmap tile = new Bitmap(tileWidth, tileHeight);
            //            Graphics G = Graphics.FromImage(tile);
            //            G.DrawImage(sourceBmp, destRect, srcRect, GraphicsUnit.Pixel);
            //            p.Image = tile;
            //            p.Location = loc;
            //            p.Tag = loc;
            //            p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
            //            p.Text = $"Col:{col} x Row:{row}";
            //            // p.MouseDown += p_MouseDown;
            //            // p.MouseUp += p_MouseUp;
            //            // p.MouseMove += p_MouseMove;
            //            this.Controls.Add(p);
            //        }
            //}
        }

        private void Pawn1Picture_Click(object sender, EventArgs e)
        {
            _selectedSpawnablePawn = CurrentGame.GameLevel.Pawn1;
            Pawn1PictureHighlight.Visible=true;

            Pawn2PictureHighlight.Visible=false;
            Pawn3PictureHighlight.Visible=false;
        }

        private void Pawn2Picture_Click(object sender, EventArgs e)
        {
            _selectedSpawnablePawn = CurrentGame.GameLevel.Pawn2;
            Pawn2PictureHighlight.Visible=true;

            Pawn1PictureHighlight.Visible=false;
            Pawn3PictureHighlight.Visible=false;
        }

        private void Pawn3Picture_Click(object sender, EventArgs e)
        {
            _selectedSpawnablePawn = CurrentGame.GameLevel.Pawn3;
            Pawn3PictureHighlight.Visible=true;

            Pawn2PictureHighlight.Visible=false;
            Pawn1PictureHighlight.Visible=false;
        }

        private void Pawn3PictureHighlight_Click(object sender, EventArgs e)
        {

        }

        private void Pawn2PictureHighlight_Click(object sender, EventArgs e)
        {

        }
    }
}