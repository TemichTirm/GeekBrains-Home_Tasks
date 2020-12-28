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
            UserInterface.NeedChanges((byte)toDoList.Count());
            //toDoList.Add(CreateNewToDo(toDoList)); 
            WorkWithFile.SaveFile(toDoList);
            //Console.ReadLine();
        }
        static ToDo CreateNewToDo(List<ToDo> toDoList)
        {
            byte count = (byte)toDoList.Count;
            return new ToDo (++count, "Умыться", false);
        }
    }
}
