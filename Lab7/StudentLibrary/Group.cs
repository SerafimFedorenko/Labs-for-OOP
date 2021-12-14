using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    /// <summary>
    /// Класс-контейнер, содержащий список студентов и обрабатывающий его
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Список студентов
        /// </summary>
        public List<Student> Students = new List<Student>();
        /// <summary>
        /// Базовый конструктор без параметров
        /// </summary>
        public Group()
        {

        }
        /// <summary>
        /// Метод добавления студента в список
        /// </summary>
        /// <param name="student"></param>
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        /// <summary>
        /// Метод, считающий среднюю стипендию у бюджетников
        /// </summary>
        /// <param name="minGrant"></param>
        /// <returns></returns>
        public double GetAverageGrant(double minGrant)
        {
            double grantsSum = 0;
            int grantsQuantity = 0;
            foreach(Student student in Students)
            {
                if(student.StudentType == TypeOfStudent.State)
                {
                    grantsSum += student.GetGrant(minGrant);
                    grantsQuantity++;
                }
            }
            return grantsSum / grantsQuantity;
        }
        /// <summary>
        /// Метод, считающий средний балл у всех студентов
        /// </summary>
        /// <returns></returns>
        public double GetAverageGrade()
        {
            double gradesSum = 0;
            int gradesQuantity = 0;
            foreach (Student student in Students)
            {
                gradesSum += student.GetAverageGrade();
                gradesQuantity++;
            }
            return gradesSum / gradesQuantity;
        }
        /// <summary>
        /// Метод возвращающий список платников, сдавших сессию вовремя
        /// </summary>
        /// <returns></returns>
        public List<Student> GetPassedOnTimePaidStudents()
        {
            List<Student> passedOnTimePaidStudents = new List<Student>();
            foreach (Student student in Students)
            {
                if(student.PassOnTime && student.StudentType == TypeOfStudent.Paid)
                {
                    passedOnTimePaidStudents.Add(student);
                }
            }
            return passedOnTimePaidStudents;
        }
    }
}
