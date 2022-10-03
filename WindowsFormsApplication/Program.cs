using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WindowsFormsApplication
{
    public class Program
    {
        public static Form1 MainForm { get; private set; }
        public static readonly string ServerIp = "https://localhost:7134";
        public static readonly string LocalHostPort = "5501";

        [STAThread]
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().RunAsync();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Form1();
            Application.Run(MainForm);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("https://*:5501")
                .UseStartup<Startup>();
    }
}