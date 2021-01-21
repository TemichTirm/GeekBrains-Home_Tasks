using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_5._5
{
    /// <summary>
    /// Реализация списка задач
    /// </summary>
    class MyToDoList
    {
        static void Main(string[] args)
        {
            
            List<ToDo> toDoList = new List<ToDo>();
            toDoList =  WorkWithFile.ReadFile();        // Чтение данных из файла
            UserInterface.PrintToDo(toDoList);          // Вывод списка задач в консоль
            byte taskIndex;                             
            while (true)
            {
                // Запрос на внесение изменений
                (bool isNeedChanges, byte numOfToDo_ToChange) changes = UserInterface.NeedChanges((byte)toDoList.Count());
                if (!changes.isNeedChanges) break;
                else if ((taskIndex = changes.numOfToDo_ToChange) > 0) // Если изменения подтверждены и выбран номер задачи
                {
                    switch (UserInterface.ChooseChange())
                    {
                        case ConsoleKey.Escape:                     // Возврат в начало
                            {
                                Console.Clear();
                                UserInterface.PrintToDo(toDoList);
                                break;
                            }
                        case ConsoleKey.D1:                         // Изменение статуса задачи
                            {
                                toDoList[taskIndex - 1].ChangeStatus();
                                UserInterface.RefreshRecordLine(toDoList[taskIndex - 1]);
                                Console.WriteLine($"\nСтатус задачи № {taskIndex} изменен на " +
                                    $"{(toDoList[taskIndex - 1].IsDone? "\"Выполнено\"" : "\"Не выполнено\"")}");
                                Console.Write("\nДля продолжения нажмите Enter...");
                                Console.ReadLine();
                                Console.Clear();
                                UserInterface.PrintToDo(toDoList);
                                break;
                            }
                        case ConsoleKey.D2:                         // Изменение наименования задачи
                            {
                                Console.WriteLine("\nВведите новое наименование задачи");
                                string newTitle = Console.ReadLine();
                                toDoList[taskIndex - 1].ChangeTitle(newTitle);
                                UserInterface.RefreshRecordLine(toDoList[taskIndex - 1]);
                                Console.WriteLine($"Наименование задачи № {taskIndex} изменено");
                                Console.Write("\nДля продолжения нажмите Enter...");
                                Console.ReadLine();
                                Console.Clear();
                                UserInterface.PrintToDo(toDoList);
                                break;
                            }
                        case ConsoleKey.Delete:                     // Удаление выбранной задачи
                            {                                
                                Console.WriteLine($"Задача № {taskIndex} будет удалена, подтверждаете удаление? Д/Н");
                                while (true)
                                {
                                    ConsoleKeyInfo key = Console.ReadKey(true);
                                    if (key.Key == ConsoleKey.Y)
                                    {
                                        Console.Clear();
                                        UserInterface.PrintToDo(toDoList);
                                        break;
                                    }
                                    if (key.Key == ConsoleKey.L)
                                    {
                                        toDoList.RemoveAt(taskIndex - 1);
                                        byte count = 1;
                                        foreach (ToDo task in toDoList) task.Count = count++;
                                        Console.Clear();
                                        UserInterface.PrintToDo(toDoList);
                                        break;
                                    }
                                }
                                break;
                            }
                    }
                }
                // Добавление новой задачи в список
                else                                                
                {
                    string newTaskTitle = UserInterface.AddNewTask();
                    toDoList.Add(new ToDo((byte)(toDoList.Count + 1), newTaskTitle, false));
                    Console.Clear();
                    UserInterface.PrintToDo(toDoList);
                }
            }
            WorkWithFile.SaveFile(toDoList);
            Console.WriteLine("Информация успешно сохранена!");
            Console.ReadLine();
        }
    }
}
