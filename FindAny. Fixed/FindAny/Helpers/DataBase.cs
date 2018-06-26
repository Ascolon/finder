using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FindAny.Helpers
{
    static public class DataBase
    {
        static public List<string> GetData() 
        {
            if (File.Exists("MDF/DataFile.txt"))
            {
                var file = File.ReadAllLines("MDF/DataFile.txt");
                return file.ToList();
            }
            return new List<string>();
        }

        static public void SetData(string data)
        {
            if (File.Exists("MDF/DataFile.txt"))
            {
                var file = File.ReadAllLines("MDF/DataFile.txt").ToList();
                file.Add(DateTime.Now + ": Игрок " + new ConfigMethods().GetPlayerName() + " за " + new ConfigMethods().GetLevel() + " уровень набрал " + data + " очков");
                File.WriteAllLines("MDF/DataFile.txt", file);
            }
            else
            {
                var file = new List<string>();
                file.Add(DateTime.Now + ": Игрок " + new ConfigMethods().GetPlayerName() + " за " + new ConfigMethods().GetLevel() + " уровень набрал " + data + " очков");
                File.WriteAllLines("MDF/DataFile.txt", file);
            }
        }


        static public void Restart()
        {
            if (File.Exists("MDF/" + new ConfigMethods().GetPlayerName() + ".txt"))
            {
               // File.Delete("MDF/" + new ConfigMethods().GetPlayerName() + ".txt");
            }
        }

    }
}
