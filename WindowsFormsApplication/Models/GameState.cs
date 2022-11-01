using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models
{
    public class GameState
    {
        public int PlayerTowerHealth { get; set; }
        public int OpponentTowerHealth { get;set; }
        public List<Pawn> Pawns { get; set; }
        public GameGrid SelectedGameGrid { get; set; }

    }
}
