using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    /// <summary>
    /// Класс рабочий
    /// </summary>
    public class Worker : Human, IComparable<Worker>
    {
        /// <summary>
        /// Место работы
        /// </summary>
        public string WorkPlace { get; set; }
        /// <summary>
        /// Статус работника
        /// </summary>
        public int[] Salaries = new int[12];
        /// <summary>
        /// Конструктор класса рабочий
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        /// <param name="status"></param>
        /// <param name="workPlace"></param>
        /// <param name="salaries"></param>
        public Worker(string surname, int birthday,string status, string workPlace, int[] salaries)
        {
            WorkPlace = workPlace;
            Surname = surname;
            Birthday = birthday;
            Salaries = salaries;
            Status = status;
        }
        /// <summary>
        /// Метод, вычисляющий максимальную зарплату рабочего
        /// </summary>
        /// <returns></returns>
        public override double Intelligence()
        {
            int maxSalary = Salaries.Max<int>();
            return maxSalary;
        }
        /// <summary>
        /// Метод для вывода информации о рабочем
        /// </summary>
        /// <returns></returns>
        public override string GetInformation()
        {
            return Surname + " " + Status + " " + Birthday + " " + Intelligence();
        }
        /// <summary>
        /// Метод, реализующий интерфейс IComparable, для сортировки рабочих по алфавиту
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Worker other)
        {
            return Surname.CompareTo(other.Surname);
        }
    }
}
