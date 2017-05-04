using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonthlyFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            if (args[0] == null)
            {
                Console.WriteLine("Add path to Monthly Folder Creation in program arguments");
                Console.ReadKey();
            }
            else if (args[0].Contains('\"') || args[0].Contains('\''))
            {
                path = args[0].Substring(1, args[0].Length - 1);
            }
            else {
                path = args[0];
                if (!File.Exists(path))
                    {
                        Console.WriteLine("Path to Monthly Folder Creation is wrong or doesn't exist");
                    }
                else
                {
                    CheckFolders(path);
                }
            }
        }

        static void CheckFolders(string path)
        {


        }
    }
}
