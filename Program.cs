using TeraziAPI.Controller;
using TeraziAPI.Utility;
using TeraziAPI.View;
using Microsoft.Owin.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace TeraziAPI
{
    internal static class Program
    {
        #region Definitions

        public static Serial Serial;
        public static string Values { get; set; }
        public static Settings Settings { get; set; }
        public static ProcessIcon processIcon { get; set; }

        #endregion Definitions

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Program.Settings = new Settings();
                if (!File.Exists(@"settings.json"))
                {
                    Settings.BaseAddress = "http://localhost:6161/";

                    Settings.WriteJsonSettings(Settings);
                }

                Settings = Settings.ReadSettings();

                Program.processIcon = new ProcessIcon();
                processIcon.Display();
                processIcon.ShowNotification("Uygulama başlatılıyor", "Terazi API", ToolTipIcon.None, 500);
                processIcon.Dispose();

                ////while (Program.Serial == null || Program.Serial.SerialObject == null)
                ////{
                    Program.Serial = new Serial();
                ////}                                

                Thread.Sleep(250);

                WebApp.Start<Startup>(url: Settings.BaseAddress);

                Program.processIcon = new ProcessIcon();
                processIcon.Display();
                processIcon.ShowNotification("Uygulama başladı", "Terazi API Bilgi:", ToolTipIcon.None, 500);

                Application.Run();
            }
            catch (Exception ex)
            {
                Program.Values = $"Error: {ex.Message}";
            }
        }

    }
}