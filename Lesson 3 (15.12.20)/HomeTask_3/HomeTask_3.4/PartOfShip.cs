using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_3._4
{
    /// <summary>
    /// Класс представляющий элемент корабля в виде точки
    /// </summary>
    class PartOfShip
    {
        public int x;       // Координата по горизонтали
        public int y;       // Координата повертикали
        private char sym;   // Символ изображающий элемент корабля на консоли
        /// <summary>
        /// Создание объекта в виде элемента корабля
        /// </summary>
        /// <param name="x">Координата по горизонтали (от 0 до 9)</param>
        /// <param name="y">Координата по вертикали (от 0 до 9)</param>
        /// <param name="sym">Символ изображающий часть корабля</param>
        public PartOfShip(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }
        /// <summary>
        /// Создание объекта в виде элемента корабля в виде копии другого объекта
        /// </summary>
        /// <param name="p">Копируемый объект</param>
        public PartOfShip(PartOfShip p)
        {
            this.x = p.x;
            this.y = p.y;
            this.sym = p.sym;
        }
        /// <summary>
        /// Смещение элемента корабля на заданную величину в заданном направлении
        /// </summary>
        /// <param name="offset">Величина смещения</param>
        /// <param name="isVertical">Направление смещения (true - по вертикали, false - по горизонтали)</param>
        public void Move (int offset, bool isVertical)
        {
            if (isVertical) this.y += offset;
            else this.x += offset;
        }
    }
}
