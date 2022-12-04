namespace IntegrationTests
{
    using WindowsFormsApplication;
    using WindowsFormsApplication.Helpers;
    using WindowsFormsApplication.Models;

    public class HttpRequestsTests
    {
        private MenuForm menuForm;

        [SetUp]
        public void Setup()
        {
            menuForm = new MenuForm();
        }

        [Test]
        public void HealthServerCheck_ReturnsOkHealthyResponse()
        {
            string serverUrl = $"{Program.ServerIp}/health";

            HttpResponseMessage response = HttpRequests.GetRequest(serverUrl);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
        }

        [Test]
        public void CreateClientRequest_WithValidName_ReturnsCreatedResponse()
        {
            string name = "TestName";
            string localhostPort = "TestLocalHostPort_6154198";
            string serverUrl = $"{Program.ServerIp}/Player/Create/{name}/{localhostPort}";

            HttpResponseMessage response = HttpRequests.GetRequest(serverUrl);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.Created);
            HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}");
        }

        [Test]
        public void CreateClientRequest_WithDuplicateName_ReturnsBadRequestResponse()
        {
            string name = "TestName";
            string localhostPort = "TestLocalHostPort_6154198";
            string serverUrl = $"{Program.ServerIp}/Player/Create/{name}/{localhostPort}";

            HttpRequests.GetRequest(serverUrl);
            HttpResponseMessage response = HttpRequests.GetRequest(serverUrl);

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
            HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}");
        }

        [Test]
        public void CreateClientRequest_WhenTryingToRegisterThirdClient_ReturnsBadRequestResponse()
        {
            string name = "TestName";
            string localhostPort = "TestLocalHostPort_6154198";

            HttpRequests.GetRequest($"{Program.ServerIp}/Player/Create/{name}1/{localhostPort}1");
            HttpRequests.GetRequest($"{Program.ServerIp}/Player/Create/{name}2/{localhostPort}2");
            HttpResponseMessage response = HttpRequests.GetRequest($"{Program.ServerIp}/Player/Create/{name}3/{localhostPort}3");

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.BadRequest);
            HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}1");
            HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}2");
        }

        [Test]
        public void UnregisterClientRequest_WithValidName_ReturnsNoContentResponse()
        {
            string name = "TestName";
            string localhostPort = "TestLocalHostPort_6154198";
            string serverUrl = $"{Program.ServerIp}/Player/Create/{name}/{localhostPort}";

            HttpRequests.GetRequest(serverUrl);
            HttpResponseMessage response = HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}");

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        public void UnregisterClientRequest_WithInvalidName_ReturnsNoContentResponse()
        {
            string name = "TestName";
            string localhostPort = "TestLocalHostPort_6154198";
            string serverUrl = $"{Program.ServerIp}/Player/Create/{name}/{localhostPort}";

            HttpRequests.GetRequest(serverUrl);
            HttpResponseMessage response = HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}");

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        public void SetPlayerAsReadytRequest_WithValidName_ReturnsOkResponse()
        {
            string name = "TestName";
            string localhostPort = "TestLocalHostPort_6154198";
            string serverUrl = $"{Program.ServerIp}/Player/Create/{name}/{localhostPort}";

            HttpRequests.GetRequest(serverUrl);
            HttpResponseMessage response = HttpRequests.GetRequest($"{Program.ServerIp}/Player/SetAsReady/{name}");

            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);
            HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}");
        }
        [Test]
        public void GetGameInfoRequest_WithOnePlayer_ReturnsGameInfoWithPlayerResponse()
        {
            string name = "TestName";
            string localhostPort = "TestLocalHostPort_6154198";
            string serverUrl = $"{Program.ServerIp}/Player/Create/{name}/{localhostPort}";

            HttpRequests.GetRequest(serverUrl);
            Game response = HttpRequests.GetRequest($"{Program.ServerIp}/Game").Deserialize<Game>();

            Assert.AreEqual(response.Player1.Name, name);
            HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}");
        }

        [Test]
        public void GetGameInfoRequest_WithNoPlayers_ReturnsGameInfoWithNoPlayersResponse()
        {
            Game response = HttpRequests.GetRequest($"{Program.ServerIp}/Game").Deserialize<Game>();

            Assert.IsNull(response.Player1);
        }

        [Test]
        public void GetGameInfoRequest_WithTwoPlayers_ReturnsGameInfoWithPlayersResponse()
        {
            string name = "TestName";
            string localhostPort = "TestLocalHostPort_6154198";

            HttpRequests.GetRequest($"{Program.ServerIp}/Player/Create/{name}0/{localhostPort}");
            HttpRequests.GetRequest($"{Program.ServerIp}/Player/Create/{name}1/{localhostPort}");
            Game response = HttpRequests.GetRequest($"{Program.ServerIp}/Game").Deserialize<Game>();

            Assert.AreEqual(response.Player1.Name, name+"0");
            Assert.AreEqual(response.Player2.Name, name+"1");
            HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}0");
            HttpRequests.DeleteRequest($"{Program.ServerIp}/Player/Unregister/{name}1");
        }

    }
}