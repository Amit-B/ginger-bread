using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Windows.Forms;
using System.IO;
namespace GingerBread.Classes
{
    class Text
    {
        public static char[] c =
        {
            'a',
            'e',
            'i',
            'o',
            'u'
        };
        public static string[] s =
        {
            "ch",
            "sh",
            "th",
            "hh",
            "b",
            "c",
            "d",
            "f",
            "g",
            "h",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "v",
            "w",
            "x",
            "y",
            "z"
        };
        public static List<string> GetSyllables(string text)
        {
            string[] words = text.Split(' ');
            int flag = -1;
            List<string> toRead = new List<string>();
            for (int i = 0, m = words.GetLength(0); i < m; i++)
            {
                flag = -1;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (!c.Contains(words[i][j]) && flag != -1 && s[flag].Length == 1)
                        flag = -1;
                    if (flag == -1)
                    {
                        for (int a = 0, m2 = s.GetLength(0); a < m2 && flag == -1; a++)
                            if (words[i].ToString().Remove(0, j).StartsWith(s[a]))
                            {
                                toRead.Add(s[a]);
                                flag = a;
                            }
                        if (flag == -1 && c.Contains(words[i][j]))
                            toRead.Add(words[i][j].ToString());
                    }
                    else
                    {
                        if (c.Contains(words[i][j]))
                        {
                            toRead[toRead.Count - 1] += words[i][j].ToString();
                            flag = -1;
                        }
                        continue;
                    }
                }
                toRead.Add(" ");
            }
            return toRead;
        }
        public static void CreateFiles()
        {
            const string EXT = ".wav";
            int mc = c.GetLength(0), ms = s.GetLength(0);
            string dir = Classes.Files.GetPath(Files.ProgramDirectory.Sounds) + "/";
            for (int i = 0; i < mc; i++)
                if(!File.Exists(dir + c[i].ToString() + EXT))
                    File.WriteAllText(dir + c[i].ToString() + EXT, string.Empty);
            for (int i = 0; i < ms; i++)
            {
                if (!File.Exists(dir + s[i].ToString() + EXT))
                    File.WriteAllText(dir + s[i].ToString() + EXT, string.Empty);
                for (int j = 0; j < mc; j++)
                    if (!File.Exists(dir + s[i].ToString() + c[j].ToString() + EXT))
                        File.WriteAllText(dir + s[i].ToString() + c[j].ToString() + EXT, string.Empty);
            }
        }
    }
}