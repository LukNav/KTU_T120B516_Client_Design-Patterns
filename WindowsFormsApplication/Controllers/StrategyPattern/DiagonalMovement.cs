using System;
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
        public void Move(List<PictureBox> tileList, Pawn pawn, PictureBox defTile)
        {
            PictureBox targetTile = new PictureBox();
            bool canBreak = false;
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
                    position = new Position(99999, 999999);
                }
                if (position.X - 1 == pawn.Position.X && position.Y - 1 == pawn.Position.Y)
                {
                    targetTile = tile;
                    if (canBreak) break;
                    else canBreak = true;
                }
                else if (position == pawn.Position)
                {
                    targetTile.Image = defTile.Image;
                    if (canBreak) break;
                    else canBreak = true;
                }
            }
            targetTile.Image = FileUtils.GetImage(pawn.ImageName);
            targetTile.Paint += new PaintEventHandler((sender, e) =>
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                e.Graphics.DrawString(pawn.Health.ToString(), Control.DefaultFont, Brushes.Red, 0, 0);
            });
        }
    
    }
}
