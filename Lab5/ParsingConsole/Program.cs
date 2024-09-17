using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaLibrary;

namespace ParsingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Parsing parsing = new Parsing();
            Console.WriteLine("Введите формулу");
            string formula = Console.ReadLine();
            Console.WriteLine("Введите точку");
            double point = Convert.ToDouble(Console.ReadLine());
            if (parsing.CheckCorrectness(formula))
            {
                Console.WriteLine($"Результат вычисления функции в точке {point}:");
                Console.WriteLine(parsing.CalcFunction(formula, point));
            }
            else
            {
                Console.WriteLine("Функция введена неверно");
            }
            Console.ReadKey();
        }
    }
}
