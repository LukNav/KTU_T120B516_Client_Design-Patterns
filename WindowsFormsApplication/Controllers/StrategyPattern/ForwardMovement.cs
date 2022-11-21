using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication.Helpers;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.StrategyPattern
{
    internal class ForwardMovement : IMoveAlgorithm
    {
        public Position GetPossibleMovementPosition(List<PictureBox> tileList, Pawn pawn)
        {//Possible implementation to show possible moves of soldier
            Position newPosition = new Position(pawn.Position.X, pawn.Position.Y + 1);
            bool movementAvailable = false;
            foreach (PictureBox tile in tileList)
            {
                Position position;
                try
                {
                    position = new Position
                    (
                        Int32.Parse(tile.Name.Substring(4, 2)),
                        Int32.Parse(tile.Name.Substring(11, 2))
                    );
                }
                catch
                {
                    position = new Position(999999, 999999);
                }
                if (position.Y - 1 == pawn.Position.Y && position.X == pawn.Position.X)
                {
                    movementAvailable = true;
                    break;
                }
            }

            if (movementAvailable)
            {
                return  newPosition;
            }
            return null;
        }

        public void Move(List<PictureBox> tileList, Pawn pawn)
        {
            Position newPosition = new Position(pawn.Position.X, pawn.Position.Y + 1);
            bool movementAvailable = false;
            foreach (PictureBox tile in tileList)
            {
                Position position;
                try
                {
                    position = new Position
                    (
                        Int32.Parse(tile.Name.Substring(4, 2)),
                        Int32.Parse(tile.Name.Substring(11, 2))
                    );
                }
                catch
                {
                    position = new Position(999999, 999999);
                }
                if (position.Y - 1 == pawn.Position.Y && position.X == pawn.Position.X)
                {
                    movementAvailable = true;
                    break;
                }
            }

            if (movementAvailable)
            {
                pawn.Position = newPosition;
            }
        }
    }
}
