using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    /// <summary>
    /// Фабрика студентов
    /// </summary>
    public class StudentFabric
    {
        /// <summary>
        /// Метод возвращающий студента с полученными параметрами
        /// </summary>
        /// <param name="grades"></param>
        /// <param name="passOnTime"></param>
        /// <param name="name"></param>
        /// <param name="typeOfStudent"></param>
        /// <returns></returns>
        public static Student GetStudent(List<int> grades, bool passOnTime, string name, TypeOfStudent typeOfStudent)
        {
            Student student = null;
            switch(typeOfStudent)
            {
                case TypeOfStudent.State:
                    student = new StateStudent(grades, passOnTime, name, typeOfStudent);
                    break;
                case TypeOfStudent.Paid:
                    student = new PaidStudent(grades, passOnTime, name, typeOfStudent);
                    break;
            }
            return student;
        }
    }
}
