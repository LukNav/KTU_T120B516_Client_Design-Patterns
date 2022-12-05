using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WindowsFormsApplication
{
    public class Program
    {
        public static MenuForm MenuForm { get; private set; }
        public static GameForm GameForm { get; private set; }

        public static readonly string ProxyIp = "http://localhost:5269/Proxy";
        public static readonly string ServerIp = "https://localhost:7134";
        public static readonly string LocalHostPort = "5550";
        public static readonly bool ShouldUseProxy = true;

        [STAThread]
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().RunAsync();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MenuForm = new MenuForm();
            GameForm = new GameForm();
            Application.Run(MenuForm);
            Application.Run(GameForm);
            GameForm.Visible = false;
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls($"https://*:{LocalHostPort}")
                .UseStartup<Startup>();
    }
}