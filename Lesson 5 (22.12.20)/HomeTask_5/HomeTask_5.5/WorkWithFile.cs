using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace HomeTask_5._5
{
    /// <summary>
    /// Класс работы с файлом
    /// </summary>
    class WorkWithFile
    {
        private const string filename = "myToDo.json";      // Задаём има файла по умолчанию жестко. Можно при необходимости 
                                                            // реализовать механизм запроса имени файла
        /// <summary>
        /// Метод чтения данных из файла формата json и десериализация
        /// </summary>
        /// <returns>Список объектов класса задач</returns>
        public static List<ToDo> ReadFile()
        {
            // Проверка наличия файла            
            List<ToDo> toDoList = new List<ToDo>();
            if (File.Exists(filename))
            {
                byte count = 1;
                string[] serializedJson = File.ReadAllLines(filename);
                for (int i = 0; i < serializedJson.Length; i++)
                {
                    // Десериализация по строкам с проверкой целостности данных. При их повреждении строка пропускается
                    try
                    {
                        toDoList.Add(JsonSerializer.Deserialize<ToDo>(serializedJson[i]));
                        toDoList[count-1].Count = count++;    // Назначение новыхпорядковых номеров на случай повреждения записей в файле
                    }
                    catch (Exception) { continue; }
                }                
            }
            return toDoList;
        }
        /// <summary>
        /// Метод записи данных в файл формата json
        /// </summary>
        /// <param name="toDoList">Список объектов класса задач</param>
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
