using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models
{
    public class GameGridBuilder : BuilderPattern.IGameGridBuilder
    {
        private int PlayerOneTowerY { get; set; }
        private int PlayerTwoTowerY { get; set; }
        private int TowerX { get; set; }
        private int TowerLength { get; set; }
        private int TileOriginX { get; set; }
        private int TileOriginY { get; set; }
        private int Spacer { get; set; }
        private int TileWidth { get; set; }
        private int TileHeight { get; set; }
        private int TileRows { get; set; }
        private int TileCols { get; set; }
        private List<int> GridContents { get; set; }


        public GameGridBuilder SetSpacer(int spacer)
        {
            Spacer = spacer;
            return this;
        }

        public GameGridBuilder SetTileCols(int tileCols)
        {
            TileCols = tileCols;
            return this;
        }

        public GameGridBuilder SetTileHeight(int tileHeight)
        {
            TileHeight = tileHeight;
            return this;
        }

        public GameGridBuilder SetTileOriginX(int tileOriginX)
        {
            TileOriginX = tileOriginX;
            return this;
        }

        public GameGridBuilder SetTileOriginY(int tileOriginY)
        {
            TileOriginY = tileOriginY;
            return this;
        }

        public GameGridBuilder SetTileRows(int tileRows)
        {
            TileRows = tileRows;
            return this;
        }

        public GameGridBuilder SetTileWidth(int tileWidth)
        {
            TileWidth = tileWidth;
            return this;
        }

        public GameGridBuilder SetGridContents(List<int> contents)
        {
            GridContents = contents;
            return this;
        }

        public GameGrid BuildGameGrid()
        {
            return new GameGrid()
            {
                TileOriginX = TileOriginX,
                TileOriginY = TileOriginY,
                Spacer = Spacer,
                TileWidth = TileWidth,
                TileHeight = TileHeight,
                TileRows = TileRows,
                TileCols = TileCols,
                PlayerOneTowerY = PlayerOneTowerY,
                PlayerTwoTowerY = PlayerTwoTowerY,
                TowerX = TowerX,
                TowerLength = TowerLength,
            };
        }

        public GameGridBuilder SetPlayerOneTowerY(int playerOneTowerY)
        {
            PlayerOneTowerY = playerOneTowerY;
            return this;
        }

        public GameGridBuilder SetPlayerTwoTowerY(int playerTwoTowerY)
        {
            PlayerTwoTowerY = playerTwoTowerY;
            return this;
        }

        public GameGridBuilder SetTowerX(int towerX)
        {
            TowerX = towerX;
            return this;
        }

        public GameGridBuilder SetTowerLength(int towerLength)
        {
            TowerLength = towerLength;
            return this;
        }

        public static implicit operator GameGrid(GameGridBuilder ggb)
        {
            return ggb.BuildGameGrid();
        }
    }
}
