using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace HomeTask_5._5
{
    class WorkWithFile
    {
        private const string filename = "myToDo.json";
        public static List<ToDo> ReadFile()
        {
            if (File.Exists(filename))
            {
                List<ToDo> toDoList = new List<ToDo>();
                string[] serializedJson = File.ReadAllLines(filename);
                for (int i = 0; i < serializedJson.Length; i++)
                {
                    try
                    {
                        toDoList.Add(JsonSerializer.Deserialize<ToDo>(serializedJson[i]));
                    }
                    catch (Exception e) { continue; }
                }
                return toDoList;
            }
            else return null;
        }
        public static void SaveFile(List<ToDo> toDoList)
        {
            string[] serializedJson = new string[toDoList.Count];
            byte count = 0;
            foreach (ToDo task in toDoList)
            {
                serializedJson[count] = JsonSerializer.Serialize(task);
                count++;
            }
            File.WriteAllLines(filename, serializedJson);
               
        }
    }
}
