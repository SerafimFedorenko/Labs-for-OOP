using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    /// <summary>
    /// Абстрактный класс учащийся 
    /// </summary>
    public abstract class Learner : Human
    {
        /// <summary>
        /// Список оценок учащегося
        /// </summary>
        public List<int> Grades = new List<int>();
        /// <summary>
        /// Учреждения образования, в котором учится учащийся
        /// </summary>
        public string EducationalInstitution { get; set; }
        /// <summary>
        /// Метод, вычисляющий средний балл
        /// </summary>
        /// <returns></returns>
        public override double Intelligence()
        {
            double sumGrades = 0;
            int quantGrades = 0;
            foreach (int grade in Grades)
            {
                sumGrades += grade;
                quantGrades++;
            }
            return sumGrades / quantGrades;
        }
    }
}
