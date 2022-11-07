using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models.BridgePattern
{
    public class Explosive : ObstacleType
    {
        public override void HazardEffect()
        {
            //Do the hazard effect
        }

        public override bool IsBlocking()
        {
            return false;
        }
    }
}
