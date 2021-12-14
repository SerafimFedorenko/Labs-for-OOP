using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    /// <summary>
    /// Абстрактный класс человек
    /// </summary>
    public abstract class Human
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Год рождения
        /// </summary>
        public int Birthday { get; set; }
        /// <summary>
        /// Статус человека
        /// </summary>
        public string Status;
        /// <summary>
        /// Абстрактный метод для вывода дополнительных сведений о человеке 
        /// </summary>
        /// <returns></returns>
        public abstract double Intelligence();
        /// <summary>
        /// Абстрактный метод для вывода информаации о человеке
        /// </summary>
        /// <returns></returns>
        public abstract string GetInformation();
    }
}
