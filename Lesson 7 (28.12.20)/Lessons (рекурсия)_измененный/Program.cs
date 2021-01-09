// Decompiled with JetBrains decompiler
// Type: Lessons__рекурсия_.Program
// Assembly: Lessons (рекурсия), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B8275EB6-AD94-41F3-BE84-61DB737C9AB0
// Assembly location: C:\Users\Temich\Desktop\Программирование\Geekbrains\GeekBrains-Home_Tasks\Lesson 7 (28.12.20)\Lessons (рекурсия)\bin\Release\Lessons (рекурсия).exe

using System;

namespace Lessons__рекурсия_
{
  internal class Program
  {
    private static void PrintArray(int[] array, int i = 0)
    {
      if (i >= array.Length)
        return;
      Console.Write(string.Format("{0} ", (object) array[i]));
      Program.PrintArray(array, ++i);
    }

    private static int SumArray(int[] array, int i = 0) => i >= array.Length ? 0 : array[i] + Program.SumArray(array, ++i);

    private static long SumDigits(long num) => num / 10L == 0L ? num % 10L : num % 10L + Program.SumDigits(num / 10L);

    private static void Main(string[] args)
    {
      int[] array = new int[10]
      {
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10
      };
      long num = 987654321;
      Console.Write("Массив: ");
      Program.PrintArray(array);
      Console.Write("\nСумма всех чисел в массиве равна = ");
      Console.WriteLine(Program.SumArray(array));
      Console.Write(string.Format("\nСумма всех цифр в числе \"{0}\" равна = ", (object) num));
      Console.WriteLine(Program.SumDigits(num));
      Console.ReadLine();
    }
  }
}
