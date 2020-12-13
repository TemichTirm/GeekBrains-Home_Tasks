using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherInfo;
/// <summary>
/// Домашнее задание 2.1
/// </summary>
namespace HomeTask_2._1
{
    public class Program
    {
        
        /// <summary>
        /// Вычисление средней температуры за сутки на основе мин. и макс. значений, введенных пользователем
        /// </summary>
        static void Main()
        {
            // Запрос минимальной температуры за сутки
            Console.WriteLine("Пожалуйста введите минимальную температуру за сутки, градусы Цельсия:");
            WeatherInfo.WeatherInfo.minTemperature = WeatherInfo.WeatherInfo.GetValue(100.0);

            // Запрос максимальной температуры за сутки
            Console.WriteLine("Пожалуйста введите максимальную температуру за сутки, градусы Цельсия:");
            WeatherInfo.WeatherInfo.maxTemperature = WeatherInfo.WeatherInfo.GetValue(100.0);

            //Расчет среднего значения температуры за сутки
            WeatherInfo.WeatherInfo.averageTemperature = (WeatherInfo.WeatherInfo.maxTemperature + WeatherInfo.WeatherInfo.minTemperature) / 2;

            //Вывод результатов на экран
            Console.Clear();
            Console.WriteLine($"Минимальная температура за сутки: {WeatherInfo.WeatherInfo.minTemperature} град. Цельсия;");
            Console.WriteLine($"Максимальная температура за сутки: {WeatherInfo.WeatherInfo.maxTemperature} град. Цельсия;");
            Console.WriteLine($"\nСредняя температура за сутки: {WeatherInfo.WeatherInfo.averageTemperature} град. Цельсия.");

            Console.ReadLine();
        }
    }
}
