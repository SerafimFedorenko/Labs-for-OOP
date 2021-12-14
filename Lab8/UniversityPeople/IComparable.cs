using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    /// <summary>
    /// Интерфейс для сортировки объектов
    /// </summary>
    public interface IComparable
    {
        /// <summary>
        /// Интерфейсный метод для сравнения работников
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        int CompareTo(Worker other);
    }
}
