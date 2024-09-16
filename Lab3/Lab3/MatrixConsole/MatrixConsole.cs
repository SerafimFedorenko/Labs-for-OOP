using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixAdapter;
using MatrixLibrary;

namespace MatrixConsole
{
    class MatrixConsole
    {
        static ConsoleInOutMatrix conIOMatrix = new ConsoleInOutMatrix();
        static void InOutMatrix(
            out Matrix matrixA,
            out Matrix matrixB,
            out Matrix matrixC)
        {
            matrixA = conIOMatrix.InputMatrix();
            Console.Clear();
            matrixB = conIOMatrix.InputMatrix();
            Console.Clear();
            matrixC = conIOMatrix.InputMatrix();
            Console.Clear();
            conIOMatrix.OutputMatrix(matrixA);
            conIOMatrix.OutputMatrix(matrixB);
            conIOMatrix.OutputMatrix(matrixC);
        }
        static void CalcAndOutputAverageMeanOfNegative(Matrix matrixA, Matrix matrixB, Matrix matrixC)
        {
            try
            {
                Console.Write($"\nСреднее значение отрицательных элементов в матрице {matrixA.Name}:");
                Console.WriteLine($" {Math.Round(matrixA.GetAverageMeanOfNegative(3), 3)}:");
            }
            catch
            {
                Console.Write("\nВычисление невозможно! " +
                $"В матрице {matrixA.Name} отрицательных элементов повторяющихся больше 3 раз!");
            }
            try
            {
                Console.Write($"\nСреднее значение отрицательных элементов в матрице {matrixB.Name}:");
                Console.WriteLine($" {Math.Round(matrixB.GetAverageMeanOfNegative(3), 3)}:");
            }
            catch
            {
                Console.WriteLine("\nВычисление невозможно! " +
                $"В матрице {matrixB.Name} отрицательных элементов повторяющихся больше 3 раз!");
            }
            try
            {
                Console.Write($"\nСреднее значение отрицательных элементов в матрице {matrixC.Name}:");
                Console.WriteLine($" {Math.Round(matrixC.GetAverageMeanOfNegative(3), 3)}:");
            }
            catch
            {
                Console.WriteLine("\nВычисление невозможно! " +
                $"В матрице {matrixC.Name} отрицательных элементов повторяющихся больше 3 раз!");
            }
        }
        static void MultiplicateAll(Matrix matrixA, Matrix matrixB, Matrix matrixC)
        {
            if (matrixA.IsEqual(matrixB) && matrixB.IsEqual(matrixC))
            {
                Console.WriteLine("Результат поэлементного умножения трёх матриц:");
                conIOMatrix.OutputMatrix(matrixA * matrixB * matrixC);
            }
            else
            {
                Console.WriteLine("Поэлементное умножение трёх матриц невозможно из-за несовпадения размерностей");
            }
        }
        static void CalculationsHorrbleThings(Matrix matrixA, Matrix matrixB, Matrix matrixC)
        {
            Console.WriteLine($"Введите число, с которым будет сравниваться среднее арифметическое отрицательных элементов матрицы {matrixA.Name}");
            int number = Convert.ToInt32(Console.ReadLine());
            if (matrixA.GetAverageMeanOfNegative() > number)
            {
                if (matrixC)
                {
                    for (int i = 0; i < matrixC.Rows; i++)
                    {
                        for (int j = 0; j < matrixC.Columns; j++)
                        {
                            if (matrixC[i, j] != 0)
                            {
                                try
                                { 
                                    matrixC[i, j] += (int)(matrixA * matrixB).GetAverageMeanOfNegative(2); 
                                }
                                catch
                                {
                                    Console.WriteLine($"В произведении массивов {matrixA.Name} и {matrixB.Name} \n" +
                                        "нет повторяющихся больше двух раз отрицательных элементов");
                                    break;
                                }
                            }
                        }
                    }
                    conIOMatrix.OutputMatrix(matrixC);
                }
                else
                {
                    Console.WriteLine($"В матрице {matrixC.Name} нет ненулевых элементов");
                }
            }
            else
            {
                Console.WriteLine($"Вы ввели число большее или равное среднему арифметическому отрицательных элементов матрицы {matrixA.Name}");
            }
        }
        static void Main(string[] args)
        {
            Matrix matrixA = new Matrix();
            Matrix matrixB = new Matrix();
            Matrix matrixC = new Matrix();
            InOutMatrix(out matrixA, out matrixB, out matrixC);

            string menuItem;
            do
            {
                Console.WriteLine("Ввeдите пункт меню:");
                Console.WriteLine("1. Ввод и вывод трех матриц А, В и С;");
                Console.WriteLine("2. Вычисление и вывод среднего арифметического \n" +
                    "отрицательных элементов матрицы, которые повторяются более 3 раз в каждой матрице;");
                Console.WriteLine("3. Вычисление А*В*С, если это возможно;");
                Console.WriteLine("4. Если среднее арифметическое отрицательных элементов матрицы А больше заданного числа, \n" +
                    "а в матрице С есть ненулевые элементы, увеличить все ненулевые элементы массива С \n" +
                    "на значение минимального среднего арифметического отрицательных \n" +
                    "элементов матрицы А*В, которые повторяются более 2 раз.\n");
                menuItem = Console.ReadLine();
                switch (menuItem)
                {
                    case "1":
                        InOutMatrix(out matrixA, out matrixB, out matrixC);
                        break;
                    case "2":
                        CalcAndOutputAverageMeanOfNegative(matrixA, matrixB, matrixC);
                        break;
                    case "3":
                        MultiplicateAll(matrixA, matrixB, matrixC);
                        break;
                    case "4":
                        CalculationsHorrbleThings(matrixA, matrixB, matrixC);
                        break;
                }
            }
            while (menuItem != "5");
            Console.ReadLine();
        }
    }
}
