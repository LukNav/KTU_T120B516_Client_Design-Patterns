using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.MediatorPattern
{
    public interface IMenuMediator
    {
        string CreateClient();
        void SetPlayerAsReady();
        Game GetGameInfo();
        void UnregisterPlayer();
    }
}
