using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeTask_5._4
{
    class DirInfo
    {
        static void Main()
        {
            //string path = @"C:\Microsoft\Xamarin"; 
            //string path = @"C:\$Recycle.Bin\S-1-5-18";
            //string path = @"C:\$Recycle.Bin";
            string path = @"C:\Users\Temich\Desktop\Программирование\Geekbrains\GeekBrains-Home_Tasks\Lesson 5 (22.12.20)\HomeTask_5\HomeTask_5.4\bin\Debug\examples";
            string filename = "dirinfo.txt";
            Console.WriteLine("Путь к директории:");
            Console.WriteLine(path);
            Console.WriteLine("\nСодержимое директории:");
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Указан неверный путь, такой директории не существует!");
                Console.ReadLine();
                return;
            }
            else
            {
                try
                {
                    Directory.SetCurrentDirectory(path);
                }
                catch (System.UnauthorizedAccessException e)
                {
                    Console.WriteLine("Нет аторизации для доступа к указанной директории");
                    Console.ReadLine();
                    return;
                }
                path = @".\";
                //string parentDirectory = Directory.GetParent(path)?.ToString();
                //path = (parentDirectory != null) ? path.Replace($@"{parentDirectory}\", "") : path;
                

                foreach (string s in DirInfoByRecursion.GetDirInfo(path))
                {
                    Console.WriteLine(s);
                }
                //if (Directory.Exists(path))
                //{
                //    PrintDirectory(GetDirInfo(path));
                //    PrintFiles(GetFileInfo(path));
                //}
                Console.ReadLine();
            }
        }
        
        static string[] GetDirInfo(string path)
        {
            return Directory.GetDirectories(path);
        }
        static string[] GetFileInfo(string path)
        {
            return Directory.GetFiles(path);
        }
        static void PrintDirectory (string[] dir)
        {
            foreach (string s in dir)
            {
                Console.WriteLine(s);
            }
        }
        static void PrintFiles(string[] files)
        {
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }
    }

}
