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
        public GameState CurrentGameState { get; private set; }
        private Pawn _selectedPawn;
        private int _ticks = 0;
        public List<PictureBox> tiles = new List<PictureBox>();

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

        #region HttpRequests

        private Game GetGameInfo()
        {
            string serverUrl = $"{Program.ServerIp}/Game";
            HttpResponseMessage httpResponseMessage = HttpRequests.GetRequest(serverUrl);
            return httpResponseMessage.Deserialize<Game>();
        }

        #endregion

        //Metodas kuris sukuria zaidimo grida. Galima bus veliau bandyt taip updatint zaidimo busena speju: sena grida istrinant ir pakeiciant nauju.
        private void GridMaker(GameGrid gridToMake)
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
                    switch(0) //Kazkodel meta nullreference errorus su GameGrid tai as tiesiog priverciu switcha zole det visur kol kas. - Maksas
                    {
                        case 0:
                            p.Image = FileUtils.GetImage("GrassTile.png");
                            break;
                        case 1:
                            p.Image = FileUtils.GetImage("Villager_1.png");
                            break;
                        case 2:
                            p.Image = FileUtils.GetImage("Villager_2.png");
                            break;
                        case 3:
                            p.Image = FileUtils.GetImage("Villager_3.png");
                            break;
                    }

                    p.Location = loc;
                    p.Tag = loc;
                    p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
                    p.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownOnGrid);
                    this.Controls.Add(p);
                    tiles.Add(p);

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
            GridMaker(gridToMake);

            //Originalus grido gaminimo kintamieji
            { 
                /*this.Size = new Size(1000, 900);
                int tileOriginX = 200;
                int tileOriginY = 125;
                int spacer = 2;
                int tileWidth = 70;
                int tileHeight = 70;
                int tileRows = 9;
                int tileCols = 9;



                //Originalus bokstu kintamieji
                int towerX = 480;
                int tower1Y = 25;
                int tower2Y = 775;
                int towerLength = 100;


                //Load towers
                Image towerImage = FileUtils.GetImage("Tower_1.png");
                Size towerSize = new Size(towerLength, towerLength);
                PictureBox tower1 = new PictureBox();
                PictureBox tower2 = new PictureBox();
                Point tower1Location = new Point(towerX, tower1Y);
                Point tower2Location = new Point(towerX, tower2Y);
                tower1.Location = tower1Location;
                tower2.Location = tower2Location;
                tower1.Name = "Tower1"; //might need to change names to respresent players instead
                tower2.Name = "Tower2";
                tower1.Image = towerImage;
                tower2.Image = towerImage;
                tower1.Size = towerSize;
                tower2.Size = towerSize;
                this.Controls.Add(tower1);
                this.Controls.Add(tower2);


                //Senas grido kurimo budas
                Size s = new Size(tileWidth, tileHeight);
                Rectangle destRect = new Rectangle(Point.Empty, s);
                for (int row = 0; row < tileRows; row++)
                {
                    for (int col = 0; col < tileCols; col++)
                    {
                        PictureBox p = new PictureBox();
                        p.Size = s;
                        Point loc = new Point(spacer+tileOriginX + tileWidth * col, spacer+tileOriginY + tileHeight * row);
                        p.Image = FileUtils.GetImage("GrassTile.png");
                        p.Location = loc;
                        p.Tag = loc;
                        p.Name = String.Format("Col={0:00}-Row={1:00}", col, row);
                        p.MouseDown += new System.Windows.Forms.MouseEventHandler(MouseDownOnGrid);
                        this.Controls.Add(p);
                    }
                }
                */
            }
        }

        //Metodas uzloadinti gamestate'a
        public void LoadGameState(GameState gameState)
        {
            CurrentGameState = gameState;
            BuildCurrentGameState();
        }
        private void BuildCurrentGameState()
        {
            GridMaker(CurrentGameState.SelectedGameGrid); //reset the grid
            foreach (Pawn pawn in CurrentGameState.Pawns)
            {
                foreach (PictureBox pictureBox in tiles)
                {
                    Position p = GetPositionFromTile(pictureBox);
                    if (p == pawn.Position)
                    {
                        LoadPawn(pawn, pictureBox);
                        break;
                    }
                }
            }
        }
        public IEnumerable<Control> GetAllControls(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
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

        private PictureBox _currentTile;
        void MouseDownOnGrid(object sender, MouseEventArgs e)
        {
            _currentTile = (PictureBox)sender;
            Position currentPosition = GetPositionFromTile(_currentTile);
            if (currentPosition.Y <= 0)
            {
                LoadPawn(_selectedPawn, _currentTile);
                //_currentTile.Image = FileUtils.GetImage(_selectedPawn.ImageName);
                //_currentTile.Paint += new PaintEventHandler((sender, e) =>
                //{
                //    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                //    e.Graphics.DrawString(_selectedPawn.Health.ToString(), Font, Brushes.Red, 0, 0);
                //});

                Pawn pawnToSend = _selectedPawn;
                pawnToSend.Position = currentPosition;
                CurrentGameState.Pawns.Add(pawnToSend);
            }
        }
        private void LoadPawn(Pawn pawn, PictureBox tile)
        {
            tile.Image = FileUtils.GetImage(pawn.ImageName);
            tile.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(pawn.Health.ToString(), Font, Brushes.Red, 0, 0);
            });
        }
        private Position GetPositionFromTile(PictureBox tile)
        {
            try
            {
                Position position = new Position
                (
                    Int32.Parse(tile.Name.Substring(4, 2)),
                    Int32.Parse(tile.Name.Substring(11, 2))
                );
                return position;
            }
            catch
            {
                return new Position(99999, 999999);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {          
            //Cia gali daryt kazka su fizika and shiet.
        }

        public GameState GetGameState()
        {
            return CurrentGameState;
        }

        private void loadStateButton_Click(object sender, EventArgs e)
        {
            GameState testState = new GameState();
            testState.PlayerTowerHealth = 200;
            testState.OpponentTowerHealth = 200;
            testState.Pawns = new List<Pawn>();
            testState.Pawns.Add(new Pawn(new Position(3, 3), "Villager_3.png", 13, 2, 2, 2));
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
            LoadGameState(testState);
        }
    }
}