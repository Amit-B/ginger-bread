using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Timers;
using System.IO;
namespace GingerBread.Classes
{
    class Audio
    {
        private static List<string> toRead;
        private static Timer timer;
        private static SoundPlayer sp;
        private static int position;
        private static string[] seperators =
        {
            " ",
            ".",
            ","
        };
        public static void Load()
        {
            toRead = new List<string>();
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Interval = 250;
            sp = new SoundPlayer();
        }
        public static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string file = Files.GetPath(Files.ProgramDirectory.Sounds) + "/" + toRead[position] + ".wav";
            if (File.Exists(file))
            {
                sp.SoundLocation = Files.GetPath(Files.ProgramDirectory.Sounds) + "/" + toRead[position] + ".wav";
                sp.Load();
                sp.Play();
            }
            timer.Interval = seperators.Contains(toRead[position]) ? 400 : 250;
            position++;
            if (position == toRead.Count)
                timer.Stop();
        }
        public static void Read(IEnumerable<string> collection)
        {
            if (timer.Enabled)
                timer.Stop();
            toRead.Clear();
            toRead.AddRange(collection);
            position = 0;
            timer.Start();
        }
    }
}