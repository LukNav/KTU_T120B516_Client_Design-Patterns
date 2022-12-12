using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.StatePattern
{
    public abstract class State
    {
        public bool IsSelectable { get; set; }
    }
}
