using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    /// <summary>
    /// Класс студент-платник наследующийся от абстрактного класса студент
    /// </summary>
    public class PaidStudent : Student
    {
        /// <summary>
        /// Базовый конструктор класса студент-платник наследующийся от конструктора абстрактного класса студент
        /// </summary>
        /// <param name="grades"></param>
        /// <param name="passOnTime"></param>
        /// <param name="fullName"></param>
        /// <param name="studentType"></param>
        public PaidStudent(List<int> grades, bool passOnTime, string fullName, TypeOfStudent studentType) : base(grades, passOnTime, fullName, studentType)
        {
        }
        /// <summary>
        /// Метод, возвращающий стипендию: для платника она равна нулю
        /// </summary>
        /// <param name="minGrant"></param>
        /// <returns></returns>
        public override double GetGrant(double minGrant)
        {
            return 0;
        }
    }
}
