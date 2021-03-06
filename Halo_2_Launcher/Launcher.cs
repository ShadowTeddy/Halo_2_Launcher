﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Halo_2_Launcher.Objects;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using Halo_2_Launcher.Controllers;
using System.Diagnostics;
using MetroFramework.Forms;
using System.IO;
namespace Halo_2_Launcher
{
    public static class H2Launcher
    {

        private static Halo_2_Launcher.Controllers.Settings _LauncherSettings;
        private static Game _Game;
        private static PostLaunch _Post;
        private static ProcessMemory _Memory;
        private static WebHandler _WebControl;
        private static XliveSettings _XliveSettings;
        public static string ToolVersion = "1.0";
        public static Halo_2_Launcher.Controllers.Settings LauncherSettings
        { get { if (H2Launcher._LauncherSettings == null) { H2Launcher._LauncherSettings = new Halo_2_Launcher.Controllers.Settings(); } return H2Launcher._LauncherSettings; } }
        public static XliveSettings XliveSettings
        { get { if (H2Launcher._XliveSettings == null) { H2Launcher._XliveSettings = new XliveSettings(); } return H2Launcher._XliveSettings; } }
        public static Game H2Game
        { get { if (_Game == null) { _Game = new Game(); } return _Game; } }
        public static PostLaunch Post
        { get { if (H2Launcher._Post == null) { H2Launcher._Post = new PostLaunch(); } return H2Launcher._Post; } }
        public static ProcessMemory Memory
        { get { if (H2Launcher._Memory == null) { H2Launcher._Memory = new ProcessMemory("halo2"); } return H2Launcher._Memory; } }
        public static WebHandler WebControl
        { get { if (H2Launcher._WebControl == null) { H2Launcher._WebControl = new WebHandler(); } return H2Launcher._WebControl; } }
        public static int MapPointer(int Offset)
        {
            //This function needs a home in the future.
            return Memory.Pointer(0, true, 0x47CD54, Offset);
        }
        public static async void StartHalo(string Gamertag, string LoginToken, MetroForm Form)
        {
            Form.Hide();
            XliveSettings.ProfileName1 = Gamertag;
            XliveSettings.loginToken = LoginToken;
            XliveSettings.SaveSettings();
            LauncherSettings.SaveSettings();
            await Task.Delay(1);
            //File.WriteAllLines(Paths.InstallPath + "token.ini", new string[] { "token=" + LoginToken, "username=" + Gamertag });
            H2Game.RunGame();
            while (Process.GetProcessesByName("halo2").Length == 1)
            {
                //DURING HALO RUNNING THREAD
                await Task.Delay(1);
            }
            Form.Show();
        }
    }
}
