using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models.BuilderPattern
{
    public interface IGameGridBuilder
    {
        GameGridBuilder SetPlayerOneTowerY(int playerOneTowerY);
        GameGridBuilder SetPlayerTwoTowerY(int playerTwoTowerY);
        GameGridBuilder SetTowerX(int towerX);
        GameGridBuilder SetTowerLength(int towerLength);
        GameGridBuilder SetTileOriginX(int tileOriginX);
        GameGridBuilder SetTileOriginY(int tileOriginY);
        GameGridBuilder SetSpacer(int spacer);
        GameGridBuilder SetTileWidth(int tileWidth);
        GameGridBuilder SetTileHeight(int tileHeight);
        GameGridBuilder SetTileRows(int tileRows);
        GameGridBuilder SetTileCols(int tileCols);
        GameGridBuilder SetGridContents(List<int> contents);

        GameGrid BuildGameGrid();
    }
}
