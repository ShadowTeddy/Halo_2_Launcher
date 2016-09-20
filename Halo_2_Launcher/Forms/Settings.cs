using Halo_2_Launcher.Objects;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Halo_2_Launcher
{
    public partial class Settings : MetroForm
    {
        public Settings()
        {
            InitializeComponent();
            #region SetControls
            this.widthTextBox.Text = H2Launcher.LauncherSettings.ResolutionWidth.ToString();
            this.heightTextBox.Text = H2Launcher.LauncherSettings.ResolutionHeight.ToString();
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                startingMonitorComboBox.Items.Add((i + 1).ToString() + ((Screen.AllScreens[i].Primary) ? " Primary" : ""));
                if (i == H2Launcher.LauncherSettings.StartingMonitor) startingMonitorComboBox.SelectedIndex = i;
            }
            this.windowModeComboBox.SelectedItem = H2Launcher.LauncherSettings.DisplayMode.ToString();
            this.vsyncToggle.Checked = H2Launcher.LauncherSettings.H2VSync;
            this.soundToggle.Checked = H2Launcher.LauncherSettings.Sound;
            this.introToggle.Checked = H2Launcher.LauncherSettings.Intro;
            this.xboxFOVToggle.Checked = H2Launcher.LauncherSettings.H2XFOV;
            #endregion
        }

        private void textBox_Numerical(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back))) e.Handled = true;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            H2Launcher.LauncherSettings.ResolutionHeight = int.Parse(this.heightTextBox.Text);
            H2Launcher.LauncherSettings.ResolutionWidth = int.Parse(this.widthTextBox.Text);
            H2Launcher.LauncherSettings.DisplayMode = (H2DisplayMode)Enum.Parse(typeof(H2DisplayMode), this.windowModeComboBox.SelectedItem.ToString());
            H2Launcher.LauncherSettings.StartingMonitor = startingMonitorComboBox.SelectedIndex;
            H2Launcher.LauncherSettings.H2VSync = vsyncToggle.Checked;
            H2Launcher.LauncherSettings.Sound = soundToggle.Checked;
            H2Launcher.LauncherSettings.Intro = introToggle.Checked;
            H2Launcher.LauncherSettings.H2XFOV = xboxFOVToggle.Checked;
            if (!introToggle.Checked)
            {
                if (!Directory.Exists(Paths.InstallPath + "\\movie.bak"))
                {
                    Directory.Move(Paths.InstallPath + "\\movie", Paths.InstallPath + "\\movie.bak");
                    Directory.CreateDirectory(Paths.InstallPath + "\\movie");
                    File.Create(Paths.InstallPath + "\\movie\\credits_60.wmv").Close();
                    File.Create(Paths.InstallPath + "\\movie\\intro_60.wmv").Close();
                    File.Create(Paths.InstallPath + "\\movie\\intro_low_60.wmv").Close();
                }
            }
            else
            {
                if (File.Exists(Paths.InstallPath + "\\movie.bak"))
                {
                    Directory.Delete(Paths.InstallPath + "\\movie", true);
                    Directory.Move(Paths.InstallPath + "\\movie.bak", Paths.InstallPath + "\\movie");
                }
            }
            H2Launcher.LauncherSettings.SaveSettings();
        }
    }
}
