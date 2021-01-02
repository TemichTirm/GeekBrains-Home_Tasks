using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_4._3
{
    class Seasons
    {
        /// <summary>
        /// Определение времени года по порядковому номеру месяца и вывода его на консоль на русском языке
        /// </summary>
        static void Main()
        { 
            // Вывол приветствия
            string greeting = "Определение времен года";
            Console.WriteLine(greeting);

            // Запрос порядкового номера месяца
            const int minMonth = 1;
            const int maxMonth = 12;
            Console.WriteLine($"\nПожалуйста введите порядковый номер текущего месяца от {minMonth} до {maxMonth}:");
            int month = GetValue(minMonth, maxMonth);

            // Очищение консоли и вывод результата определения времени года на русском языке
            Console.Clear();
            Console.WriteLine(greeting);
            Console.WriteLine($"\nВремя года - {GetSeasonInRussian(GetSeason(month))}");
            
            Console.ReadLine();
        }
        #region Перечисление времен года
        /// <summary>
        /// Перечисление времен года
        /// </summary>
        enum SeasonsOfYear
        {
            Winter, // Зима
            Spring, // Весна
            Summer, // Лето
            Autumn  // Осень
        }
        #endregion
        #region Метод получения значения целого числа из консоли c проверкой по границам значений
        /// <summary>
        /// Выводит значение в виде целого числа от минимального до максимального значения включительно с проверкой  после ввода в консоли 
        /// </summary>
        /// <param name="minValue">Минимальная величина значения</param>
        /// <param name="maxValue">Максимальная величина значения</param>
        /// <returns></returns>
        static int GetValue(int minValue, int maxValue)
        {
            int value;
            string input = Console.ReadLine();
            while (!int.TryParse(input, out value) || (value > maxValue) || (value < minValue))
            {
                Console.WriteLine($"Ошибка! Вы ввели неверное значение, пожалуйста введите число от {minValue} до {maxValue}:");
                input = Console.ReadLine();
            }
            return value;
        }
        #endregion
        #region Метод определения времени года в зависимости от номера месяца
        /// <summary>
        /// Определяет время года в зависимости от номера месяца
        /// </summary>
        /// <param name="month">Порядковый номер месяца</param>
        /// <returns>Время года</returns>
        static SeasonsOfYear GetSeason(int month)
        {
            SeasonsOfYear currentSeason = SeasonsOfYear.Winter;
            switch (month)
            {
                case 1:
                case 2:
                case 12:
                    {
                        currentSeason = SeasonsOfYear.Winter;
                        break;
                    }
                case 3:
                case 4:
                case 5:
                    {
                        currentSeason = SeasonsOfYear.Spring;
                        break;
                    }
                case 6:
                case 7:
                case 8:
                    {
                        currentSeason = SeasonsOfYear.Summer;
                        break;
                    }
                case 9:
                case 10:
                case 11:
                    {
                        currentSeason = SeasonsOfYear.Autumn;
                        break;
                    }
            }
            return currentSeason;
        }
        #endregion
        #region Метод возвращает название времени года на русском
        /// <summary>
        /// Возвращает название времени года на русском языкев виде строки
        /// </summary>
        /// <param name="season">Значение времени года</param>
        /// <returns>Строка содержащая название времени года на русском языке</returns>
        static string GetSeasonInRussian(SeasonsOfYear season)
        {
            string output = null;
            switch (season)
            {
                case SeasonsOfYear.Winter:
                    {
                        output = "Зима";
                        break;
                    }
                case SeasonsOfYear.Spring:
                    {
                        output = "Весна";
                        break;
                    }
                case SeasonsOfYear.Summer:
                    {
                        output = "Лето";
                        break;
                    }
                case SeasonsOfYear.Autumn:
                    {
                        output = "Осень";
                        break;
                    }
            }
            return output;
        }
        #endregion
    }
}
