using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.ChainPattern
{
    public abstract class Handler : IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNextHandler(Handler nextHandler)
        {
            this._nextHandler = nextHandler;
            return nextHandler;
        }

        public virtual int CalculateDamageValue(string targetType, int damageStat, int armorStat)
        {
            if(this._nextHandler != null)
            {
                return this._nextHandler.CalculateDamageValue(targetType, damageStat, armorStat);
            }
            else
            {
                return 0;
            }
        }
    }
}
