using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeTask_5._4
{
    class DirInfoByRecursion
    {
        public static List<string> GetDirInfo (string path)
        {
            List<string> dList = new List<string>();
            if (!Directory.Exists(path))
            {
                dList.Add("Путь указан не верно, такая директория не существует!");
                return dList;
            }
            else
            {
                string[] subDirInfo = null;
                try
                {
                    subDirInfo =  Directory.GetDirectories(path);
                }
                catch (UnauthorizedAccessException e)
                {
                    dList.Add(e.ToString());
                }
                catch (DirectoryNotFoundException e)
                {
                    dList.Add(e.ToString());
                }
                if (subDirInfo != null) dList.AddRange(subDirInfo); //////////////////
                {
                    string[] fileInfo;
                    try
                    {
                        fileInfo = Directory.GetFiles(path);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        dList.Add(e.ToString());
                        return dList;
                    }
                    dList.AddRange(fileInfo);
                    dList.Add("");
                }

                if (subDirInfo != null) 
                {
                    foreach (string dir in subDirInfo)
                    {
                        //dList.Add(dir);                        
                        dList.AddRange(GetDirInfo(dir));
                    }
                }
                return dList;
            }
        }
    }
}
