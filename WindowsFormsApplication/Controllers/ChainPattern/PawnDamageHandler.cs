using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.ChainPattern
{
    internal class PawnDamageHandler : Handler
    {
        private Handler nextHandler;
        public override int CalculateDamageValue(string targetType, int damageStat, int armorStat)
        {
            if(targetType == "PAWN")
            {
                return damageStat - armorStat;
            }
            else
            {
                return nextHandler.CalculateDamageValue(targetType, damageStat, armorStat);
            }
        }
    }
}
