using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.ChainPattern
{
    public interface IHandler
    {
        IHandler SetNextHandler(Handler nextHandler);

        int CalculateDamageValue(String targetType, int damageStat, int armorStat);
    }
}
