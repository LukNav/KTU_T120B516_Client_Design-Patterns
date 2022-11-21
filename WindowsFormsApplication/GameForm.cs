using System.Diagnostics;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Net.Http.Headers;
using WindowsFormsApplication.Controllers;
using WindowsFormsApplication.Helpers;
using WindowsFormsApplication.Models;
using WindowsFormsApplication.Models.BridgePattern;

namespace WindowsFormsApplication
{
    public partial class GameForm : Form
    {
        #region Game Session Settings
        public static string PlayerName { get; set; }
        public static Game CurrentGame { get; private set; }
        public GameState CurrentGameState { get; private set; }
        public GameState EnemyGameState { get; private set; }
        private bool IsPlayersTurn = false;
        #endregion

        #region Grid Settings
        public List<PictureBox> tiles = new List<PictureBox>();
        private PictureBox defTile;
        private Pawn _selectedGridPawn = null;
        private PictureBox _selectedPawnTile = null;
        #endregion

        #region Other Settings
        private Pawn _selectedPawn;
        private int _ticks = 0;
        #endregion

        public GameForm()
        {
            CurrentGameState = new GameState();
            CurrentGameState.Pawns = new List<Pawn>();
            InitializeComponent();
        }

        public void StartGame(Game game)
        {
            Program.MenuForm.Visible = false;
            Program.GameForm.Visible = true;
            Program.GameForm.timer1.Start();
            CurrentGame = game;
            _selectedPawn = CurrentGame.GameLevel.Pawn1;
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
       
        internal void BeginPlayersTurn(GameState enemyGameState)
        {
            EnemyGameState = enemyGameState;
            BuildCurrentGameState();
            IsPlayersTurn = true;
            YourTurnLabel.Visible = true;
            WaitForYourTurnLabel.Visible = false;
        }

        private void EndPlayersTurn(GameState currentGameState)
        {
            IsPlayersTurn = false;
            YourTurnLabel.Visible = false;
            WaitForYourTurnLabel.Visible = true;
            var temp = HttpRequests.PostRequest($"{Program.ServerIp}/EndTurn/{PlayerName}", currentGameState);
        }

        private void BuildCurrentGameState()
        {
            RebuildGrid(); //recreate the grid
            foreach (Pawn pawn in CurrentGameState.Pawns)
            {
                foreach (PictureBox pictureBox in tiles)
                {
                    Position p = GameGrid.GetPositionFromTile(pictureBox);
                    if (p == pawn.Position)
                    {
                        DrawPawn(pawn, pictureBox);
                        break;
                    }
                }
            }

            foreach (Pawn pawn in EnemyGameState.Pawns)
            {
                foreach (PictureBox pictureBox in tiles)
                {
                    Position p = GameGrid.GetPositionFromTile(pictureBox);
                    if (p == pawn.Position)
                    {
                        DrawPawn(pawn, pictureBox);
                        break;
                    }
                }
            }
        }

        private void RebuildGrid()
        {
            BuildGrid(CurrentGameState.SelectedGameGrid);
        }

        /// <summary>
        /// Metodas kuris sukuria zaidimo grida. Galima bus veliau bandyt taip updatint zaidimo busena speju: sena grida istrinant ir pakeiciant nauju.
        /// </summary>
        /// <param name="gridToMake"></param>
        private void BuildGrid(GameGrid gridToMake)
        {
            //delete old tiles
            foreach (PictureBox tile in tiles)
            {
                this.Controls.Remove(tile);
            }
            tiles.Clear();

            //Load battlefield
            int tileContentIterator = 0;
            Size size = new Size(gridToMake.TileWidth, gridToMake.TileHeight);
            Rectangle destRect = new Rectangle(Point.Empty, size);
            for (int row = 0; row < gridToMake.TileRows; row++)
            {
                for (int col = 0; col < gridToMake.TileCols; col++)
                {
                    PictureBox p = new PictureBox();
                    p.Size = size;
                    Point loc = new Point(gridToMake.Spacer + gridToMake.TileOriginX + gridToMake.TileWidth * col, gridToMake.Spacer + gridToMake.TileOriginY + gridToMake.TileHeight * row);

                    //Switchas uzpildyti tilus pagal ju turini
                    p.Image = FileUtils.GetImage("GrassTile.png");

                    p.Location = loc;
                    p.Tag = loc;
                    p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
                    p.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownOnGrid);
                    this.Controls.Add(p);
                    tiles.Add(p);
                    if (defTile == null) defTile = p;
                    tileContentIterator++; //Saugo kokiam langeli dabar busim buildinant grida sita
                }
            }

            //Load towers
            Image towerImage = FileUtils.GetImage("Tower_1.png");
            Size towerSize = new Size(gridToMake.TowerLength, gridToMake.TowerLength);
            PictureBox tower1 = new PictureBox();
            PictureBox tower2 = new PictureBox();
            Point tower1Location = new Point(gridToMake.TowerX, gridToMake.PlayerOneTowerY);
            Point tower2Location = new Point(gridToMake.TowerX, gridToMake.PlayerTwoTowerY);
            tower1.Location = tower1Location;
            tower2.Location = tower2Location;
            tower1.Name = "Tower1"; //might need to change names to respresent players instead
            tower2.Name = "Tower2";
            tower1.Image = towerImage;
            tower2.Image = towerImage;
            tower1.Size = towerSize;
            tower2.Size = towerSize;
            CurrentGameState.PlayerTowerHealth = 300;
            CurrentGameState.OpponentTowerHealth = 300;
            this.Controls.Add(tower1);
            this.Controls.Add(tower2);
        }

