using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models
{
    public class GameGridBuilder : BuilderPattern.IGameGridBuilder
    {
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
                TileCols = TileCols
            };
        }        

        public static implicit operator GameGrid(GameGridBuilder ggb)
        {
            return ggb.BuildGameGrid();
        }
    }
}
