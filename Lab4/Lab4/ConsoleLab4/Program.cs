using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationsOnString;

namespace ConsoleLab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations operations = new Operations();
            string menuItem;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Проверить, можно ли из первого слова составить второе слово;");
                Console.WriteLine("2. Посчитать сумму всех чисел в массиве строк, состоящих из букв и цифр;");
                Console.WriteLine("3. Выход из программы.");
                menuItem = Console.ReadLine();
                Console.Clear();
                switch (menuItem)
                {
                    case "1":
                        Console.WriteLine("Введите первое слово, в котором будем искать буквы из второго слова");
                        string mainWord = Console.ReadLine();
                        Console.WriteLine("Введите слово, буквы которого будем искать в первом слове");
                        string searchedWord = Console.ReadLine();
                        if (operations.CanCreateWord(mainWord, searchedWord))
                        {
                            Console.WriteLine($"Из букв слова {mainWord} можно составить слово {searchedWord}");
                        }
                        else
                        {
                            Console.WriteLine($"Из букв слова {mainWord} нельзя составить слово {searchedWord}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите текст");
                        string text = Console.ReadLine();
                        Console.WriteLine("Предложения с буквами и цифрами из текста:");
                        foreach (string sentence in operations.CreateArrayOfSentences(text))
                        {
                            Console.WriteLine(sentence);
                        }
                        int sumOfNumbers = operations.CalcSumOfNumInText(text);
                        Console.WriteLine($"Сумма всех чисел в тексте: {sumOfNumbers}");
                        break;
                    case "3":
                        Console.WriteLine("Выход из программы");
                        break;
                    default:
                        Console.WriteLine("Введёно неверное значение");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (menuItem != "3");
        }
    }
}
