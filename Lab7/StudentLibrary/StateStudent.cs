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
    public class StateStudent : Student
    {
        /// <summary>
        /// Базовый конструктор класса студент-платник наследующийся от конструктора абстрактного класса студент
        /// </summary>
        /// <param name="grades"></param>
        /// <param name="passOnTime"></param>
        /// <param name="fullName"></param>
        /// <param name="studentType"></param>
        public StateStudent(List<int> grades, bool passOnTime, string fullName, TypeOfStudent studentType) : base(grades, passOnTime, fullName, studentType)
        {
        }
        /// <summary>
        /// Метод, возвращающий стипендию: для бюджетника она зависит от оценки и минимальной стипендии 
        /// </summary>
        /// <param name="minGrant"></param>
        /// <returns></returns>
        public override double GetGrant(double minGrant)
        {
            if (GetAverageGrade() < 5 || !PassOnTime)
            {
                return 0;
            }
            else if (GetAverageGrade() < 6)
            {
                return minGrant;
            }
            else if (GetAverageGrade() < 8)
            {
                return minGrant * 1.25;
            }
            else if (GetAverageGrade() <= 10)
            {
                return minGrant * 1.5;
            }
            return 0;
        }
    }
}
