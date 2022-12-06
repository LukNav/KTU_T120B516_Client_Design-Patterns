using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.InterpreterPattern
{
    internal interface IInterpreter
    {
        void Interpret(IContext context);

    }
}
