using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.StatePattern
{
    public class PlayerState : State
    {
        public PlayerState(Pawn pawn)
        {
            this.IsSelectable = true;
            this.Pawn = pawn;
        }

        public override void SwitchState()
        {
            Pawn.CurrentState = new EnemyState(Pawn);
        }
    }
}