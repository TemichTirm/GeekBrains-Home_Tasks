using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeTask_2._4
{
    class Program
    {
        static void Main()
        {
            if (WeatherInfo.WeatherInfo.averageTemperature > 0)
            {
                switch ((Months)WeatherInfo.WeatherInfo.month)
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
        }
    }
}
