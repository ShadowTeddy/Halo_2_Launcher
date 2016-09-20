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
        private string _ProfileName1;
        private string _ProfileXUID1;
        private int _OnlineProfile;
        private int _Debug;
        private int _AltPorts;
        public string ProfileName1
        {
            get { return this._ProfileName1; }
            set { this._ProfileName1 = value; }
        }
        public string ProfileXUID1
        {
            get { return this._ProfileXUID1; }
            set { this._ProfileXUID1 = value; }
        }
        public int OnlineProfile
        {
            get { return this._OnlineProfile; }
            set { this._OnlineProfile = value; }
        }
        public int Debug
        {
            get { return this._Debug; }
            set { this._Debug = value; }
        }
        public int AltPorts
        {
            get { return this._AltPorts; }
            set { this._AltPorts = value; }
        }
        public void SaveSettings()
        {
            //ADD SETTINGS CONTROLS FOR THE SETTINGS THAT NEED IT.
            StringBuilder SB = new StringBuilder();
            SB.AppendLine("profile name 1 = " + this.ProfileName1);
            SB.AppendLine("profile xuid 1 = " + this.ProfileXUID1.PadLeft(16, '0'));
            SB.AppendLine("online profile = " + this.OnlineProfile);
            SB.AppendLine("save directory = XLiveEmu");
            SB.AppendLine("server = " + 0);
            SB.AppendLine("debug log = " + 0);
            SB.AppendLine("debug = " + this.Debug);
            SB.AppendLine("altports = " + this.AltPorts);
            SB.AppendLine("arguments = " + Paths.InstallPath);
            File.WriteAllText(Paths.InstallPath + "xlive.ini", SB.ToString());
        }
    }
}
