using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherInfo;

namespace HomeTask_2._2
{
    class Program
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
        static void Main()
        {
            // Запрос месяца номера месяца
            Console.WriteLine("Пожалуйста введите порядковый номер месяца:");
            WeatherInfo.WeatherInfo.month = WeatherInfo.WeatherInfo.GetValue(12);
            
            //Вывод результатов на экран
            Console.Clear();
            Console.WriteLine($"Вы выбрали месяц: {(Months)WeatherInfo.WeatherInfo.month}");
            
            Console.ReadLine();
        }
    }
}
