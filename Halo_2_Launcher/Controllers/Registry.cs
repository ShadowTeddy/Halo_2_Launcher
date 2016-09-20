using Halo_2_Launcher.Objects;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Halo_2_Launcher.Controllers
{
    public static class RegistryControl
    {
        public static void SetScreenResX(int X)
        {
            SetVideoSetting("ScreenResX", X);
        }
        public static void SetScreenResY(int Y)
        {
            SetVideoSetting("ScreenResY", Y);
        }
        public static void SetDisplayMode(bool FullScreen)
        {
            SetVideoSetting("DisplayMode", (FullScreen) ? 0 : 1);
        }
        public static int GetScreenResX()
        {
            return (int)GetVideoSetting("ScreenResX");
        }
        public static int GetScreenResY()
        {
            return (int)GetVideoSetting("ScreenResY");
        }
        public static H2DisplayMode  GetDisplayMode()
        {
            return (((int)GetVideoSetting("DisplayMode") == 1) ? H2DisplayMode.Windowed : H2DisplayMode.Fullscreen);
        }
        private static void SetVideoSetting(string Setting, object Value)
        {
            Registry.SetValue(Paths.H2RegistryBase + "Video Settings", Setting, Value);
        }
        private static object GetVideoSetting(string Setting)
        {
            return Registry.GetValue(Paths.H2RegistryBase + "Video Settings", Setting, null);
        }
    }
}
