using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NimbusFox.ServerGui.Classes;

namespace NimbusFox.ServerGui {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Global.Main = new Main();
            Global.Settings = new Settings();
            Application.Run(Settings.InitSettings ? Global.Settings : (Form)Global.Main);
        }
    }
}
