using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halo_2_Launcher.Controllers.AntiCheat.Tags
{
    public class MultiplayerGlobals
    {
        private int TagBaseOffset = 0x3C000;
        private int PlayerInformationOffset = 0x134; // 0x130 = Count of reflexive properties.
        public float PlayerWalkingSpeed
        {
            get
            {
                return H2Launcher.Memory.ReadFloat(0, H2Launcher.MapPointer(ResolveReflexiveOffset(PlayerInformationOffset) + 0x24));
            }
        }
        public float PlayerForwardSpeed
        {
            get
            {
                return H2Launcher.Memory.ReadFloat(0, H2Launcher.MapPointer(ResolveReflexiveOffset(PlayerInformationOffset) + 0x2C));
            }
        }
        public float PlayerBackwardSpeed
        {
            get
            {
                return H2Launcher.Memory.ReadFloat(0, H2Launcher.MapPointer(ResolveReflexiveOffset(PlayerInformationOffset) + 0x30));
            }
        }
        public float PlayerSidewaysSpeed
        {
            get
            {
                return H2Launcher.Memory.ReadFloat(0, H2Launcher.MapPointer(ResolveReflexiveOffset(PlayerInformationOffset) + 0x34));
            }
        }
        public float PlayerRunAcceleration
        {
            get
            {
                return H2Launcher.Memory.ReadFloat(0, H2Launcher.MapPointer(ResolveReflexiveOffset(PlayerInformationOffset) + 0x38));
            }
        }
        private int ResolveReflexiveOffset(int Offset)
        {
            return H2Launcher.Memory.ReadInt(0, H2Launcher.MapPointer(TagBaseOffset + Offset));
        }
    }
}
