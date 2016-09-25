using Halo_2_Launcher.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halo_2_Launcher.Controllers
{
    public class XliveSettings
    {
        /*
         *   SetVariable("profile name 1 =", "Player");
            SetVariable("profile xuid 1 =", "0000000000000000");
            SetVariable("online profile =", "1");
            SetVariable("server =", "0");
            SetVariable("save directory =", "XLiveEmu");
            SetVariable("debug log =", "0");
            SetVariable("debug =", "0");
            SetVariable("altports =", "0");
            SetVariable("arguments =", "");
            SetVariable("install directory =", GlobalVariables.InstallPath);
            SaveConfigFile(GlobalVariables.InstallPath + "xlive.ini", ConfigFile);
         * 
         * */
        private string _ProfileName1 = "player 1";
        private int _Ports = 1000;
        private string _loginToken = "";
        private int _GunGame = 0;
        private string _InstallPath = "";
        public string ProfileName1
        {
            get { return this._ProfileName1; }
            set { this._ProfileName1 = value; }
        }
        public int Ports
        {
            get { return this._Ports; }
            set { this._Ports = value; }
        }
        public string loginToken
        {
            get { return this._loginToken; }
            set { this._loginToken = value; }
        }
        public int GunGame
        {
            get { return this._GunGame; }
            set { this._GunGame = value; }
        }
        public string InstallPath
        {
            get { return this._InstallPath; }
            set { this._InstallPath = value; }
        }
        public void SaveSettings()
        {
            //ADD SETTINGS CONTROLS FOR THE SETTINGS THAT NEED IT.
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("name = " + this.ProfileName1);
            SB.AppendLine("debug_log = " + 0);
            SB.AppendLine("port = " + this.Ports);
            SB.AppendLine("arguments = "); //Not needed as the launcher doesn't pass arguments they are built at runtime based off of the settings.
            SB.AppendLine("login_token = " + this.loginToken);
            SB.AppendLine("gungame = " + this.GunGame);
            SB.AppendLine("install_path = " + this.InstallPath);
            File.WriteAllText(Paths.InstallPath + "xlive.ini", SB.ToString());
        }
        public void LoadSettings()
        {
            if (!File.Exists(Paths.InstallPath + "xlive.ini")) SaveSettings();
            else
            {
                StreamReader SR = new StreamReader(Paths.InstallPath + "xlive.ini");
                string[] Lines = SR.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                SR.Close();
                SR.Dispose();
                foreach (string Line in Lines)
                {
                    string[] Setting = Line.Split(new string[] { " = " }, StringSplitOptions.None);
                    switch (Setting[0])
                    {
                        case "name":
                            {
                                this.ProfileName1 = Setting[1];
                                break;
                            }
                        case "port":
                            {
                                this.Ports = int.Parse(Setting[1]);
                                break;
                            }
                        case "login_token":
                            {
                                this.loginToken = Setting[1];
                                break;
                            }
                        case "install_path":
                            {
                                this.InstallPath = Setting[1];
                                break;
                            }
                    }
                }
            }
        }
    }
}
