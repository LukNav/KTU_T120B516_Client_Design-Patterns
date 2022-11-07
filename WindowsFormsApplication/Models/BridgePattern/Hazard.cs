using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models.BridgePattern
{
    public class Hazard : ObstacleType
    {
        public override void HazardEffect()
        {
            //Hazard effect happens
        }

        public override bool IsBlocking()
        {
            return false;
        }
    }
}
