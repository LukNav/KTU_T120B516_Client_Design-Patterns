using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models.BridgePattern
{
    public abstract class ObstacleType
    {
        public abstract void HazardEffect();

        public abstract bool IsBlocking();
    }
}
