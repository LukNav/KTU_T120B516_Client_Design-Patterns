﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Models.BridgePattern
{
    public class Wall : ObstacleType
    {
        public override void HazardEffect()
        {
            //Enact hazardous effects
        }

        public override bool IsBlocking()
        {
            return true;
        }
    }
}
