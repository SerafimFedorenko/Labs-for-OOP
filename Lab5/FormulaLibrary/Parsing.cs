using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormulaLibrary
{
    /// <summary>
    /// Класс реализующий парсинг и вычисление функции из строки
    /// </summary>
    public class Parsing
    {
        /// <summary>
        /// Метод, выясняющий корректность введённой функции
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public bool CheckCorrectness(string formula)
        {
            Regex regex = new Regex(@"^[a-z]+\([a-z]\)=(sin|cos|tg|ctg)\([a-z]\)(\+|\*|\-|\/)(sin|cos|tg|ctg)\([a-z]\)$");
            if (regex.IsMatch(formula))
            {
                string[] words = Regex.Split(formula, @"[\(\=\*\/\-\+]");
                if (words[1] == words[3] && words[3] == words[5])
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Метод, возвращающий введённые тригонометрические функции ввиде строк 
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public string[] GetFunctions(string formula)
        {
            string[] words = Regex.Split(formula, @"[\(\=\*\/\-\+]");
            string[] functions = new string[2];
            functions[0] = words[2];
            functions[1] = words[4];
            return functions;
        }
        /// <summary>
        /// Метод, возвращающий математический знак, стоящий между тригонометрическими функциями 
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        public char GetMathSign(string formula)
        {
            char[] signs = { '+', '-', '*', '/' };
            foreach (char sing in signs)
            {
                if (formula.Contains(sing))
                {
                    return sing;
                }
            }
            return '+';
        }
        /// <summary>
        /// Метод вычисляющий значение суммы в зависимости от математического знака
        /// </summary>
        /// <param name="sign"></param>
        /// <param name="result1"></param>
        /// <param name="result2"></param>
        /// <returns></returns>
        private double CalcExpression(char sign, double result1, double result2)
        {
            Dictionary<char, Func<double, double, double>> expression = new Dictionary<char, Func<double, double, double>>()
            {
                {
                    '+',(num1, num2) => num1 + num2
                },
                {
                    '-',(num1, num2) => num1 - num2
                },
                {
                    '*',(num1, num2) => num1 * num2
                },
                {
                    '/',(num1, num2) => num1 / num2
                }
            };
            return expression[sign](result1, result2);
        }
        /// <summary>
        /// Метод вычиляющий тригонометрические функции
        /// </summary>
        /// <param name="func"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private double CalcTrigFunction(string func, double point)
        {
            Dictionary<string, Func<double, double>> expression = new Dictionary<string, Func<double, double>>()
            {
                {
                    "sin",(num) => Math.Sin(num)
                },
                {
                    "cos",(num) => Math.Cos(num)
                },
                {
                    "tg",(num) => Math.Tan(num)
                },
                {
                    "ctg",(num) => 1 / Math.Tan(num)
                }
            };
            return expression[func](point);
        }
        /// <summary>
        /// Метод принимающий строку с функцией и вычисляющий выражение в определённой точке
        /// </summary>
        /// <param name="formula"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public double CalcFunction(string formula, double point)
        {
            string[] functions = GetFunctions(formula);
            char sign = GetMathSign(formula);
            double result = CalcExpression(sign, CalcTrigFunction(functions[0], point), CalcTrigFunction(functions[1], point));
            return result;
        }
    }
}