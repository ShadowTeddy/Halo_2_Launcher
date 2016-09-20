using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Halo_2_Launcher.Controllers.Tags.Properties;
namespace Halo_2_Launcher.Controllers.Tags
{
    public interface TagBase
    {
        TagTypes Type
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

    public class Tag :  TagBase
    {
        private TagTypes _Type;
        private string _Name;
        public TagTypes Type
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
    public class TagProperties : System.Collections.CollectionBase, System.Collections.IEnumerable
    {
        public void Add(TagProperty TagProperty)
        {
            this.Add(TagProperty);
        }
        public TagProperty this[int i]
        {
            get
            {
                return (TagProperty)this[i];
            }
        }
        public TagProperty this[string name]
        {
            get
            {
                foreach(Object TagProperty in this)
                    if (((TagProperty)TagProperty).Name == name)
                        return (TagProperty)TagProperty;
                throw new Exception("No Tag Property with that name was found");
            }
        }
    }

}
