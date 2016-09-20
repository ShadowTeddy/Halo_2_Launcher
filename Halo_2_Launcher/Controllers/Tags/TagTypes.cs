using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halo_2_Launcher.Controllers.Tags
{
    public enum TagTypes
    {
        weap
    }
    public enum MetaTypes
    {
        unused,
        bitmask32, //Add Option parsing inside the bitmask32 object not specify it as a new metatype
        tfloat, //Can't use float as an enum type
        enum16,//Add Option parsing inside the enum16 object not specify it as a new metatype
        enum32, //Add Option parsing inside the enum32 object not specify it as a new metatype
        stringid,
        reflexive,
        tShort,//Can't use short as an enum tpye
        ident //Tag Selector
    }
}
