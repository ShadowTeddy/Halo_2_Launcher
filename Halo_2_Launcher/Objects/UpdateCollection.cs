using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halo_2_Launcher.Objects
{
    public class UpdateCollection : System.Collections.CollectionBase, System.Collections.IEnumerable
    {
        public void AddObject(UpdateObject UO)
        {
            this.List.Add(UO);
        }
        public UpdateObject this[int i]
        {
            get
            {
                return (UpdateObject)List[i];
            }
            set
            {
                    List[i] = value;
            }
        }
        public UpdateObject this[string name]
        {
            get
            {
                for (int i = 0; i < List.Count; i++)
                    if (((UpdateObject)List[i]).name == name)
                        return ((UpdateObject)List[i]);
                return null;
            }
            set
            {
                for (int i = 0; i < List.Count; i++)
                    if (((UpdateObject)List[i]).name == name)
                        List[i] = value;
            }
        }
    }
    public class UpdateObject: object
    {
        public string name;
        public string version;
        private string _localpath;
        private string _remotepath;
        public bool replaceoriginal;
        public string remotepath
        {
            get
            {
                return FormatPath(this._remotepath);
            }
            set
            {
                this._remotepath = value;
            }
        }
        public string localpath
        {
            get
            {
                return FormatPath(this._localpath);
            }
            set
            {
                this._localpath = value;
            }
        }
        private string FormatPath(string str)
        {
            string tString = str;
            tString = tString.Replace("{Version}", this.version);
            tString = tString.Replace("{InstallDir}", Paths.InstallPath);
            tString = tString.Replace("{Files}", Paths.Files);
            tString = tString.Replace("{LauncherDir}", Paths.LauncherPath);
            tString = tString.Replace("{RemoteDir}", Paths.RemoteUpdatePath);
            tString = tString.Replace("{AppDir}", Application.StartupPath);
            return tString;
        }
        public override bool Equals(object UO) 
        {
            UpdateObject tUO = ((UpdateObject)UO);
            if (UO == null)
                return false;
            else
            {
                if (this.localpath == tUO.localpath && this.remotepath == tUO.remotepath && this.name == tUO.name && this.version == tUO.version)
                    return true;
                return false;
            }
        }
        public override int GetHashCode()
        {
            //lel
            int tHash = 0;
            foreach(char c in name)
                tHash += c.GetHashCode();
            return tHash;
        }
    }
}