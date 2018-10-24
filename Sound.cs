using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Media;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Labirint2D
{
    class Sound
    {
        public static SoundPlayer sound_fail = new SoundPlayer(Properties.Resources.Fail);
        public static SoundPlayer sound_key = new SoundPlayer(Properties.Resources.Key);
        public static SoundPlayer sound_start = new SoundPlayer(Properties.Resources.On);
        public static SoundPlayer sound_youwin = new SoundPlayer(Properties.Resources.Off);
        private static bool onOff { get; set; }

        public static void Play(SoundPlayer sp)
        {
            if (onOff)
                sp.Play();
        }

        public static void OnOff(bool OnOff)
        {
            onOff = OnOff;
        }
    }

    class IniFile
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
