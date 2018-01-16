using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace GingerBread.Classes
{
    class Files
    {
        public enum ProgramDirectory { Main, Sounds }
        public static string GetPath(ProgramDirectory dir)
        {
            string ret = string.Empty, main = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "/GingerBread";
            switch (dir)
            {
                case ProgramDirectory.Main: ret = main; break;
                case ProgramDirectory.Sounds: ret = main + "/Sound Files"; break;
            }
            return ret;
        }
        public static void Install()
        {
            string[] check = { GetPath(ProgramDirectory.Main), GetPath(ProgramDirectory.Sounds) };
            for(int i = 0, m = check.GetLength(0); i < m; i++)
            if (!Directory.Exists(check[i]))
                Directory.CreateDirectory(check[i]);
            Text.CreateFiles();
        }
    }
}