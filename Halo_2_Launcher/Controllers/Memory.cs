using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Media;

namespace Halo_2_Launcher.Controllers
{
    public class ProcessMemory
    {
        #region Flags
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }
        public enum VirtualKeyStates : int
        {
            VK_LBUTTON = 0x01,
            VK_RBUTTON = 0x02,
            VK_CANCEL = 0x03,
            VK_MBUTTON = 0x04,
            //
            VK_XBUTTON1 = 0x05,
            VK_XBUTTON2 = 0x06,
            //
            VK_BACK = 0x08,
            VK_TAB = 0x09,
            //
            VK_CLEAR = 0x0C,
            VK_RETURN = 0x0D,
            //
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_MENU = 0x12,
            VK_PAUSE = 0x13,
            VK_CAPITAL = 0x14,
            //
            VK_KANA = 0x15,
            VK_HANGEUL = 0x15,  /* old name - should be here for compatibility */
            VK_HANGUL = 0x15,
            VK_JUNJA = 0x17,
            VK_FINAL = 0x18,
            VK_HANJA = 0x19,
            VK_KANJI = 0x19,
            //
            VK_ESCAPE = 0x1B,
            //
            VK_CONVERT = 0x1C,
            VK_NONCONVERT = 0x1D,
            VK_ACCEPT = 0x1E,
            VK_MODECHANGE = 0x1F,
            //
            VK_SPACE = 0x20,
            VK_PRIOR = 0x21,
            VK_NEXT = 0x22,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_SELECT = 0x29,
            VK_PRINT = 0x2A,
            VK_EXECUTE = 0x2B,
            VK_SNAPSHOT = 0x2C,
            VK_INSERT = 0x2D,
            VK_DELETE = 0x2E,
            VK_HELP = 0x2F,
            //
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            VK_APPS = 0x5D,
            //
            VK_SLEEP = 0x5F,
            //
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_F13 = 0x7C,
            VK_F14 = 0x7D,
            VK_F15 = 0x7E,
            VK_F16 = 0x7F,
            VK_F17 = 0x80,
            VK_F18 = 0x81,
            VK_F19 = 0x82,
            VK_F20 = 0x83,
            VK_F21 = 0x84,
            VK_F22 = 0x85,
            VK_F23 = 0x86,
            VK_F24 = 0x87,
            //
            VK_NUMLOCK = 0x90,
            VK_SCROLL = 0x91,
            //
            VK_OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
            //
            VK_OEM_FJ_JISHO = 0x92,   // 'Dictionary' key
            VK_OEM_FJ_MASSHOU = 0x93,   // 'Unregister word' key
            VK_OEM_FJ_TOUROKU = 0x94,   // 'Register word' key
            VK_OEM_FJ_LOYA = 0x95,   // 'Left OYAYUBI' key
            VK_OEM_FJ_ROYA = 0x96,   // 'Right OYAYUBI' key
            //
            VK_LSHIFT = 0xA0,
            VK_RSHIFT = 0xA1,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_LMENU = 0xA4,
            VK_RMENU = 0xA5,
            //
            VK_BROWSER_BACK = 0xA6,
            VK_BROWSER_FORWARD = 0xA7,
            VK_BROWSER_REFRESH = 0xA8,
            VK_BROWSER_STOP = 0xA9,
            VK_BROWSER_SEARCH = 0xAA,
            VK_BROWSER_FAVORITES = 0xAB,
            VK_BROWSER_HOME = 0xAC,
            //
            VK_VOLUME_MUTE = 0xAD,
            VK_VOLUME_DOWN = 0xAE,
            VK_VOLUME_UP = 0xAF,
            VK_MEDIA_NEXT_TRACK = 0xB0,
            VK_MEDIA_PREV_TRACK = 0xB1,
            VK_MEDIA_STOP = 0xB2,
            VK_MEDIA_PLAY_PAUSE = 0xB3,
            VK_LAUNCH_MAIL = 0xB4,
            VK_LAUNCH_MEDIA_SELECT = 0xB5,
            VK_LAUNCH_APP1 = 0xB6,
            VK_LAUNCH_APP2 = 0xB7,
            //
            VK_OEM_1 = 0xBA,   // ';:' for US
            VK_OEM_PLUS = 0xBB,   // '+' any country
            VK_OEM_COMMA = 0xBC,   // ',' any country
            VK_OEM_MINUS = 0xBD,   // '-' any country
            VK_OEM_PERIOD = 0xBE,   // '.' any country
            VK_OEM_2 = 0xBF,   // '/?' for US
            VK_OEM_3 = 0xC0,   // '`~' for US
            //
            VK_OEM_4 = 0xDB,  //  '[{' for US
            VK_OEM_5 = 0xDC,  //  '\|' for US
            VK_OEM_6 = 0xDD,  //  ']}' for US
            VK_OEM_7 = 0xDE,  //  ''"' for US
            VK_OEM_8 = 0xDF,
            //
            VK_OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
            VK_OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
            VK_ICO_HELP = 0xE3,  //  Help key on ICO
            VK_ICO_00 = 0xE4,  //  00 key on ICO
            //
            VK_PROCESSKEY = 0xE5,
            //
            VK_ICO_CLEAR = 0xE6,
            //
            VK_PACKET = 0xE7,
            //
            VK_OEM_RESET = 0xE9,
            VK_OEM_JUMP = 0xEA,
            VK_OEM_PA1 = 0xEB,
            VK_OEM_PA2 = 0xEC,
            VK_OEM_PA3 = 0xED,
            VK_OEM_WSCTRL = 0xEE,
            VK_OEM_CUSEL = 0xEF,
            VK_OEM_ATTN = 0xF0,
            VK_OEM_FINISH = 0xF1,
            VK_OEM_COPY = 0xF2,
            VK_OEM_AUTO = 0xF3,
            VK_OEM_ENLW = 0xF4,
            VK_OEM_BACKTAB = 0xF5,
            //
            VK_ATTN = 0xF6,
            VK_CRSEL = 0xF7,
            VK_EXSEL = 0xF8,
            VK_EREOF = 0xF9,
            VK_PLAY = 0xFA,
            VK_ZOOM = 0xFB,
            VK_NONAME = 0xFC,
            VK_PA1 = 0xFD,
            VK_OEM_CLEAR = 0xFE
        }
        #endregion
        #region APIs


