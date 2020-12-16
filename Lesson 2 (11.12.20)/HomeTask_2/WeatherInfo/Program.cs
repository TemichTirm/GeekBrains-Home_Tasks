using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Проект для сохранения данных о погоде и методов проверки введенных значений
/// </summary>
namespace HomeTask_2._4
{
    enum Months
    {
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December
    }
    class HomeTask2_4
    { 
        static void Main()
        {            
            double averageTemperature = HomeTask_2._1.HomeTask2_1.GetAverageTemp(); // Вызов проекта 1
            int month = HomeTask_2._2.HomeTask2_1.GetMonth();                       // Вызов проекта 2

            // Определение дождливая ли зима. 
            if (averageTemperature > 0)
            {
                switch ((Months)month)
                {
                    case Months.December:
                    case Months.January:
                    case Months.February:
                        {
                            Console.WriteLine("Дождливая зима");
                            break;
                        }
                }
            }
            Console.ReadLine();
            HomeTask_2._3.HomeTask2_3.IsIven(); // Вызов проекта 3
        }
    }
}
