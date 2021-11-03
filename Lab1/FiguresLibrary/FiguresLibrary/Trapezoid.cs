using System;

namespace FiguresLibrary
{
    public class Trapezoid
    {
        public double x1, x2;
        /// <summary>
        /// Корструктор класса Trapezoid, определяющий верхнюю и нижнюю границы трапеции
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        public Trapezoid(double firstX, double secondX)
        {
            this.x1 = Math.Min(firstX, secondX);
            this.x2 = Math.Max(firstX, secondX);
        }
        /// <summary>
        /// Метод проверяющий существование фигуры
        /// </summary>
        /// <returns></returns>
        public bool IsExist()
        {
            if (x1 < 1 && x2 > 1 || x1 > 1 && x2 < 1 || x1 <= 0 || x2 <= 0 || x1 == x2 || x1 == 1 || x2 == 1)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Метод, считающий стороны фигуры
        /// </summary>
        /// <returns></returns>
        public double[] CalcSides()
        {
            double[] sides = new double[4];
            sides[0] = Math.Abs(Math.Log(x1));
            sides[1] = Integration(x1, x2);
            sides[2] = Math.Abs(Math.Log(x2));
            sides[3] = x2 - x1;
            return sides;
        }
        /// <summary>
        /// Метод, считающий периметр фигуры
        /// </summary>
        /// <returns></returns>
        public double CalcPerimeter()
        {
            double perimeter = 0;
            foreach (double side in CalcSides())
                perimeter += side;
            return perimeter;
        }
        /// <summary>
        /// Метод, считающий площадь фигуры
        /// </summary>
        /// <returns></returns>
        public double CalcSquare()
        {
            return Math.Abs(x2 * Math.Log(x2) - x2 - (x1 * Math.Log(x1) - x1));
        }
        /// <summary>
        /// Метод, проверяющий принадлежность точки к границе фигуры
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsBelongsToTheBorder(double x, double y)
        {
            if (x == x1 && Math.Abs(Math.Log(x1)) >= Math.Abs(y) && Math.Sign(y) == Math.Sign(Math.Log(x1)))
                return true;
            else
                if (x == x2 && Math.Abs(Math.Log(x2)) >= Math.Abs(y) && Math.Sign(y) == Math.Sign(Math.Log(x2)))
                return true;
            else
                if (x > x1 && x < x2 && (y == Math.Log(x) || y == 0))
                return true;
            else return false;
        }
        /// <summary>
        /// Метод проверяющий принадлежность точки фигуре
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsBelongsToTheFigure(double x, double y)
        {
            if (x >= x1 && x <= x2 && Math.Abs(y) <= Math.Abs(Math.Log(x)) && (Math.Sign(y) == Math.Sign(Math.Log(x)) || y == 0))
                return true;
            else return false;
        }
        /// <summary>
        /// </summary>
        /// <param name="a"></param>
        /// Метод, осуществляющий интегрирование, необходимое для вычисления длины дуги кривой
        /// <param name="b"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public double Integration(double a, double b)
        {
            double n = 100000;
            double h = (b - a) / n;
            b = a + h;
            int i = 0;
            double integ = 0;
            while (i < n)
            {
                integ = integ + h * (Foo(a) + 3 * Foo((2 * a + b) / 3) + 3 * Foo((a + 2 * b) / 3) + Foo(b)) / 8;
                a = b;
                b = b + h;
                i++;
            }
            return integ;
        }
        /// <summary>
        /// Метод, содержащий подынтегральную функцию
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public double Foo(double x)
        {
            return Math.Pow((1 + Math.Pow(x, -2)), 1.0 / 2);
        }
    }
}
