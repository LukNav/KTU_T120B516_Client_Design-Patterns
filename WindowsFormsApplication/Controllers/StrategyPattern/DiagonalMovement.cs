﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication.Helpers;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.StrategyPattern
{
    internal class DiagonalMovement : IMoveAlgorithm
    {
        public void Move(List<PictureBox> tileList, Pawn pawn)
        {
            Position newPosition = new Position(pawn.Position.X + 1, pawn.Position.Y + 1);
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
                if (position.Y - 1 == pawn.Position.Y && position.X - 1 == pawn.Position.X)
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
        public List<Position> MovePositions(Pawn pawn)
        {
            List<Position> newPositions = new List<Position>();
            Position newPosition1 = new Position(pawn.Position.X + 1, pawn.Position.Y + 1);
            Position newPosition2 = new Position(pawn.Position.X - 1, pawn.Position.Y + 1);

            newPositions.Add(newPosition1);
            newPositions.Add(newPosition2);
            return newPositions;
        }
    }
}