using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halo_2_Launcher.Controllers.AntiCheat.Tags
{
    public class Weapons
    {
        private object[] Weapon = new object[]
        {
            new object[]
            {
                "Warthog Chaingun",
                0x7E48DC
            },
            new object[]
            {
                "Warthog Gauss",
                0x810A0C
            },
            new object[]
            {
                "Banshee Gun",
                0x83FF10
            },
            new object[]
            {
                "Ghost plasma bolt",
                0x86D5B8
            },
            new object[]
            {
                "Human Stationary Turret",
                0x879FE0
            },
            new object[]
            {
                "Scorpion Cannon",
                0x8AD420
            },
            new object[]
            {
                "Scorpion Cannon MP",
                0x8B74D0
            },
            new object[]
            {
                "Covenent Stationary Turret",
                0x8CD82C
            },
            new object[]
            {
                "Wraith Mortar Turret",
                0x9058D4
            },
            new object[]
            {
                "Wraith Turret",
                0x914BAC
            },
            new object[]
            {
                "Wraith Mortar Turret MP",
                0x9160E0
            },
            new object[]
            {
                "Specter Turret",
                0x93CDE4
            },
            new object[]
            {
                "Covenent Small Stationary Turret",
                0x94EA98
            },
            new object[]
            {
                "Magnum",
                0x96E778
            },
            new object[]
            {
                "Needler",
                0x9C0A00
            },
            new object[]
            {
                "Plasma Pistol",
                0xA02D34
            },
            new object[]
            {
                "Battle Rifle",
                0xA49548
            },
            new object[]
            {
                "Carbine",
                0xA7BE18
            },
            new object[]
            {
                "Plasma Rifle",
                0xAAE094
            },
            new object[]
            {
                "Shotgun",
                0xAF18C8
            },
            new object[]
            {
                "SMG",
                0xB1E18C
            },
            new object[]
            {
                "Sniper Rifle",
                0xB79E84
            },
            new object[]
            {
                "Flak Cannon",
                0xBAE650
            },
            new object[]
            {
                "Rocket Launcher",
                0xBDBA4C
            },
            new object[]
            {
                "Brute Shot",
                0xC0E63C
            },
            new object[]
            {
                "Assault Bomb",
                0xC5D044
            },
            new object[]
            {
                "Ball",
                0xC9C4FC
            },
            new object[]
            {
                "Flag",
                0xC9E894
            },
            new object[]
            {
                "Energy Sword",
                0xCC5964
            },
            new object[]
            {
                "Emergy Sword Empty",
                0xCC9F40
            },
            new object[]
            {
                "Beam Rifle",
                0xCE0008
            },
            new object[]
            {
                "Brute Plasma Rifle",
                0xD0F4EC
            },
            new object[]
            {
                "Sentinal Beam",
                0xD1456C
            },
            new object[]
            {
                "Juggernaut Ball",
                0xE742EC
            },
            new object[]
            {
                "SMG Silenced",
                0xD32C9C
            }
        };
        //private int[] TagBaseOffsetArray = new int[]
        //{
        //    0x7E48DC, //Warthog Chaingun
        //    0x810A0C, //Warthog Gauss
        //    0x83FF10, //Banshee Gun
        //    0x86D5B8, //Ghost plasma bolt
        //    0x879FE0, //Human Stationary Turret
        //    0x8AD420, //Scorpion Cannon
        //    0x8B74D0, //Scorpion Cannon MP
        //    0x8CD82C, //Covenent Stationary Turret
        //    0x9058D4, //Wraith Mortar Turret
        //    0x914BAC, //Wraith Turret
        //    0x9160E0, //Wraith Mortar Turret MP
        //    0x93CDE4, //Specter Turret
        //    0x94EA98, //Covenent Small Stationary Turret
        //    0x96E778, //Magnum
        //    0x9C0A00, //Needler
        //    0xA02D34, //Plasma Pistol
        //    0xA49548, //Battle Rifle
        //    0xA7BE18, //Carbine
        //    0xAAE094, //Plasma Rifle
        //    0xAF18C8, //Shotgun
        //    0xB1E18C, //SMG
        //    0xB79E84, //Sniper Rifle Gun
        //    0xBAE650, //Flak Cannon (Fuel Rod)
        //    0xBDBA4C, //Rocket Launcher Gun
        //    0xC0E63C, //Brute Shot
        //    0xC5D044, //Assault Bomb
        //    0xC9C4FC, //Ball
        //    0xC9E894, //Flag
        //    0xCC5964, //Energy Sword
        //    0xCC9F40, //Emergy Sword Empty
        //    0xCE0008, //Beam Rifle
        //    0xD0F4EC, //Brute Plasma Rifle
        //    0xD1456C, //Sentinal Beam
        //    0xE742EC, //Juggernaut Ball
        //    0xD32C9C  //SMG Silenced
        //};


        public object[] Properties = new object[]
        {
            new object[]
            {
                "MeleeAAMagnitismAngleOffset",
                0x19C,
                "Single"
            },
            new object[]
            {
                "MeleeAAMagnitismRangeOffset",
                0x1A0,
                "Single"
            },
            new object[]
            {
                "MeleeAAThrottleMagnitudeOffset",
                0x1A4,
                "Single"
            },
            new object[]
            {
                "MeleeAAThrottleMinDistanceOffset",
                0x1A8,
                "Single"
            },
            new object[]
            {
                "MeleeAAThrottleMaxAdjustmentAgleOffset",
                0x1AC,
                "Single"
            },
            new object[]
            {
                "AAAngleOffset",
                0x208,
                "Single"
            },
            new object[]
            {
                "AARangeOffset",
                0x20C,
                "Single"
            },
            new object[]
            {
                "MagnetismAngleOffset",
                0x210,
                "Single"
            },
            new object[]
            {
                "MagnetismRangeOffset",
                0x214,
                "Single"
            },
            new object[]
            {
                "DeviationAngleOffset",
                0x21C,
                "Single"
            },
            new object[]
            {
                "BarrelReflexive",
                0x2D0, //Offset to the count of the Relfexive Property +0x4 to get the offset of the properties of the Relfexive
                "Reflexive",
                0xEC, //Size of each object inside of the relfexive (MapPointer[TagBase + Offset] + [i * Size])
                new object[] //Reflexive properties bassed off the offset from +0x4 the reflexive count
                {
                    new object[]
                    {
                        "RoundsPerSecondMinOffset",
                        0x4,
                        "Single"
                    },
                    new object[]
                    {
                        "RoundsPerSecondMaxOffset",
                        0x8,
                        "Single"
                    },
                    new object[]
                    {
                        "ShotsPerFireUpperOffset",
                        0x1C,
                        "Int16"
                    },
                    new object[]
                    {
                        "ShotsPerFireLowerOffset",
                        0x1E,
                        "Int16"
                    },
                    new object[]
                    {
                        "FireRecoveryTimeOffset",
                        0x20,
                        "Single"
                    },
                    new object[]
                    {
                        "MagazineOffset",
                        0x28,
                        "Int16"
                    },
                    new object[]
                    {
                        "RoundsPerShotOffset",
                        0x2A,
                        "Int16"
                    },
                    new object[]
                    {
                        "ErrorAccelerationTimeOffset",
                        0x38,
                        "Single"
                    },
                    new object[]
                    {
                        "ErrorDecelerationTimeOffset",
                        0x3C,
                        "Single"
                    },
                    new object[]
                    {
                        "ProjectilesPerShotOffset",
                        0x6A,
                        "Int16"
                    },
                    new object[]
                    {
                        "ErrorAngleMin",
                        0x74,
                        "Single"
                    },
                    new object[]
                    {
                        "ErrorAngleMax",
                        0x78,
                        "Single"
                    },
                    new object[]
                    {
                        "HeatGeneratedPerRoundOffset",
                        0xA4,
                        "Single"
                    },
                    new object[]
                    {
                        "OverloadTimeSecOffset",
                        0xA8,
                        "Single"
                    }
                }
            }
        };
        //private int MeleeAAMagnitismAngleOffset = 0x19C;
        //private int MeleeAAMagnitismRangeOffset = 0x1A0;
        //private int MeleeAAThrottleMagnitudeOffset = 0x1A4;
        //private int MeleeAAThrottleMinDistanceOffset = 0x1A8;
        //private int MeleeAAThrottleMaxAdjustmentAgleOffset = 0x1AC;
        //private int AAAngleOffset = 0x208;
        //private int AARangeOffset = 0x20C;
        //private int MagnetismAngleOffset = 0x210;
        //private int MagnetismRangeOffset = 0x214;
        //private int DeviationAngleOffset = 0x21C;

        //private int BarrelReflexiveCountOffset = 0x2D0;
        //private int BarrelReflexiveOffset = 0x2D4;
        //private int RoundsPerSecondMinOffset = 0x4;
        //private int RoundsPerSecondMaxOffset = 0x8;
        //private int ShotsPerFireUpperOffset = 0x1C; //Short
        //private int ShotsPerFireLowerOffset = 0x1E; //Short
        //private int FireRecoveryTimeOffset = 0x20;
        //private int MagazineOffset = 0x28; //Short
        //private int RoundsPerShotOffset = 0x2A; //Short
        //private int ErrorAccelerationTimeOffset = 0x38;
        //private int ErrorDecelerationTimeOffset = 0x3C;
        //private int ProjectilesPerShotOffset = 0x6A;
        //private int ErrorAngleMin = 0x74;
        //private int ErrorAngleMax = 0x78;
        //private int HeatGeneratedPerRoundOffset = 0xA4;
        //private int OverloadTimeSecOffset = 0xA8;
        /*
         * 
         * When i start again change the offsets to a object[object[]] that contains (name, offset, type) for easier parsing.
         * 
         * */
        public void GhettoRipping()
        {
            foreach (object[] Weapon in this.Weapon)
            {
                StringBuilder Bartley = new StringBuilder();
                string WeaponName = (string)Weapon[0];
                int WeaponOffset = (int)Weapon[1];
                Bartley.AppendLine(string.Format("{0}", WeaponName));
                foreach (object[] Property in this.Properties)
                {
                    string PropertyName = (string)Property[0];
                    int PropertyOffset = (int)Property[1];
                    string PropertyType = (string)Property[2];
                    int tOffset = H2Launcher.MapPointer(WeaponOffset + PropertyOffset);
                    switch (PropertyType)
                    {
                        case "Single": //Float
                            {
                                float tValue = H2Launcher.Memory.ReadFloat(0, tOffset);
                                Bartley.AppendLine(string.Format("{0}:{1}:{2}", PropertyName, PropertyOffset.ToString("X"), tValue.ToString()));
                                break;
                            }
                        case "Int16": //Short
                            {
                                short tValue = H2Launcher.Memory.ReadShort(0, tOffset);
                                Bartley.AppendLine(string.Format("{0}:{1}:{2}", PropertyName, PropertyOffset.ToString("X"), tValue.ToString()));
                                break;
                            }
                        case "Reflexive":
                            {
                                int rCount = H2Launcher.Memory.ReadInt(0, tOffset);
                                int rRawOffset = H2Launcher.Memory.ReadInt(0, tOffset + 4);
                                int rOffset = H2Launcher.MapPointer(rRawOffset);
                                int rSize = (int)Property[3];
                                Bartley.AppendLine(string.Format("{0}:{1}:{2}", PropertyName, rRawOffset.ToString("X"), rCount.ToString()));
                                for (int i = 0; i < rCount; i++) //Loop through every part of the Reflexive
                                {
                                    int pOffset = rSize * i;//To reach the next property size of each object * i.
                                    Bartley.AppendLine(string.Format("\t{0}", i.ToString()));
                                    foreach (object[] rProperty in (object[])Property[4])
                                    {
                                        string rPropertyName = (string)rProperty[0];
                                        int rPropertyOffset = rOffset + pOffset + (int)rProperty[1];
                                        string rPropertyType = (string)rProperty[2];
                                        switch (rPropertyType)
                                        {
                                            case "Single":
                                                {
                                                    float tValue = H2Launcher.Memory.ReadFloat(0, rPropertyOffset);
                                                    Bartley.AppendLine(string.Format("\t\t{0}:{1}:{2}", rPropertyName, rPropertyOffset.ToString("X"), tValue.ToString()));
                                                    break;
                                                }
                                            case "Int16": //Short
                                                {
                                                    short tValue = H2Launcher.Memory.ReadShort(0, rPropertyOffset);
                                                    Bartley.AppendLine(string.Format("\t\t{0}:{1}:{2}", rPropertyName, rPropertyOffset.ToString("X"), tValue.ToString()));
                                                    break;
                                                }
                                        }
                                    }
                                }
                            }
                            break;
                    }
                }
                File.WriteAllText(Application.StartupPath + "\\AntiCheat\\" + WeaponName + ".txt", Bartley.ToString());
                int ss = 0;
            }
}
        public class Reflexive
        {

        }
    }
}
