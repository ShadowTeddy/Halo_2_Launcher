using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using System.Runtime.InteropServices;
using Halo_2_Launcher.Controllers;
using Halo_2_Launcher.Objects;
namespace Halo_2_Launcher.Forms
{
    public partial class MainForm : MetroForm
    {
        //this.Style = (MetroFramework.MetroColorStyle)Enum.Parse(typeof(MetroFramework.MetroColorStyle), Globals.Settings.Color);
        private Settings _settings;
        private bool SettingsOpen = false;
        private bool RegisterMode = false;
        public MainForm()
        {
            this.ShadowType = MetroFormShadowType.None;
            InitializeComponent();
            H2Launcher.LauncherSettings.LoadSettings();
            this.rememberCheckBox.Checked = H2Launcher.LauncherSettings.RememberAccount;
            if (this.rememberCheckBox.Checked)
            {
                this.usernameTextBox.Text = H2Launcher.LauncherSettings.RememberUsername;
                this.passwordTextBox.Text = "PASSWORDHOLDERLOLOL";
            }
            this.metroLabel3.Visible = false;
            this.emailTextBox1.Visible = false;
            _settings = new Settings();
            _settings.FormClosed += _settings_Closed;
        }


        public void playButton_Click(object sender, EventArgs e)
        {
            
            if (!this.SettingsOpen)
            {
                if (!H2Launcher.LauncherSettings.RememberAccount)
                {
                    H2Launcher.WebControl.Login(this, usernameTextBox.Text, passwordTextBox.Text, rememberCheckBox.Checked);
                }
                else
                {
                    //if (H2Launcher.LauncherSettings.RememberToken != string.Empty)
                        H2Launcher.WebControl.RememberLogin(this, usernameTextBox.Text, H2Launcher.LauncherSettings.RememberToken, rememberCheckBox.Checked);
                    //else
                    //    H2Launcher.WebControl.Login(this, usernameTextBox.Text, passwordTextBox.Text, rememberCheckBox.Checked);
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "You cannot do that!" + Environment.NewLine + Environment.NewLine + "Close the settings menu before you launch the game.", "Wait a moment!", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this._settings.BringToFront();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        #region Settings
        private void settingsButton_Click(object sender, EventArgs e)
        {
            this._settings.Show();
            this._settings.SetDesktopLocation(this._settings.Location.X, (this.Location.Y + (this.Location.Y / 2)) - 20);
            this.SettingsOpen = true;
        }
        private void _settings_Closed(object sender, EventArgs e)
        {
            this.SettingsOpen = false;
            this._settings = new Settings();
            _settings.FormClosed += _settings_Closed;
        }
        #endregion 

        private void registerButton_Click(object sender, EventArgs e)
        {
            if(this.RegisterMode == false)
            {
                this.metroLabel3.Visible = true;
                this.emailTextBox1.Visible = true;
                this.registerButton.Width = 285;
                this.registerButton.Location = new System.Drawing.Point(23, 172);
                this.rememberCheckBox.Visible = false;
                this.emailTextBox1.Text = "";
                this.usernameTextBox.Text = "";
                this.passwordTextBox.Text = "";
                this.RegisterMode = true;
                this.Invalidate();
            } else if (this.RegisterMode == true)
            {
                this.metroLabel3.Visible = false;
                this.emailTextBox1.Visible = false;
                this.registerButton.Width = 86;
                this.registerButton.Location = new System.Drawing.Point(222, 172);
                this.RegisterMode = false;
                this.rememberCheckBox.Visible = true;
                this.Invalidate();
                H2Launcher.WebControl.Register(this, this.usernameTextBox.Text, this.passwordTextBox.Text);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {
            this.Text = Fun.GoIdioms;
            this.Invalidate();
        }
    }
}
