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

            switch (values[0])
            {
                case "quit":
                    Program.MenuForm.quitButton_Click(null, null);
                    break;

                case "ready":
                    Program.MenuForm.ReadyButton_Click(null, null);
                    break;

                case "name":
                    if(values.Length > 1)
                        Program.MenuForm.NameTextBox.Text = values[1];
                    break;

                case "start":
                    Program.MenuForm.SubmitNameButton_Click(null, null);
                    break;
            }
        }     
    }
}
