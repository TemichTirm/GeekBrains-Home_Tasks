﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace HomeTask_5._5
{
    class ToDo
    {
        
        //private string title;
        //private bool isDone;
        //private byte count;
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public byte Count { get; set; }
        public ToDo()
        {

        }
        public ToDo(byte count, string title, bool isDone) 
        {
            Title = title;
            IsDone = isDone;
            Count = count;
        }
        public void Print ()
        {
            string status = IsDone ? "[x]" : "[ ]";
            string output = String.Format(" {0}\t   {1}\t\t{2}", Count, status, Title );
            Console.WriteLine(output);
        }
        public void ChangeTask (bool status, string newTitle = null)
        {
            IsDone = status;
            Title = newTitle?? Title;
        }
    }
}