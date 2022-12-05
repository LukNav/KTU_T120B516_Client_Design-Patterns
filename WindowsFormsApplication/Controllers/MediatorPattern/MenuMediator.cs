using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WindowsFormsApplication.Helpers;
using WindowsFormsApplication.Models;

namespace WindowsFormsApplication.Controllers.MediatorPattern
{
    internal class MenuMediator : IMenuMediator
    {
        private object PlayerName { get; set; }
        private string LocalHostPort { get; set; }

        public MenuMediator(object playerName, string localHostPort)
        {
            PlayerName=playerName;
            LocalHostPort=localHostPort;
        }

        public string CreateClient()
        {
            string serverUrl = $"{Program.ServerIp}/Player/Create/{PlayerName}/{LocalHostPort}";

            HttpResponseMessage httpResponseMessage = HttpRequests.GetRequest(serverUrl);
            string responseMessage = httpResponseMessage.Message();

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created)
                return null;
            else
                return responseMessage;
        }

        public Game GetGameInfo()
        {
            string serverUrl = $"{Program.ServerIp}/Game";
            HttpResponseMessage httpResponseMessage = HttpRequests.GetRequest(serverUrl);
            return httpResponseMessage.Deserialize<Game>();
        }

        public void SetPlayerAsReady()
        {
            string serverUrl = $"{Program.ServerIp}/Player/SetAsReady/{PlayerName}";
            HttpRequests.GetRequest(serverUrl);
        }

        public void UnregisterPlayer()
        {
            string serverUrl = $"{Program.ServerIp}/Player/Unregister/{PlayerName}";
            HttpRequests.DeleteRequest(serverUrl);
        }
    }
}
