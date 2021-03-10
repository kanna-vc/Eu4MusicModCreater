using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Eu4MusicModCreater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввести названия мода (файлов txt и asset)");
            string NameModFile = Console.ReadLine();
            Console.WriteLine(@"Ввести путь к папке music. прим ( C:\Users\Professional\Documents\Paradox Interactive\Europa Universalis IV\mod\MyMusicMod\music )");
            string Path = Console.ReadLine();

            string TxtModPath = Path + @"\" + NameModFile + ".txt";
            string AssetModPath = Path + @"\" + NameModFile + ".asset";

            var txtWriter = new StreamWriter(TxtModPath);
            var assetWriter = new StreamWriter(AssetModPath);

            foreach (var item in Directory.GetFiles(Path))
            {
                string music = item.Substring(Path.Length + 1);
                string[] splitMusic = music.Split(new char[] { '.' });
                if (splitMusic[1] == "ogg")
                {
                    try
                    {
                        string asset = "\n music = {\n  name = \"" + splitMusic[0] + "\"\n  file = \"" + music + "\"\n}";
                        string txt = "\nsong = {\n  name = \"" + splitMusic[0] + "\"\n      chance = { modifier = { factor = 1.5 } }\n }";

                        assetWriter.Write(asset);
                        txtWriter.Write(txt);

                        Console.WriteLine(music + " - успешно");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(music + " - " + e);
                    }
                }
            }
            txtWriter.Close();
            assetWriter.Close();

            Console.ReadKey();
        }
    }
}
