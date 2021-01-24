using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Reflection;

namespace HomeTask_3
{
    public class BechmarkClass
    {
        // Инициализация массивов координат для различных типов данных
        const int numberOfCoordinates = 10_000;
        static float[] floatCoordinate = new float[numberOfCoordinates];
        static double[] doubleCoordinate = new double[numberOfCoordinates];
        static int[] intCoordinate = new int[numberOfCoordinates];
        static long[] longCoordinate = new long[numberOfCoordinates];
        private static int count = 0;
        /// <summary>
        /// Конструктор класса Benchmark наполняющий масиивы координат случайными числами
        /// </summary>
        static BechmarkClass()
        {
            Random rnd = new Random();
            for (int i = 0; i < numberOfCoordinates; i++)
            {
                floatCoordinate[i] = (float)rnd.NextDouble();
                doubleCoordinate[i] = rnd.NextDouble();
                intCoordinate[i] = rnd.Next(int.MinValue, int.MaxValue);
                longCoordinate[i] = rnd.Next(int.MinValue, int.MaxValue)* rnd.Next(0, 100000);
            }
        }
        /// <summary>
        /// Возвращает две координаты типа float последовательно из массива координат
        /// </summary>
        /// <returns>Две координаты float</returns>
        private static (float x, float y) GiveMeFloatCoordinate()
        {
            count = (count < (numberOfCoordinates - 2)) ? count + 1 : 0;
            return (floatCoordinate[count], floatCoordinate[++count]);
        }
        /// <summary>
        /// Возвращает две координаты типа double последовательно из массива координат
        /// </summary>
        /// <returns>Две координаты double</returns>
        private static (double x, double y) GiveMeDoubleCoordinate()
        {
            count = (count < (numberOfCoordinates - 2)) ? count + 1 : 0;
            return (doubleCoordinate[count], doubleCoordinate[++count]);
        }
        /// <summary>
        /// Возвращает две координаты типа Int последовательно из массива координат
        /// </summary>
        /// <returns>Две координаты Int</returns>
        private static (int x, int y) GiveMeIntCoordinate()
        {
            count = (count < (numberOfCoordinates - 2)) ? count + 1 : 0;
            return (intCoordinate[count], intCoordinate[++count]);
        }
        /// <summary>
        /// Возвращает две координаты типа Long последовательно из массива координат
        /// </summary>
        /// <returns>Две координаты Long</returns>
        private static (long x, long y) GiveMeLongCoordinate()
        {
            count = (count < (numberOfCoordinates - 2)) ? count + 1 : 0;
            return (longCoordinate[count], longCoordinate[++count]);
        }

