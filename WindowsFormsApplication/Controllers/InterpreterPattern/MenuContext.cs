using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.InterpreterPattern
{
    internal class MenuContext : IContext
    {
        private string _value;
        public string value { get { return _value.ToLower(); } set { _value = value; } }

        public MenuContext(string value)
        {
            _value = value;
        }
    }
}
