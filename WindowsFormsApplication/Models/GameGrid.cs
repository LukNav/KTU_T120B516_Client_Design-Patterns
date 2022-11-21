using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models
{
    public class GameGrid
    {
        public int PlayerOneTowerY { get; set; }
        public int PlayerTwoTowerY { get; set; }
        public int TowerX { get; set; }
        public int TowerLength { get; set; }
        public int TileOriginX { get; set; }
        public int TileOriginY { get; set; }
        public int Spacer { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int TileRows { get; set; }
        public int TileCols { get; set; }

        public static Position GetPositionFromTile(PictureBox tile)
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
    }
}
