using Microsoft.AspNetCore.Mvc;

namespace WindowsFormsApplication.Models
{
    internal interface IStartGameObserver
    {
        ActionResult StartGame(Game gameInfo);
    }
}