        [Benchmark(Description ="Дистанция через класс Float")]
        public void TestDistanceFromClassFloat()
        {
            PointClassOfFloat firstPoint = new PointClassOfFloat(GiveMeFloatCoordinate());
            PointClassOfFloat secondPoint = new PointClassOfFloat(GiveMeFloatCoordinate());
            PointClassOfFloat.GetDistance(firstPoint, secondPoint);
        }
        [Benchmark(Description = "Дистанция через структуру Float")]
        public void TestDistanceFromStructFloat()
        {
            PointStructOfFloat firstPoint = new PointStructOfFloat(GiveMeFloatCoordinate());
            PointStructOfFloat secondPoint = new PointStructOfFloat(GiveMeFloatCoordinate());
            PointStructOfFloat.GetDistance(firstPoint, secondPoint);
        }
        [Benchmark(Description = "Дистанция через структуру Double")]
        public void TestDistanceFromStructDouble()
        {
            PointStructOfDouble firstPoint = new PointStructOfDouble(GiveMeDoubleCoordinate());
            PointStructOfDouble secondPoint = new PointStructOfDouble(GiveMeDoubleCoordinate());
            PointStructOfDouble.GetDistance(firstPoint, secondPoint);
        }
        [Benchmark(Description = "Дистанция через структуру Float (без квадратного корня)")]
        public void TestDistanceFromStructFloatWithoutSqrt()
        {
            PointStructOfFloat firstPoint = new PointStructOfFloat(GiveMeFloatCoordinate());
            PointStructOfFloat secondPoint = new PointStructOfFloat(GiveMeFloatCoordinate());
            PointStructOfFloat.GetDistanceWithoutSqrt(firstPoint, secondPoint);
        }
        [Benchmark(Description = "Дистанция через структуру Int")]
        public void TestDistanceFromStructInt()
        {
            PointStructOfInt firstPoint = new PointStructOfInt(GiveMeIntCoordinate());
            PointStructOfInt secondPoint = new PointStructOfInt(GiveMeIntCoordinate());
            PointStructOfInt.GetDistance(firstPoint, secondPoint);
        }
        [Benchmark(Description = "Дистанция через структуру Long")]
        public void TestDistanceFromStructLong()
        {
            PointStructOfLong firstPoint = new PointStructOfLong(GiveMeIntCoordinate());
            PointStructOfLong secondPoint = new PointStructOfLong(GiveMeIntCoordinate());
            PointStructOfLong.GetDistance(firstPoint, secondPoint);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);            
        }
    }
    /// <summary>
    /// Класс точек с координатами типа Float
    /// </summary>
    class PointClassOfFloat
    {
        private float X { get; set; }
        private float Y { get; set; }

        private const int multiply = 100_000;
        public PointClassOfFloat((float x, float y) point)
        {
            X = point.x * multiply;
            Y = point.y * multiply;
        }
        /// <summary>
        /// Возвращает значение расстояния между двумя точками
        /// </summary>
        /// <param name="firstPoint">Точка с координатами типа Float</param>
        /// <param name="secondPoint">Точка с координатами типа Float</param>
        /// <returns>Расстояние</returns>
        public static float GetDistance(PointClassOfFloat firstPoint, PointClassOfFloat secondPoint)
        {
            float x = firstPoint.X - secondPoint.X;
            float y = firstPoint.Y - secondPoint.Y;
            return MathF.Sqrt(x * x + y * y);
        }
    }
    /// <summary>
    /// Структура точек с координатами типа Float
    /// </summary>
    struct PointStructOfFloat
    {
        private float X { get; set; }
        private float Y { get; set; }

        private const int multiply = 100_000;
        public PointStructOfFloat((float x, float y) point)
        {
            X = point.x * multiply;
            Y = point.y * multiply;
        }
        /// <summary>
        /// Возвращает значение расстояния между двумя точками
        /// </summary>
        /// <param name="firstPoint">Точка с координатами типа Float</param>
        /// <param name="secondPoint">Точка с координатами типа Float</param>
        /// <returns>Расстояние</returns>
        public static float GetDistance(PointStructOfFloat firstPoint, PointStructOfFloat secondPoint)
        {
            float x = firstPoint.X - secondPoint.X;
            float y = firstPoint.Y - secondPoint.Y;
            return MathF.Sqrt(x * x + y * y);
        }
        /// <summary>
        /// Возвращает значение квадрата расстояния между двумя точками (без вычисления корня)
        /// </summary>
        /// <param name="firstPoint">Точка с координатами типа Float</param>
        /// <param name="secondPoint">Точка с координатами типа Float</param>
        /// <returns>Квадрат расстояния</returns>
        public static float GetDistanceWithoutSqrt(PointStructOfFloat firstPoint, PointStructOfFloat secondPoint)
        {
            float x = firstPoint.X - secondPoint.X;
            float y = firstPoint.Y - secondPoint.Y;
            return (x * x + y * y);
        }
    }
    /// <summary>
    /// Структура точек с координатами типа Double
    /// </summary>
    struct PointStructOfDouble
    {
        private double X { get; set; }
        private double Y { get; set; }
        private const int multiply = 100_000;
        public PointStructOfDouble((double x, double y) point)
        {
            X = point.x * multiply;
            Y = point.y * multiply;
        }
        /// <summary>
        /// Возвращает значение расстояния между двумя точками
        /// </summary>
        /// <param name="firstPoint">Точка с координатами типа Double</param>
        /// <param name="secondPoint">Точка с координатами типа Double</param>
        /// <returns>Расстояние</returns>
        public static double GetDistance(PointStructOfDouble firstPoint, PointStructOfDouble secondPoint)
        {
            double x = firstPoint.X - secondPoint.X;
            double y = firstPoint.Y - secondPoint.Y;
            return Math.Sqrt(x * x + y * y);
        }
    }
    /// <summary>
    /// Структура точек с координатами типа Int
    /// </summary>
    struct PointStructOfInt
    {
        private int X { get; set; }
        private int Y { get; set; }
        public PointStructOfInt((int x, int y) point)
        {
            X = point.x;
            Y = point.y;
        }
        /// <summary>
        /// Возвращает значение расстояния между двумя точками
        /// </summary>
        /// <param name="firstPoint">Точка с координатами типа Int</param>
        /// <param name="secondPoint">Точка с координатами типа Int</param>
        /// <returns>Расстояние</returns>
        public static double GetDistance(PointStructOfInt firstPoint, PointStructOfInt secondPoint)
        {
            int x = firstPoint.X - secondPoint.X;
            int y = firstPoint.Y - secondPoint.Y;
            return Math.Sqrt(x * x + y * y);
        }
    }
    /// <summary>
    /// Структура точек с координатами типа Long
    /// </summary>
    struct PointStructOfLong
    {
        private long X { get; set; }
        private long Y { get; set; }
        public PointStructOfLong((long x, long y) point)
        {
            X = point.x;
            Y = point.y;
        }
        /// <summary>
        /// Возвращает значение расстояния между двумя точками
        /// </summary>
        /// <param name="firstPoint">Точка с координатами типа Long</param>
        /// <param name="secondPoint">Точка с координатами типа Long</param>
        /// <returns>Расстояние</returns>
        public static double GetDistance(PointStructOfLong firstPoint, PointStructOfLong secondPoint)
        {
            long x = firstPoint.X - secondPoint.X;
            long y = firstPoint.Y - secondPoint.Y;
            return Math.Sqrt(x * x + y * y);
        }
    }
}
