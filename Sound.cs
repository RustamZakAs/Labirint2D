using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

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
}
