using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.StrategyPattern
{
    public interface IMoveAlgorithm
    {
        public void Move(List<PictureBox> tileList, Pawn pawn);
    }
}
