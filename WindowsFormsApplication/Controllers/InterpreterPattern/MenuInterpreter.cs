using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication.Controllers.InterpreterPattern
{
    internal class MenuInterpreter : IInterpreter
    {
        public void Interpret(IContext context)
        {
            Interpret(context);
        }

        public void Interpret(MenuContext context)
        {
            //input name
            //submit name
            //ready
            //quit
            switch (context.value)
            {
                case "Quit":
                    Program.MenuForm.quitButton_Click(null, null);
                    break;

                case "ready":

                    break;

                case "name":

                    break;
            }
        }     
    }
}
