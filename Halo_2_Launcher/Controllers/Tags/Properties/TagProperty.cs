using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halo_2_Launcher.Controllers.Tags.Properties
{
    public interface TagPropertyBase
    {
        MetaTypes Type
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
    }
    public class TagProperty : TagPropertyBase
    {
        private MetaTypes _Type;
        private string _Name;
        public MetaTypes Type
        {
            get { return this._Type; }
            set { this._Type = value; }
        }
        public string Name
        {
            get { return this._Name; }
            set { this._Name = value; }
        }
    }
}