        private void DrawPawn(Pawn pawn, PictureBox tile)
        {
            tile.Image = FileUtils.GetImage(pawn.ImageName);
            tile.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(pawn.Health.ToString(), Font, Brushes.Red, 0, 0);
            });
        }

        private void MouseDownOnGrid(object sender, MouseEventArgs e)
        {
            PictureBox selectedTile = (PictureBox)sender;
            Position currentPosition = GameGrid.GetPositionFromTile(selectedTile);
            Pawn pawnOnGrid = CurrentGameState.Pawns.Where(p => p.Position == currentPosition).FirstOrDefault();//Try getting a pawn, if it exists in selected tile

            //if (pawnOnGrid is selected and possible move is selected ) <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<   Vincentai/Maksai
            //{ Move Pawn; EndPlayersTurn(CurrentGameState); }

            if (pawnOnGrid != null)//If in the selected tile there is a pawn
            {
                ShowPossibleMovesForSelectedPawn(sender, pawnOnGrid, selectedTile);
            }
            else if (currentPosition.Y <= 0)//If empty grid tile is selected to spawn
            {
                DrawPawn(_selectedPawn, selectedTile);
                Pawn pawnToSend = _selectedPawn;
                pawnToSend.Position = currentPosition;
                CurrentGameState.Pawns.Add(pawnToSend);
                if (_selectedGridPawn != null)//Deselect selected grid pawns
                {
                    BuildCurrentGameState();
                    _selectedGridPawn = null;
                    _selectedPawnTile = null;
                }
                EndPlayersTurn(CurrentGameState);
            }
        }
        private void ShowPossibleMovesForSelectedPawn(object sender, Pawn pawnOnGrid, PictureBox pawnTile)
        {
            DrawSelectedPawnSymbol(pawnOnGrid, pawnTile);
            //MarkPawnPossibleMoves(pawnOnGrid);                <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<   Vincentai/Maksai
            _selectedGridPawn = pawnOnGrid;
            _selectedPawnTile = (PictureBox)sender;
        }

        /// <summary>
        /// Draws [x] symbol near selected pawn
        /// </summary>
        /// <param name="pawn"></param>
        /// <param name="tile"></param>
        private void DrawSelectedPawnSymbol(Pawn pawn, PictureBox tile)
        {
            tile.Image = FileUtils.GetImage(pawn.ImageName);
            tile.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                e.Graphics.DrawString("[x]", Font, Brushes.Green, 50, 0);
                e.Graphics.DrawString(pawn.Health.ToString(), Font, Brushes.Red, 0, 0);
            });
        }

        #region other events

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.Name = $"Game: {Program.LocalHostPort}";
            this.Text = $"Game: {Program.LocalHostPort}";

            //GameGridBuilderis
            var GameGridBuilder = new GameGridBuilder();
            GameGrid gridToMake = GameGridBuilder;

            //Kazkodel prastai is anksto generuotas int listas veike, tai cia rankiniu budu sugeneruoju lygio kurimui.Gal pataisysiu kadanors, gal ne, IDK. -Maksas
            List<int> gridContents = new List<int>(); //Cia galima saugoti kokie daiktai bus ant zemelapio "by default" kaip int kintamuosius. 0 = grass tile, 1 = kazkas kitko, etc. etc.
            for (int i = 0; i < 49; i++)
            {
                gridContents.Add(0);
            }

            //Kol kas tie papildomi lygiai identiski pirmam.
            switch (0) //Keist skaiciuka kad pakeist generuojama lygi
            {
                case 0:
                    gridToMake = GameGridBuilder.
                        SetPlayerOneTowerY(25).
                        SetPlayerTwoTowerY(775).
                        SetTowerX(480).
                        SetTowerLength(100).
                        SetTileOriginX(200).
                        SetTileOriginY(100).
                        SetTileHeight(70).
                        SetTileWidth(70).
                        SetSpacer(2).
                        SetTileCols(9).
                        SetTileRows(9).
                        SetGridContents(gridContents);
                    break;
                case 1:
                    gridToMake = GameGridBuilder.
                        SetPlayerOneTowerY(25).
                        SetPlayerTwoTowerY(775).
                        SetTowerX(480).
                        SetTowerLength(100).
                        SetTileOriginX(200).
                        SetTileOriginY(100).
                        SetTileHeight(70).
                        SetTileWidth(70).
                        SetSpacer(2).
                        SetTileCols(9).
                        SetTileRows(9).
                        SetGridContents(gridContents);
                    break;
                case 2:
                    gridToMake = GameGridBuilder.
                        SetPlayerOneTowerY(25).
                        SetPlayerTwoTowerY(775).
                        SetTowerX(480).
                        SetTowerLength(100).
                        SetTileOriginX(200).
                        SetTileOriginY(100).
                        SetTileHeight(70).
                        SetTileWidth(70).
                        SetSpacer(2).
                        SetTileCols(9).
                        SetTileRows(9).
                        SetGridContents(gridContents);
                    break;
            }
            CurrentGameState.SelectedGameGrid = gridToMake;
            BuildGrid(gridToMake);

        }

        private void Pawn1Picture_Click(object sender, EventArgs e)
        {
            _selectedPawn = CurrentGame.GameLevel.Pawn1;
            Pawn1PictureHighlight.Visible=true;

            Pawn2PictureHighlight.Visible=false;
            Pawn3PictureHighlight.Visible=false;
        }

        private void Pawn2Picture_Click(object sender, EventArgs e)
        {
            _selectedPawn = CurrentGame.GameLevel.Pawn2;
            Pawn2PictureHighlight.Visible=true;

            Pawn1PictureHighlight.Visible=false;
            Pawn3PictureHighlight.Visible=false;
        }

        private void Pawn3Picture_Click(object sender, EventArgs e)
        {
            _selectedPawn = CurrentGame.GameLevel.Pawn3;
            Pawn3PictureHighlight.Visible=true;

            Pawn2PictureHighlight.Visible=false;
            Pawn1PictureHighlight.Visible=false;
        }  

        private void timer1_Tick(object sender, EventArgs e)
        {
            //move all pawns
            //foreach (Pawn pawn in CurrentGameState.Pawns)
            //{
            //pawn.moveAlgorithm.Move(tiles, pawn);
            //    Debug.WriteLine("Current pawns: {0}", CurrentGameState.Pawns.Count);
            //    Debug.WriteLine("X: {0} | Y: {1}", pawn.Position.X, pawn.Position.Y);
            //}
            //LoadGameState(CurrentGameState);
        }

        private void loadStateButton_Click(object sender, EventArgs e)
        {
            GameState testState = new GameState();
            testState.PlayerTowerHealth = 200;
            testState.OpponentTowerHealth = 200;
            testState.Pawns = new List<Pawn>();
            testState.Pawns.Add(new Pawn(new Position(3, 3), "Villager_3.png", 13, 2, 2, 2, PawnClass.Tier3));
            var GameGridBuilder = new GameGridBuilder();
            GameGrid gridToMake = GameGridBuilder;

            //Kazkodel prastai is anksto generuotas int listas veike, tai cia rankiniu budu sugeneruoju lygio kurimui.Gal pataisysiu kadanors, gal ne, IDK. -Maksas
            List<int> gridContents = new List<int>(); //Cia galima saugoti kokie daiktai bus ant zemelapio "by default" kaip int kintamuosius. 0 = grass tile, 1 = kazkas kitko, etc. etc.
            for (int i = 0; i < 49; i++)
            {
                gridContents.Add(0);
            }

            gridToMake = GameGridBuilder.
                SetPlayerOneTowerY(25).
                SetPlayerTwoTowerY(775).
                SetTowerX(480).
                SetTowerLength(100).
                SetTileOriginX(200).
                SetTileOriginY(100).
                SetTileHeight(70).
                SetTileWidth(70).
                SetSpacer(2).
                SetTileCols(9).
                SetTileRows(9).
                SetGridContents(gridContents);

            testState.SelectedGameGrid = gridToMake;
            BeginPlayersTurn(testState);
        }

        //BRIDGE PATTERN BASED OBSTACLE OBJECTS. THEY DO NOTHING ATM. THIS IS JUST THE FRAMEWORK FOR A BRIDGE PATTERN
        public Obstacle Spikes = new Obstacle(new Hazard(), new Position(0, 0), "I DO NOT EXIST");
        public Obstacle Lake = new Obstacle(new Slower(), new Position(0, 0), "I DO NOT EXIST");
        public Obstacle Mountain = new Obstacle(new Wall(), new Position(0, 0), "I DO NOT EXIST");
        #endregion
    }
}