        [DllImport("user32.dll")]
        public static extern short GetKeyState(Keys nVirtKey);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesRead);
        [DllImport("kernel32.dll")]
        //public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, Uint nSize, out int lpNumberOfBytesWritten);
        public static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(int hObject);
        [DllImport("kernel32.dll")]
        public static extern bool VirtualProtectEx(int hProcess, int lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        // Find window by Caption only. Note you must pass 0 as the first parameter.
        public static extern int FindWindowByCaption(int ZeroOnly, string lpWindowName);
        //public static extern short GetKeyState(VirtualKeyStates nVirtKey);
        #endregion
        #region Const

        const uint PAGE_NOACCESS = 1;
        const uint PAGE_READONLY = 2;
        const uint PAGE_READWRITE = 4;
        const uint PAGE_WRITECOPY = 8;
        const uint PAGE_EXECUTE = 16;
        const uint PAGE_EXECUTE_READ = 32;
        const uint PAGE_EXECUTE_READWRITE = 64;
        const uint PAGE_EXECUTE_WRITECOPY = 128;
        const uint PAGE_GUARD = 256;
        const uint PAGE_NOCACHE = 512;
        const uint PROCESS_ALL_ACCESS = 0x1F0FFF;

        #endregion
        protected string ProcessName;
        protected Process[] MyProcess;
        protected int[] processHandle;
        protected int[] processID;
        protected static int[] BaseAddress;
        protected static int SvrCt;
        public bool Check;
        List<int> procstore;
        public ProcessMemory(string pProcessName)
        {
            ProcessName = pProcessName;
            if (this.StartProcess())
            {
                if (this.ProcessCount != 0)
                    Check = true;
            }
            else
            {
                MessageBox.Show("Halo 2 Vista was not detected please close your game and try again.", "Error:117_2Ca-.212", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
                Check = false;
            }
        }
        public string MyProcessName()
        {
            return ProcessName;
        }
        public string GetDirectory()
        {
            return MyProcess[0].MainModule.FileName;
        }
        public bool StartProcess()
        {
            if (ProcessName != "")
            {
                Process[] iprocess = Process.GetProcessesByName(ProcessName);
                if (iprocess.Length == 0)
                {
                    SvrCt = 0;
                    return (false);
                }
                procstore = new List<int>();
                for (int i = 0; i < iprocess.Length; i++)
                    procstore.Add(iprocess[i].Id);
                procstore.Sort();
                MyProcess = new Process[iprocess.Length];
                processID = new int[iprocess.Length];
                for (int i = 0; i < iprocess.Length; i++)
                {
                    MyProcess[i] = Process.GetProcessById(procstore[i]);
                    processID[i] = procstore[i];
                }
                iprocess = null;
                SvrCt = MyProcess.Length;
                BaseAddress = new int[SvrCt];
                processHandle = new int[SvrCt];
                for (int i = 0; i < SvrCt; i++)
                {
                    try
                    {
                        processHandle[i] = OpenProcess(PROCESS_ALL_ACCESS, false, MyProcess[i].Id);
                        BaseAddress[i] = (int)MyProcess[i].MainModule.BaseAddress;
                        if (processHandle[i] == 0)
                            return (false);
                    }
                    catch
                    {
                        return (false);
                    }
                }
                return (true);
            }
            else
            {
                return (false);
            }
        } //Checks For Running Process
        public bool CheckProcess()
        {
            Process[] p = Process.GetProcessesByName(ProcessName);
            if (p.Length > 0)
                return true;
            return false;
        }
        public int BaseAddy(int handle)
        {
            return BaseAddress[handle];
        }
        public int ProcessCount { get { return SvrCt; } }
        public int ProcessId(int ID)
        {
            return procstore[ID];
        }
        public bool Keystate(Keys key)
        {
            int state = GetKeyState(key);
            if (state == -127 || state == -128)
                return true;
            return false;
        }
        public string CutString(string mystring)
        {
            try
            {
                char[] mychar = mystring.ToCharArray();
                string returnstring = "";
                for (int i = 0; i < mystring.Length; i++)
                    if (mychar[i] == '\0') return returnstring;
                    else if (mychar.Length == i) return returnstring;
                    else returnstring += mychar[i].ToString();
                return returnstring;
            }
            catch
            {
                return mystring.TrimEnd('0');
            }
        }
        public int DllImageAddress(int handle, string dllname)
        {
            ProcessModuleCollection myProcessModuleCollection = Process.GetProcessById(processID[handle]).Modules;
            for (int i = 0; i < myProcessModuleCollection.Count; i++)
                if (myProcessModuleCollection[i].FileName.EndsWith(dllname))
                    return (int)myProcessModuleCollection[i].BaseAddress;
            return -1;
        }
        public int ImageAddress(int handle, int pOffset)
        {
            try
            {
                return BaseAddress[handle] + pOffset;
            }
            catch
            {
                return 0;
            }
        } //Calculates Image Address + Custom Offset
        #region readMem
        public byte[] ReadMem(int handle, int pOffset, int pSize)
        {
            byte[] buffer = new byte[pSize];
            ReadProcessMemory(processHandle[handle], pOffset, buffer, pSize, 0);
            return buffer;
        } //Read Memory With Custom Offset and Size
        public byte[] ReadMem(int handle, bool AddToImageAddress, int pOffset, int pSize)
        {
            byte[] buffer = new byte[pSize];
            int Address = AddToImageAddress ? ImageAddress(handle, pOffset) : pOffset;
            ReadProcessMemory(processHandle[handle], Address, buffer, pSize, 0);
            return buffer;
        } //Read Memory With Custom Offset And Size And Adds Offset To Image Address If True
        public byte ReadByte(int handle, int pOffset)
        {
            byte[] buffer = new byte[1];
            ReadProcessMemory(processHandle[handle], pOffset, buffer, 1, 0);
            return buffer[0];
        } //Read Memory With 1 Byte From Offset -- For Quick Reading
        public byte ReadByte(int handle, bool AddToImageAddress, int pOffset)
        {
            byte[] buffer = new byte[1];
            int Address = AddToImageAddress ? ImageAddress(handle, pOffset) : pOffset;
            ReadProcessMemory(processHandle[handle], Address, buffer, 1, 0);
            return buffer[0];
        } //Read Memory With 1 Byte From Offset -- For Quick Reading
        public byte ReadByte(int handle, string Module, int pOffset)
        {
            byte[] buffer = new byte[1];
            ReadProcessMemory(processHandle[handle], DllImageAddress(handle, Module) + pOffset, buffer, 1, 0);
            return buffer[0];
        } //Read Memory With 1 Byte From Offset -- For Quick Reading
        public int ReadInt(int handle, int pOffset)
        {
            return BitConverter.ToInt32(ReadMem(handle, pOffset, 4), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public int ReadInt(int handle, bool AddToImageAddress, int pOffset)
        {
            return BitConverter.ToInt32(ReadMem(handle, AddToImageAddress, pOffset, 4), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public int ReadInt(int handle, string Module, int pOffset)
        {
            return BitConverter.ToInt32(ReadMem(handle, DllImageAddress(handle, Module) + pOffset, 4), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public long ReadLong(int handle, int pOffset)
        {
            return BitConverter.ToInt64(ReadMem(handle, pOffset, 8), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public long ReadLong(int handle, bool AddToImageAddress, int pOffset)
        {
            return BitConverter.ToInt64(ReadMem(handle, AddToImageAddress, pOffset, 8), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public long ReadLong(int handle, string Module, int pOffset)
        {
            return BitConverter.ToInt64(ReadMem(handle, DllImageAddress(handle, Module) + pOffset, 8), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public short ReadShort(int handle, int pOffset)
        {
            return BitConverter.ToInt16(ReadMem(handle, pOffset, 2), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public short ReadShort(int handle, bool AddToImageAddress, int pOffset)
        {
            return BitConverter.ToInt16(ReadMem(handle, AddToImageAddress, pOffset, 2), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public short ReadShort(int handle, string Module, int pOffset)
        {
            return BitConverter.ToInt16(ReadMem(handle, DllImageAddress(handle, Module) + pOffset, 2), 0);
        } //Read Memory Integer Offset -- For Quick Reading
        public float ReadFloat(int handle, int pOffset)
        {
            return BitConverter.ToSingle(ReadMem(handle, pOffset, 4), 0);
        } //Read Memory Floating Point Offset -- For Quick Reading
        public float ReadFloat(int handle, bool AddToImageAddress, int pOffset)
        {
            return BitConverter.ToSingle(ReadMem(handle, AddToImageAddress, pOffset, 4), 0);
        } //Read Memory Floating Point Offset -- For Quick Reading
        public float ReadFloat(int handle, string Module, int pOffset)
        {
            return BitConverter.ToSingle(ReadMem(handle, DllImageAddress(handle, Module) + pOffset, 4), 0);
        } //Read Memory Floating Point Offset -- For Quick Reading
        public string ReadStringAscii(int handle, int pOffset, int pSize)
        {
            return CutString(Encoding.ASCII.GetString(ReadMem(handle, pOffset, pSize)));
        } //Read Memory Floating Point Offset -- For Quick Reading
        public string ReadStringAscii(int handle, bool AddToImageAddress, int pOffset, int pSize)
        {
            return CutString(Encoding.ASCII.GetString(ReadMem(handle, AddToImageAddress, pOffset, pSize)));
        } //Read Memory Floating Point Offset -- For Quick Reading
        public string ReadStringAscii(int handle, string Module, int pOffset, int pSize)
        {
            return CutString(Encoding.ASCII.GetString(ReadMem(handle, DllImageAddress(handle, Module) + pOffset, pSize)));
        } //Read Memory Floating Point Offset -- For Quick Reading
        public string ReadStringUnicode(int handle, int pOffset, int pSize)
        {
            return CutString(Encoding.Unicode.GetString(ReadMem(handle, pOffset, pSize)));
        } //Read Memory Floating Point Offset -- For Quick Reading
        public string ReadStringUnicode(int handle, bool AddToImageAddress, int pOffset, int pSize)
        {
            return CutString(Encoding.Unicode.GetString(ReadMem(handle, AddToImageAddress, pOffset, pSize)));
        } //Read Memory Floating Point Offset -- For Quick Reading
        public string ReadStringUnicode(int handle, string Module, int pOffset, int pSize)
        {
            return CutString(Encoding.Unicode.GetString(ReadMem(handle, DllImageAddress(handle, Module) + pOffset, pSize)));
        } //Read Memory Floating Point Offset -- For Quick Reading
        #endregion
        #region WriteMem
        public void WriteMem(int handle, int pOffset, byte[] pBytes)
        {
            WriteProcessMemory(processHandle[handle], pOffset, pBytes, pBytes.Length, 0);
        } //Write Memory With Custom Offset and Size
        public void WriteMem(int handle, bool AddToImageAddress, int pOffset, byte[] pBytes)
        {
            int Address = AddToImageAddress ? ImageAddress(handle, pOffset) : pOffset;
            WriteProcessMemory(processHandle[handle], Address, pBytes, pBytes.Length, 0);
        }//Read Memory With Custom Offset And Size And Adds Offset To Image Address If True
        public void WriteByte(int handle, int pOffset, byte pBytes)
        {
            WriteMem(handle, pOffset, new byte[] { pBytes });
        } //Write Memory Byte Offset -- For Quick Reading
        public void WriteByte(int handle, bool AddToImageAddress, int pOffset, byte pBytes)
        {
            WriteMem(handle, AddToImageAddress, pOffset, new byte[] { pBytes });
        } //Write Memory Byte Offset -- For Quick Reading
        public void WriteByte(int handle, string Module, int pOffset, byte pBytes)
        {
            WriteMem(handle, DllImageAddress(handle, Module) + pOffset, new byte[] { pBytes });
        } //Write Memory Byte Offset -- For Quick Reading
        public void WriteInt(int handle, int pOffset, int pBytes)
        {
            WriteMem(handle, pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Integer Offset -- For Quick Reading
        public void WriteInt(int handle, bool AddToImageAddress, int pOffset, int pBytes)
        {
            WriteMem(handle, AddToImageAddress, pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Integer Offset -- For Quick Reading
        public void WriteInt(int handle, string Module, int pOffset, int pBytes)
        {
            WriteMem(handle, DllImageAddress(handle, Module) + pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Integer Offset -- For Quick Reading
        public void WriteFloat(int handle, int pOffset, float pBytes)
        {
            WriteMem(handle, pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Floating Point Offset -- For Quick Reading
        public void WriteFloat(int handle, bool AddToImageAddress, int pOffset, float pBytes)
        {
            WriteMem(handle, AddToImageAddress, pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Floating Point Offset -- For Quick Reading
        public void WriteFloat(int handle, string Module, int pOffset, float pBytes)
        {
            WriteMem(handle, DllImageAddress(handle, Module) + pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Floating Point Offset -- For Quick Reading
        public void WriteShort(int handle, int pOffset, short pBytes)
        {
            WriteMem(handle, pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Integer Offset -- For Quick Reading
        public void WriteShort(int handle, bool AddToImageAddress, int pOffset, short pBytes)
        {
            WriteMem(handle, AddToImageAddress, pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Integer Offset -- For Quick Reading
        public void WriteShort(int handle, string Module, int pOffset, short pBytes)
        {
            WriteMem(handle, DllImageAddress(handle, Module) + pOffset, BitConverter.GetBytes(pBytes));
        } //Write Memory Integer Offset -- For Quick Reading
        public void WriteStringUnicode(int handle, int pOffset, string pBytes)
        {
            WriteMem(handle, pOffset, Encoding.Unicode.GetBytes(pBytes + "\0"));
        } //Write Memory Floating Point Offset -- For Quick Reading
        public void WriteStringUnicode(int handle, bool AddToImageAddress, int pOffset, string pBytes)
        {
            WriteMem(handle, AddToImageAddress, pOffset, Encoding.Unicode.GetBytes(pBytes + "\0"));
        } //Write Memory Floating Point Offset -- For Quick Reading
        public void WriteStringUnicode(int handle, string Module, int pOffset, string pBytes)
        {
            WriteMem(handle, DllImageAddress(handle, Module) + pOffset, Encoding.Unicode.GetBytes(pBytes + "\0"));
        } //Write Memory Floating Point Offset -- For Quick Reading
        public void WriteStringAscii(int handle, int pOffset, string pBytes)
        {
            WriteMem(handle, pOffset, Encoding.ASCII.GetBytes(pBytes + "\0"));
        } //Write Memory Floating Point Offset -- For Quick Reading
        public void WriteStringAscii(int handle, bool AddToImageAddress, int pOffset, string pBytes)
        {
            WriteMem(handle, AddToImageAddress, pOffset, Encoding.ASCII.GetBytes(pBytes + "\0"));
        } //Write Memory Floating Point Offset -- For Quick Reading
        public void WriteStringAscii(int handle, string Module, int pOffset, string pBytes)
        {
            WriteMem(handle, DllImageAddress(handle, Module) + pOffset, Encoding.ASCII.GetBytes(pBytes + "\0"));
        } //Write Memory Floating Point Offset -- For Quick Reading
        #endregion
        #region GetPointers
        //mainmodule pointers
        public int Pointer(int handle, bool AddToImageAddress, int pOffset)
        {
            return ReadInt(handle, BaseAddy(handle) + pOffset);
        }
        public int Pointer(int handle, bool AddToImageAddress, int pOffset, int pOffset2)
        {
            return ReadInt(handle, BaseAddy(handle) + pOffset) + pOffset2;
        }
        public int Pointer(int handle, bool AddToImageAddress, int pOffset, int pOffset2, int pOffset3)
        {
            return ReadInt(handle, ReadInt(handle, BaseAddy(handle) + pOffset) + pOffset2) + pOffset3;
        }
        public int Pointer(int handle, bool AddToImageAddress, int pOffset, int pOffset2, int pOffset3, int pOffset4)
        {
            return ReadInt(handle, ReadInt(handle, ReadInt(handle, BaseAddy(handle) + pOffset) + pOffset2) + pOffset3) + pOffset4;
        }
        public int Pointer(int handle, bool AddToImageAddress, int pOffset, int pOffset2, int pOffset3, int pOffset4, int pOffset5)
        {
            return ReadInt(handle, ReadInt(handle, ReadInt(handle, ReadInt(handle, BaseAddy(handle) + pOffset) + pOffset2) + pOffset3) + pOffset4) + pOffset5;
        }
        public int Pointer(int handle, bool AddToImageAddress, int pOffset, int pOffset2, int pOffset3, int pOffset4, int pOffset5, int pOffset6)
        {
            return ReadInt(handle, ReadInt(handle, ReadInt(handle, ReadInt(handle, ReadInt(handle, BaseAddy(handle) + pOffset) + pOffset2) + pOffset3) + pOffset4) + pOffset5) + pOffset6;
        }
        //dllmodule pointers
        public int Pointer(int handle, string Module, int pOffset)
        {
            return ReadInt(handle, DllImageAddress(handle, Module) + pOffset);
        }
        public int Pointer(int handle, string Module, int pOffset, int pOffset2)
        {
            return ReadInt(handle, DllImageAddress(handle, Module) + pOffset) + pOffset2;
        }
        public int Pointer(int handle, string Module, int pOffset, int pOffset2, int pOffset3)
        {
            return ReadInt(handle, ReadInt(handle, DllImageAddress(handle, Module) + pOffset) + pOffset2) + pOffset3;
        }
        public int Pointer(int handle, string Module, int pOffset, int pOffset2, int pOffset3, int pOffset4)
        {
            return ReadInt(handle, ReadInt(handle, ReadInt(handle, DllImageAddress(handle, Module) + pOffset) + pOffset2) + pOffset3) + pOffset4;
        }
        public int Pointer(int handle, string Module, int pOffset, int pOffset2, int pOffset3, int pOffset4, int pOffset5)
        {
            return ReadInt(handle, ReadInt(handle, ReadInt(handle, ReadInt(handle, DllImageAddress(handle, Module) + pOffset) + pOffset2) + pOffset3) + pOffset4) + pOffset5;
        }
        public int Pointer(int handle, string Module, int pOffset, int pOffset2, int pOffset3, int pOffset4, int pOffset5, int pOffset6)
        {
            return ReadInt(handle, ReadInt(handle, ReadInt(handle, ReadInt(handle, ReadInt(handle, DllImageAddress(handle, Module) + pOffset) + pOffset2) + pOffset3) + pOffset4) + pOffset5) + pOffset6;
        }
        #endregion
    }
}
