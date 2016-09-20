using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Halo_2_Launcher.Objects;
using System.Diagnostics;
namespace Halo_2_Launcher.Controllers
{
    public class Game
    {
        public void SetXboxFOV()
        {
            H2Launcher.Memory.WriteFloat(0, true, 0x41D984, 1.13f);//player
            H2Launcher.Memory.WriteFloat(0, true, 0x413780, .943f);//vehicle
        }
        public void ApplyCrashFix()
        {
            H2Launcher.Memory.WriteFloat(0, true, 0x464940, 0);
            H2Launcher.Memory.WriteFloat(0, true, 0x46494C, 0);
            H2Launcher.Memory.WriteFloat(0, true, 0x464958, 0);
            H2Launcher.Memory.WriteFloat(0, true, 0x464964, 0);
        }
        public void RunGame()
        {
            ProcessStartInfo Info = new ProcessStartInfo();
            Info.WorkingDirectory = Paths.InstallPath;
            Info.FileName = "halo2.exe";

            RegistryControl.SetScreenResX(H2Launcher.LauncherSettings.ResolutionWidth);
            RegistryControl.SetScreenResY(H2Launcher.LauncherSettings.ResolutionHeight);
            switch (H2Launcher.LauncherSettings.DisplayMode)
            {
                case H2DisplayMode.Windowed:
                    {
                        Info.Arguments += "-windowed ";
                        RegistryControl.SetDisplayMode(false);
                        H2Launcher.Post.AddCommand("SetWindowResolution", new object[] { H2Launcher.LauncherSettings.ResolutionWidth, H2Launcher.LauncherSettings.ResolutionHeight });
                        break;
                    }
                case H2DisplayMode.Fullscreen:
                    {
                        RegistryControl.SetDisplayMode(true);
                        Info.Arguments += "-monitor:" + H2Launcher.LauncherSettings.StartingMonitor.ToString() + " ";
                        break;
                    }
                case H2DisplayMode.Borderless:
                    {
                        Info.Arguments += "-windowed ";
                        RegistryControl.SetDisplayMode(false);
                        H2Launcher.Post.AddCommand("SetWindowBorderless");
                        H2Launcher.Post.AddCommand("SetWindowResolution", new object[] { H2Launcher.LauncherSettings.ResolutionWidth, H2Launcher.LauncherSettings.ResolutionHeight });
                        break;
                    }

            }
            H2Launcher.XliveSettings.SaveSettings();
            if (!H2Launcher.LauncherSettings.Sound) Info.Arguments += "-nosound ";
            if (!H2Launcher.LauncherSettings.H2VSync) Info.Arguments += "-novsync ";
            if (H2Launcher.LauncherSettings.H2XFOV) H2Launcher.Post.AddCommand("SetXboxFOV");
            H2Launcher.Post.AddCommand("ApplyCrashFix");
            Process.Start(Info);
            H2Launcher.Post.RunCommands();
        }
    }
}
