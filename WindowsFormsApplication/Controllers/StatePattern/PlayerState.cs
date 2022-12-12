using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.StatePattern
{
    internal class PlayerState : State
    {
        public PlayerState()
        {
            this.IsSelectable = true;
        }
    }
}
