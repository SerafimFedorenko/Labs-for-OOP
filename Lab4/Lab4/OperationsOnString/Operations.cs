using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OperationsOnString
{
    /// <summary>
    /// Класс операций над строками
    /// </summary>
    public class Operations
    {
        /// <summary>
        /// Метод, выясняющий возможность создания слова из букв другого слова 
        /// </summary>
        /// <param name="mainWord"></param>
        /// <param name="searchedWord"></param>
        /// <returns></returns>
        public bool CanCreateWord(string mainWord, string searchedWord)
        {
            mainWord = mainWord.ToLower();
            searchedWord = searchedWord.ToLower();
            foreach (char simbol in searchedWord)
            {
                if (mainWord.IndexOf(simbol) == -1)
                {
                    return false;
                }
                else
                {
                    mainWord = mainWord.Remove(mainWord.IndexOf(simbol), 1);
                }
            }
            return true;
        }
        /// <summary>
        /// Создание массива предложений, содержащих буквы и цифры
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public List<string> CreateArrayOfSentences(string text)
        {
            List<string> sentences = new List<string>(Regex.Split(text, @"(?<=[\.!\?])\s+"));
            foreach (string sentence in sentences)
            {
                if (IsIncludeLetAndNum(sentence))
                {
                    sentences.Add(sentence);
                }
            }
            return sentences;
        }
        /// <summary>
        /// Метод для получения суммы всех чисел в массиве строк
        /// </summary>
        /// <param name="sentences"></param>
        /// <returns></returns>
        public int CalcSumOfNumInArray(List<string> sentences)
        {
            int sumOfNumbers = 0;
            foreach (string sentence in sentences)
            {
                sumOfNumbers += CalcSumOfNumInSentence(sentence);
            }
            return sumOfNumbers;
        }
        /// <summary>
        /// Метод для получения суммы всех чисел в строке
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public int CalcSumOfNumInText(string text)
        {
            
            List<string> sentences = CreateArrayOfSentences(text);
            int sumOfNumbers = CalcSumOfNumInArray(sentences);
            return sumOfNumbers;
        }
        /// <summary>
        /// Метод для вычисления суммы чисел в предложении
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public int CalcSumOfNumInSentence(string sentence)
        {
            int sumOfNumbers = 0;
            StringBuilder numberSB = new StringBuilder("");
            int number;
            foreach (char simbol in sentence)
            {
                if (Char.IsDigit(simbol))
                {
                    numberSB.Append(simbol);
                }
                else
                {
                    if(int.TryParse(numberSB.ToString(), out number))
                    {
                        sumOfNumbers += number;
                        numberSB.Remove(0,numberSB.Length);
                    }
                }
            }
            if (int.TryParse(numberSB.ToString(), out number))
            {
                sumOfNumbers += number;
            }
            return sumOfNumbers;
        }
        /// <summary>
        /// Метод, выясняющий, содержит ли строка буквы и цифры
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public bool IsIncludeLetAndNum(string sentence)
        {
            Regex regexNumAndLet = new Regex(@"([a-zа-я]\W*[0-9])|([0-9]\W*[а-яa-z])", RegexOptions.IgnoreCase);
            if (regexNumAndLet.IsMatch(sentence))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}