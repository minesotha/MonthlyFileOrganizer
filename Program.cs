using System;
using System.IO;

/// <summary>
/// Manage last months crap by moving it to named folder! [chosenBase]//year//month//[allthecrpafiles]
/// </summary>
namespace MonthlyFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            bool sortCrap = false;
            if (args[0] == null)
            {
                Console.WriteLine("Add path to Monthly Folder Creation in program arguments");
                Console.ReadKey();
            }
            else if (args[0].IndexOf("\"")>-1 || args[0].Contains("\'"))
            {
                path = args[0].Substring(1, args[0].Length - 1);
            }
            else {
                path = args[0];
                if (!Directory.Exists(path))
                 {
                        Console.WriteLine("Path to Monthly Folder Creation directory is wrong or doesn't exist");
                         Console.ReadKey();
                }
                else
                {
                    if (ManageLastMontFolder(path) == true)
                    {
                        if (args[1] != null && bool.TryParse(args[1], out sortCrap) == true && sortCrap == true)
                        {
                            MoveCrap(path);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// check if folder for last month exists, if not, make one
        /// </summary>
        /// <param name="path"> path to folder where programs hould manage years and months</param>
        /// <returns>true if made new folder for last month</returns>
        static bool ManageLastMontFolder(string path)
        {
            int year = DateTime.Now.Year;
            //-1 for last month
            int month = DateTime.Now.Month-1;
            if (!Directory.Exists(path + "//" + year + "//" + month))
            {
                Directory.CreateDirectory(path + "//" + year + "//" + month);
                return true;
            }
            else return false;
            
           
        }
        /// <summary>
        /// move all crap from last month to last month's folder
        /// </summary>
        /// <param name="path"> path to managed folderspace</param>
        static void MoveCrap(string path)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
                MoveFile(fileName, path);

        }
        /// <summary>
        /// move file from base folder to corresponing to creation date year/month folder
        /// </summary>
        /// <param name="filePath"> path to file that should be checked</param>
        /// <param name="folderPath">path to general base folder where all the crap lies</param>
        public static void MoveFile(string filePath, string folderPath)
        {
            FileInfo fi = new FileInfo(filePath);
            if(fi.CreationTime.Year == DateTime.Now.Year && fi.CreationTime.Month == fi.CreationTime.Month)
            {
                string fileName = filePath.Substring(folderPath.Length);
                File.Move(filePath, folderPath + "//" + DateTime.Now.Year + "//" + DateTime.Now.Month+fileName);
            }
        }
    }
}

