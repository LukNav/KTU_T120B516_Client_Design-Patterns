using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            string[] values = context.value.Split(' ');
            //input name
            //submit name
            //ready
            //quit
            switch (values[0])
            {
                case "quit":
                    Program.MenuForm.quitButton_Click(null, null);
                    break;

                case "ready":
                    Program.MenuForm.ReadyButton_Click(null, null);
                    break;

                case "input":
                    if(values.Length > 1)
                        Program.MenuForm.NameTextBox.Text = values[1];
                    break;

                case "submit":
                    Program.MenuForm.SubmitNameButton_Click(null, null);
                    break;
            }
        }     
    }
}
