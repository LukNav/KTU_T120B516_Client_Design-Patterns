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
        public static readonly string ServerIp = "https://localhost:7134";
        public static readonly string LocalHostPort = "5551";

        [STAThread]
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().RunAsync();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MenuForm = new MenuForm();
            Application.Run(MenuForm);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://*:5551")
                .UseStartup<Startup>();
    }
}