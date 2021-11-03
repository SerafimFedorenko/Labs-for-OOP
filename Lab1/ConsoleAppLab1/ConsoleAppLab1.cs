using System;
using FiguresLibrary;

namespace TrapezoidConsoleApp
{
    class Lab1App
    {
        static void Main(string[] args)
        {
            double abscissaOfPoint;
            double ordinateOfPoint;
            string itemOfMenu;
            Console.WriteLine("Введите нижнюю границу интервала в котором задана трапеция");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите верхнюю границу интервала в котором задана трапеция");
            double x2 = Convert.ToDouble(Console.ReadLine());
            Trapezoid theTrapezoid = new Trapezoid(x1, x2);
            while (!theTrapezoid.IsExist())
            {
                Console.WriteLine("Hе существует трапеция с введёнными границами");
                Console.WriteLine("Введите нижнюю границу интервала в котором задана трапеция");
                x1 = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите верхнюю границу интервала в котором задана трапеция");
                x2 = Convert.ToDouble(Console.ReadLine());
                theTrapezoid = new Trapezoid(x1, x2);
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();
            do
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Вычислить длины сторон трапеции;");
                Console.WriteLine("2. Вычислить площадь трапеции;");
                Console.WriteLine("3. Вычислить периметр трапеции;");
                Console.WriteLine("4. Проверить принадлежность точки с заданными координатами фигуре;");
                Console.WriteLine("5. Проверить принадлежность точки с заданными координатами границе фигуры;");
                Console.WriteLine("6. Задать новую трапецию");
                Console.WriteLine("7. Выход.");
                itemOfMenu = Console.ReadLine();
                switch (itemOfMenu)
                {
                    case "1":
                        Console.WriteLine("Стороны трапеции:");
                        foreach (double side in theTrapezoid.CalcSides())
                            Console.WriteLine(side);
                        break;
                    case "2":
                        Console.WriteLine("Площадь трапеции: ");
                        Console.WriteLine(theTrapezoid.CalcSquare());
                        break;
                    case "3":
                        Console.WriteLine("Периметр трапеции:");
                        Console.WriteLine(theTrapezoid.CalcPerimeter());
                        break;
                    case "4":
                        Console.WriteLine("Введите координату точки по оси Ох");
                        abscissaOfPoint = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите координату точки по оси Оy");
                        ordinateOfPoint = Convert.ToDouble(Console.ReadLine());
                        if (theTrapezoid.IsBelongsToTheFigure(abscissaOfPoint, ordinateOfPoint))
                            Console.WriteLine("Точка с заданными координатами принадлежит фигуре");
                        else
                            Console.WriteLine("Точка с заданными координатами не принадлежит фигуре");
                        break;
                    case "5":
                        Console.WriteLine("Введите координату точки по оси Ох");
                        abscissaOfPoint = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите координату точки по оси Оy");
                        ordinateOfPoint = Convert.ToDouble(Console.ReadLine());
                        if (theTrapezoid.IsBelongsToTheBorder(abscissaOfPoint, ordinateOfPoint))
                            Console.WriteLine("Точка с заданными координатами принадлежит границе фигуры");
                        else
                            Console.WriteLine("Точка с заданными координатами не принадлежит границе фигуры");
                        break;
                    case "6":
                        Console.WriteLine("Введите нижнюю границу интервала в котором задана трапеция");
                        x1 = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Введите верхнюю границу интервала в котором задана трапеция");
                        x2 = Convert.ToDouble(Console.ReadLine());
                        theTrapezoid = new Trapezoid(x1, x2);
                        while (!theTrapezoid.IsExist())
                        {
                            Console.WriteLine("Hе существует трапеция с введёнными границами");
                            Console.WriteLine("Введите нижнюю границу интервала в котором задана трапеция");
                            x1 = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введите верхнюю границу интервала в котором задана трапеция");
                            x2 = Convert.ToDouble(Console.ReadLine());
                            theTrapezoid = new Trapezoid(x1, x2);
                        }
                        break;
                    case "7":
                        Console.WriteLine("Выход из программы");
                        break;
                    default:
                        Console.WriteLine("Неправильно введён пункт меню");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
            while (itemOfMenu != "7");
        }
    }
}
