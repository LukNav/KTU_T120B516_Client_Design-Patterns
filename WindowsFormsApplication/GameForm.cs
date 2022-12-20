using System.Diagnostics;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Net.Http.Headers;
using WindowsFormsApplication.Controllers;
using WindowsFormsApplication.Controllers.ChainPattern;
using WindowsFormsApplication.Controllers.Composite;
using WindowsFormsApplication.Controllers.VisitorPattern;
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
        PictureBox tower1;
        PictureBox tower2;
        #endregion

        #region Other Settings
        private Pawn _selectedPawn;
        private int _ticks = 0;
        private Pawn _previouslySelectedGridPawn = null;
        private List<Position> _targetPositions = new List<Position>();
        private PlayerComposite playerComposite;
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
            BuildCurrentGameState();
            playerComposite = new PlayerComposite() { Name = PlayerName};
        }

        internal void ChangeLevel(Game game)
        {
            YourTurnLabel.Visible = false;
            WaitForYourTurnLabel.Visible = true;
            ResetGameLevel();
            SetGridContents(game.GameLevel.Level);
            RebuildGrid();
            StartGame(game);
        }

        private void ResetGameLevel()
        {
            CurrentGameState = new GameState();
            CurrentGameState.Pawns = new List<Pawn>();

            EnemyGameState = null;
            IsPlayersTurn= false;

            PictureBox defTile = null;
            _selectedGridPawn = null;
            _selectedPawnTile = null;
            Pawn _selectedPawn = null;
            _ticks = 0;
            _previouslySelectedGridPawn = null;
        }

        #region UI controls



        private void SetGameInfo(Game game)
        {
            UpdatePlayersColorsAndNames(game);
            UpdateLevelInfo(game.GameLevel);
        }

        private void UpdateLevelInfo(GameLevel gameLevel)
        {
            LevelLabel.Text = gameLevel.Level.ToString();
            Pawn1Picture.Image = FileUtils.GetImage(gameLevel.Pawn1.ImageName);
            Pawn2Picture.Image = FileUtils.GetImage(gameLevel.Pawn2.ImageName);
            Pawn3Picture.Image = FileUtils.GetImage(gameLevel.Pawn3.ImageName);
            if(tower1 != null && tower2 != null)
            {
                tower1.Image = FileUtils.GetImage(gameLevel.TowerType.imageName);
                tower2.Image = FileUtils.GetImage(gameLevel.TowerType.imageName);
            }
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
       
        internal void SetPlayerData(GameState myGameState)
        {
            CurrentGameState = myGameState;
        }

        internal void BeginPlayersTurn(GameState enemyGameState)
        {            
            EnemyGameState = enemyGameState;
            BuildCurrentGameState();
            playerComposite.RemoveAllChildren();
            CurrentGameState.Pawns.ForEach(p => playerComposite.AddChild(new PawnLeaf(p.ImageName, p.Health)));
            GameStatsLabel.Text = playerComposite.Operation();
            IsPlayersTurn = true;
            YourTurnLabel.Visible = true;
            WaitForYourTurnLabel.Visible = false;
            _targetPositions.Clear();
        }

        private void EndPlayersTurn(GameState currentGameState, GameState enemyGameState)
        {
            BuildCurrentGameState();

            IsPlayersTurn = false;
            YourTurnLabel.Visible = false;
            WaitForYourTurnLabel.Visible = true;

            if (enemyGameState != null)
            {
                GameState enemyStateToSend = PositionFlipper(enemyGameState);
                var temp1 = HttpRequests.PostRequest($"{Program.ServerIp}/GiveEnemyData/{PlayerName}", enemyStateToSend);

            }

            GameState myStateToSend = PositionFlipper(currentGameState);

            var temp2 = HttpRequests.PostRequest($"{Program.ServerIp}/EndTurn/{PlayerName}", myStateToSend);
        }

        private void BuildCurrentGameState()
        {
            MyTowerHealthLabel.Text = CurrentGameState.PlayerTowerHealth.ToString();
            EnemyTowerHealthLabel.Text = CurrentGameState.OpponentTowerHealth.ToString();
            int playerTowerHealth = CurrentGameState.PlayerTowerHealth;
            int enemyTowerHealth = CurrentGameState.OpponentTowerHealth;
            RebuildGrid(); //recreate the grid
            if (playerTowerHealth > 0 && enemyTowerHealth > 0)
            {
                CurrentGameState.PlayerTowerHealth = playerTowerHealth;
                CurrentGameState.OpponentTowerHealth = enemyTowerHealth;
            }

            //Render friendly pawns
            for (int i = 0; i < CurrentGameState.Pawns.Count(); i++)
            {
                foreach (PictureBox pictureBox in tiles)
                {
                    Position p = GameGrid.GetPositionFromTile(pictureBox);
                    if (p == CurrentGameState.Pawns[i].Position)
                    {
                        DrawPawn(CurrentGameState.Pawns[i], pictureBox, false);
                        if (String.Equals(CurrentGameState.Pawns[i].ImageName, "Corpse.png"))
                        {
                            CurrentGameState.Pawns[i].Accept(new KillVisitor());
                        }
                        break;
                    }
                }
            }

            //Render enemy pawns
            if(EnemyGameState != null)
            {
                for(int i = 0; i < EnemyGameState.Pawns.Count; i++)
                {
                    foreach(PictureBox pictureBox in tiles)
                    {
                        Position p = GameGrid.GetPositionFromTile(pictureBox);
                        if (p == EnemyGameState.Pawns[i].Position)
                        {
                            DrawPawn(EnemyGameState.Pawns[i], pictureBox, true);
                            if (String.Equals(EnemyGameState.Pawns[i].ImageName, "Corpse.png"))
                            {
                                EnemyGameState.Pawns[i].Accept(new KillVisitor());
                            }
                            break;
                        }
                    }
                }
            }

            //Removing the dead pawns from the states
            for(int i = 0; i < CurrentGameState.Pawns.Count; i++)
            {
                if(CurrentGameState.Pawns[i].IsDead)
                {
                    CurrentGameState.Pawns.Remove(CurrentGameState.Pawns[i]);
                }
            }
            if(EnemyGameState != null)
            {
                for (int i = 0; i < EnemyGameState.Pawns.Count; i++)
                {
                    if (EnemyGameState.Pawns[i].IsDead)
                    {
                        EnemyGameState.Pawns.Remove(EnemyGameState.Pawns[i]);
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
            tower1 = new PictureBox();
            tower2 = new PictureBox();
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

        private void DrawPawn(Pawn pawn, PictureBox tile, bool isEnemy)
        {
            if(isEnemy)
            {
                tile.Image = FileUtils.GetImage("Enemy_" + pawn.ImageName);
            }
            else
            {
                tile.Image = FileUtils.GetImage(pawn.ImageName);
            }

            tile.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(pawn.Health.ToString(), Font, Brushes.Red, 0, 0);
            });
        }

        //Funkcija kuri leidzia mums isskaidyti PictureBox paveiksliukus i ju atskirus bitus, kad palygintume ar du PicturbeBox turi identiska paveiksliuka
        private byte[] ImageToByteArray(Image image)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] imageByte = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
            return imageByte;
        }

        // ON CLICK PAWN MOVEMENT/ATTACK/ETC EVENTAI
        private void MouseDownOnGrid(object sender, MouseEventArgs e)
        {
            if (!IsPlayersTurn)
                return;

            #region Chain Pattern Setup
            var damagePawn = new PawnDamageHandler();
            var damageTower = new TowerDamageHandler();
            damagePawn.SetNextHandler(damageTower);
            #endregion

            PictureBox selectedTile = (PictureBox)sender;
            Position currentPosition = GameGrid.GetPositionFromTile(selectedTile);

            Pawn allyPawnOnGrid = CurrentGameState.Pawns.Where(p => p.Position == currentPosition).FirstOrDefault();//Try getting ally pawn, if it exists in selected tile
            Pawn enemyPawnOnGrid = EnemyGameState.Pawns.Where(p => p.Position == currentPosition).FirstOrDefault();//Try getting enemy pawn, if it exists in selected tile

            PawnDataText.Text = "SELECTED POSITION IS: X = " + currentPosition.X + " Y = " + currentPosition.Y;

            //Checking if the clicked tile corresponds to a marked tiles position
            bool isMarkedPosition = false;
            for (int j = 0; j < _targetPositions.Count; j++)
            {
                if (_targetPositions[j] == currentPosition)
                {
                    isMarkedPosition = true;
                    break;
                }
            }

            //Darome veiksmus paspaudus kazka priklausomai nuo to ka paspaudeme ir kada
            if (enemyPawnOnGrid != null && _previouslySelectedGridPawn != null && isMarkedPosition == true)//Ataka pries pawnsa
            {
                for (int i = 0; i < EnemyGameState.Pawns.Count(); i++)
                {
                    if (EnemyGameState.Pawns[i].Position == enemyPawnOnGrid.Position)
                    {
                        int damage = damagePawn.CalculateDamageValue("PAWN", _previouslySelectedGridPawn.Damage, EnemyGameState.Pawns[i].Armor);
                        if (damage > 0)
                        {
                            EnemyGameState.Pawns[i].Health -= damage;
                            if(EnemyGameState.Pawns[i].Health <= 0)
                            {
                                EnemyGameState.Pawns[i].Accept(new CorpseVisitor());                                
                            }                            
                            _selectedGridPawn = null;
                            _selectedPawnTile = null;
                            _previouslySelectedGridPawn = null;
                            _targetPositions.Clear();
                            DebugText.Text = "DEALT " + damage + " DAMAGE TO PAWN.";
                            AttackTowerButton.Visible = false;
                            EndPlayersTurn(CurrentGameState, EnemyGameState);
                            break;
                        }
                        else
                        {
                            BuildCurrentGameState();
                            _selectedGridPawn = null;
                            _selectedPawnTile = null;
                            _previouslySelectedGridPawn = null;
                            _targetPositions.Clear();
                            AttackTowerButton.Visible = false;
                            DebugText.Text = "FAILED TO DEAL DAMAGE. THIS MEANS THE CHAIN FAILED SOMEHOW.";
                        }
                    }
                }
            }
            else if(enemyPawnOnGrid == null && allyPawnOnGrid == null && _previouslySelectedGridPawn != null && isMarkedPosition == true)//Movementas
            {
                for (int i = 0; i < CurrentGameState.Pawns.Count(); i++)
                {
                    if (CurrentGameState.Pawns[i].Position == _previouslySelectedGridPawn.Position)
                    {
                        CurrentGameState.Pawns[i].Position = currentPosition;
                        _selectedGridPawn = null;
                        _selectedPawnTile = null;
                        _previouslySelectedGridPawn = null;
                        _targetPositions.Clear();
                        AttackTowerButton.Visible = false;
                        DebugText.Text = "MOVEMENTAS IF RETURNED TRUE";
                        EndPlayersTurn(CurrentGameState,EnemyGameState);
                        break;
                    }
                }
            }
            else if (allyPawnOnGrid != null && _previouslySelectedGridPawn == null)//If in the selected tile there is a pawn and we have not selected a pawn previously
            {
                DebugText.Text = "MARK MOVES IF RETURNED TRUE";
                ShowPossibleMovesForSelectedPawn(sender, allyPawnOnGrid, selectedTile);
                _previouslySelectedGridPawn = allyPawnOnGrid;
                if(currentPosition.Y >= CurrentGameState.SelectedGameGrid.TileRows - 1)
                {
                    AttackTowerButton.Visible = true;
                }
            }
            else if (currentPosition.Y <= 0 && allyPawnOnGrid == null && enemyPawnOnGrid == null)//If empty grid tile is selected to spawn
            {
                //Checking if the limit on the specific pawn is reached
                int countOfThisTypeOfPawn = 0;
                bool pawnLimitReached = false;
                for(int i = 0; i < CurrentGameState.Pawns.Count(); i++)
                {
                    if(String.Equals(_selectedPawn.ImageName, CurrentGameState.Pawns[i].ImageName))
                    {
                        countOfThisTypeOfPawn++;
                        if(countOfThisTypeOfPawn == 2)
                        {
                            pawnLimitReached = true;
                            break;
                        }
                    }
                }

                if(pawnLimitReached)
                {
                    DebugText.Text = "TOO MANY OF THIS SPECIFIC PAWN";
                    _selectedGridPawn = null;
                    _selectedPawnTile = null;
                    _targetPositions.Clear();
                    _previouslySelectedGridPawn = null;
                    AttackTowerButton.Visible = false;
                }
                else
                {
                    DrawPawn(_selectedPawn, selectedTile, false);
                    Pawn pawnToSend = _selectedPawn;
                    pawnToSend.Position = currentPosition;
                    CurrentGameState.Pawns.Add(pawnToSend);
                    if (_selectedGridPawn != null)//Deselect selected grid pawns
                    {
                        DebugText.Text = "SPAWN PAWN IF RETURNED TRUE";
                        _selectedGridPawn = null;
                        _selectedPawnTile = null;
                        _targetPositions.Clear();
                        _previouslySelectedGridPawn = null;
                        AttackTowerButton.Visible = false;
                    }
                    EndPlayersTurn(CurrentGameState, EnemyGameState);
                }
            }
            else//Failsafe in the event nothing worked
            {
                DebugText.Text = "FAILSAFE IF RETURNED TRUE";
                BuildCurrentGameState();
                _selectedGridPawn = null;
                _selectedPawnTile = null;
                _previouslySelectedGridPawn = null;
                _targetPositions.Clear();
                AttackTowerButton.Visible = false;
            }
        }
        private void ShowPossibleMovesForSelectedPawn(object sender, Pawn pawnOnGrid, PictureBox pawnTile)
        {
            DrawSelectedPawnSymbol(pawnOnGrid, pawnTile);
            MarkPawnPossibleMoves(pawnOnGrid);               // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<   Vincentai/Maksai
            _selectedGridPawn = pawnOnGrid;
            _selectedPawnTile = (PictureBox)sender;
        }
        private void MarkPawnPossibleMoves(Pawn pawn)
        {
            _targetPositions.Clear();
            _targetPositions = pawn.moveAlgorithm.MovePositions(pawn);
            int foundPositionsToBreak = _targetPositions.Count;
            foreach (PictureBox tile in tiles)
            {
                Position tilePosition = GetPositionFromTile(tile); 
                foreach (Position position in _targetPositions)
                {
                    if (position == tilePosition)
                    {
                        DrawSelectedMarkSymbol(tile);
                        foundPositionsToBreak--;
                    }
                    if (foundPositionsToBreak <= 0) break;
                }
                if (foundPositionsToBreak <= 0) break;
            }
        }
        private Position GetPositionFromTile(PictureBox tile) // Neistrinkit sito metodo vel pls
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
                e.Graphics.DrawString("[x]", Font, Brushes.Red, 50, 0);
                e.Graphics.DrawString(pawn.Health.ToString(), Font, Brushes.Red, 0, 0);
            });

        }
        private void DrawSelectedMarkSymbol(PictureBox tile)
        {
            tile.Image = FileUtils.GetImage("MarkedTile.png");
        }

        #region other events

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.Name = $"Game: {Program.LocalHostPort}";
            this.Text = $"Game: {Program.LocalHostPort}";

            //GameGridBuilderis
            SetGridContents(1);

        }

        private void SetGridContents(int level)
        {
            var GameGridBuilder = new GameGridBuilder();
            GameGrid gridToMake = GameGridBuilder;

            //Kazkodel prastai is anksto generuotas int listas veike, tai cia rankiniu budu sugeneruoju lygio kurimui.Gal pataisysiu kadanors, gal ne, IDK. -Maksas
            List<int> gridContents = new List<int>(); //Cia galima saugoti kokie daiktai bus ant zemelapio "by default" kaip int kintamuosius. 0 = grass tile, 1 = kazkas kitko, etc. etc.
            for (int i = 0; i < 49; i++)
            {
                gridContents.Add(0);
            }

            //Kol kas tie papildomi lygiai identiski pirmam.
            switch (level) //Keist skaiciuka kad pakeist generuojama lygi
            {
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
                case 3:
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
        }

        private void Pawn1Picture_Click(object sender, EventArgs e)
        {
            if (!IsPlayersTurn)
                return;
            _selectedPawn = CurrentGame.GameLevel.Pawn1;
            Pawn1PictureHighlight.Visible=true;

            Pawn2PictureHighlight.Visible=false;
            Pawn3PictureHighlight.Visible=false;
        }

        private void Pawn2Picture_Click(object sender, EventArgs e)
        {
            if (!IsPlayersTurn)
                return;
            _selectedPawn = CurrentGame.GameLevel.Pawn2;
            Pawn2PictureHighlight.Visible=true;

            Pawn1PictureHighlight.Visible=false;
            Pawn3PictureHighlight.Visible=false;
        }

        private void Pawn3Picture_Click(object sender, EventArgs e)
        {
            if (!IsPlayersTurn)
                return;
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
            if (!IsPlayersTurn)
                return;
            GameState testState = new GameState();
            testState.PlayerTowerHealth = 200;
            testState.OpponentTowerHealth = 200;
            testState.Pawns = new List<Pawn>();
            testState.Pawns.Add(new Pawn(new Position(3, 3), "Villager_3.png", 13, 2, 2, 2, 1, PawnClass.Tier3));
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

        private void Debug_NextLevel_Click(object sender, EventArgs e)
        {
            CurrentGameState = new GameState();
            CurrentGameState.Pawns = new List<Pawn>();

            EnemyGameState = null;

            string serverUrl = $"{Program.ServerIp}/NextLevel";
            HttpRequests.GetRequest(serverUrl);
        }

        private void LevelNameLabel_Click(object sender, EventArgs e)
        {

        }

        private GameState PositionFlipper(GameState gameStateToFlip)
        {
            //Temporary GameState object for calculations
            GameState tempState = gameStateToFlip;

            //Bools that check if we have an odd or not amount of columns/rows ( IMPORTANT FOR CALCULATING COORDINATE FLIPPING. )
            bool oddColumns = false;
            bool oddRows = false;

            if(tempState.SelectedGameGrid.TileRows % 2 == 1)
            {
                oddRows = true;
            }
            if(tempState.SelectedGameGrid.TileCols % 2 == 1)
            {
                oddColumns = true;
            }


            for(int i = 0; i < tempState.Pawns.Count; i++)
            {
                //Flipping Y coordinate
                if(oddRows)
                {
                    //Checking if we aren't in the middle row ( If we are, we obviously don't need to flip it. )
                    if(tempState.Pawns[i].Position.Y + 1 != tempState.SelectedGameGrid.TileRows - tempState.SelectedGameGrid.TileRows / 2)
                    {
                        tempState.Pawns[i].Position.Y = tempState.SelectedGameGrid.TileRows - tempState.Pawns[i].Position.Y - 1;
                    }
                }
                else
                {
                    tempState.Pawns[i].Position.Y = tempState.SelectedGameGrid.TileRows - tempState.Pawns[i].Position.Y - 1;
                }

                //Flipping the X coordinate
                if(oddColumns)
                {
                    //Checking if we aren't in the middle column ( If we are, we obviously don't need to flip it. )
                    if (tempState.Pawns[i].Position.X + 1 != tempState.SelectedGameGrid.TileCols - tempState.SelectedGameGrid.TileCols / 2)
                    {
                        tempState.Pawns[i].Position.X = tempState.SelectedGameGrid.TileCols - tempState.Pawns[i].Position.X - 1;
                    }
                }
                else
                {
                    tempState.Pawns[i].Position.X = tempState.SelectedGameGrid.TileCols - tempState.Pawns[i].Position.X - 1;
                }
            }

            return tempState;
        }

        //METHOD FOR DAMAGING THE ENEMY TOWER
        private void AttackTowerButton_Click(object sender, EventArgs e)
        {
            #region Chain Pattern Setup
            var damagePawn = new PawnDamageHandler();
            var damageTower = new TowerDamageHandler();
            damagePawn.SetNextHandler(damageTower);
            #endregion

            int damage = damagePawn.CalculateDamageValue("TOWER", _previouslySelectedGridPawn.Damage, 1); //Tas "1" yra kintamasis, pagal kuri dalinamas damage bus. i.e.: Jeigu 2, tai zala padaryta bokstui bus padalinta is dvieju.
            CurrentGameState.OpponentTowerHealth -= damage;
            EnemyGameState.PlayerTowerHealth -= damage;

            DebugText.Text = "Player game state player tower hp: " + CurrentGameState.PlayerTowerHealth + " \n";
            DebugText.Text = "Player game state enemy tower hp: " + CurrentGameState.OpponentTowerHealth + " \n";
            DebugText.Text += "Enemy game state player tower hp: " + EnemyGameState.PlayerTowerHealth + " \n";
            DebugText.Text += "Enemy game state enemy tower hp: " + EnemyGameState.OpponentTowerHealth;
            if (CurrentGameState.OpponentTowerHealth > 0)
            {
                BuildCurrentGameState();
                _selectedGridPawn = null;
                _selectedPawnTile = null;
                _targetPositions.Clear();
                _previouslySelectedGridPawn = null;
                AttackTowerButton.Visible = false;

                EndPlayersTurn(CurrentGameState, EnemyGameState);
            }
            else
            {
                EnemyGameState = new GameState();
                EnemyGameState.Pawns = new List<Pawn>();
                EnemyGameState.SelectedGameGrid = CurrentGameState.SelectedGameGrid;

                CurrentGameState = new GameState();
                CurrentGameState.Pawns = new List<Pawn>();

                string serverUrl = $"{Program.ServerIp}/NextLevel";
                HttpRequests.GetRequest(serverUrl);
            }
        }
    }
}