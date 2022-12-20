using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.StatePattern
{
    internal class EnemyState : State
    {
        public EnemyState(Pawn pawn)
        {
            this.IsSelectable = false;
            this.Pawn = pawn;
        }

        public override void SwitchState()
        {
            Pawn.CurrentState = new PlayerState(Pawn);
        }
    }
}
