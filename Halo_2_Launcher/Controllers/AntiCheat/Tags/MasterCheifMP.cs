using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halo_2_Launcher.Controllers.AntiCheat.Tags
{
    public class MasterCheifMP
    {
        private int TagBaseOffset = 0xE61030;
        public int JumpVelocity
        {
            get
            {
               return H2Launcher.Memory.ReadInt(0, H2Launcher.MapPointer(this.TagBaseOffset + 0x1F8)); //0x1F8 is the offset to the Jump Velocity inside of Halo 2
            }
        }
    }
}
