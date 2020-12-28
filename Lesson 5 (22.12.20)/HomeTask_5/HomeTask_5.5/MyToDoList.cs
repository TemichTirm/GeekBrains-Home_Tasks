using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_5._5
{
    class MyToDoList
    {
        static void Main(string[] args)
        {
            
            List<ToDo> toDoList = new List<ToDo>();
            toDoList =  WorkWithFile.ReadFile();
            UserInterface.PrintToDo(toDoList);
            byte taskIndex;
            while (true)
            {
                (bool isNeedChanges, byte numOfToDo_ToChange) changes = UserInterface.NeedChanges((byte)toDoList.Count());
                if (!changes.isNeedChanges) break;
                else if ((taskIndex = changes.numOfToDo_ToChange) > 0) 
                {
                    switch (UserInterface.ChooseChange())
                    {
                        case ConsoleKey.Escape:
                            {
                                Console.Clear();
                                UserInterface.PrintToDo(toDoList);
                                break;
                            }
                        case ConsoleKey.D1:
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
                        case ConsoleKey.D2:
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
                        case ConsoleKey.Delete:
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

                    //toDoList[numOfToDo_ToChange];
                }
                else
                {
                    string newTaskTitle = UserInterface.AddNewTask();
                    toDoList.Add(new ToDo((byte)(toDoList.Count + 1), newTaskTitle, false));
                    Console.Clear();
                    UserInterface.PrintToDo(toDoList);
                }
            }
            //toDoList.Add(CreateNewToDo(toDoList));
            WorkWithFile.SaveFile(toDoList);
            Console.WriteLine("Информация успешно сохранена!");
            Console.ReadLine();
        }
        static ToDo CreateNewToDo(List<ToDo> toDoList)
        {
            byte count = (byte)toDoList.Count;
            return new ToDo (++count, "Умыться", false);
        }
    }
}
