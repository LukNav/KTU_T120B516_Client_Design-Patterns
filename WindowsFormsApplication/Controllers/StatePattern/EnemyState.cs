using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.StatePattern
{
    internal class EnemyState : State
    {
        public EnemyState()
        {
            this.IsSelectable = false;
        }
    }
}
