using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary
{
    /// <summary>
    /// Перечисление тип студента
    /// </summary>
    public enum TypeOfStudent
    {
        /// <summary>
        /// Бюджетник соответствует нулю
        /// </summary>
        State,
        /// <summary>
        /// Платник соответствует единице
        /// </summary>
        Paid
    }
    /// <summary>
    /// Абстрактный класс студент
    /// </summary>
    public abstract class Student
    {
        /// <summary>
        /// Тип студента: платник или бюджетник
        /// </summary>
        public TypeOfStudent StudentType { get; set; }
        /// <summary>
        /// Оценки студента
        /// </summary>
        public List<int> Grades = new List<int>();
        /// <summary>
        /// Полное имя студента
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Булевская переменная, отвечающая на вопрос "сдал ли студент экзамены вовремя?"
        /// </summary>
        public bool PassOnTime { get; set; }
        /// <summary>
        /// Базовый констркуктор класса студент
        /// </summary>
        /// <param name="grades"></param>
        /// <param name="passOnTime"></param>
        /// <param name="fullName"></param>
        /// <param name="studentType"></param>
        public Student(List<int> grades, bool passOnTime, string fullName, TypeOfStudent studentType)
        {
            FullName = fullName;
            StudentType = studentType;
            PassOnTime = passOnTime;
            Grades = grades;
        }
        /// <summary>
        /// Абстрактный метод для получения стипендии студента: для разных типов студентов он разный
        /// </summary>
        /// <param name="minGrant"></param>
        /// <returns></returns>
        public abstract double GetGrant(double minGrant);
        /// <summary>
        /// Метод, вычисляющий средний балл студента
        /// </summary>
        /// <returns></returns>
        public double GetAverageGrade()
        {
            double gradesSum = 0;
            int gradesQuantity = 0;
            foreach(int grade in Grades)
            {
                gradesSum += grade;
                gradesQuantity++;
            }
            return gradesSum / gradesQuantity;
        }
        /// <summary>
        /// Метод, возвращающий всю информацию о студенте в виде строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string gradesStr = "";
            foreach (int grade in Grades)
            {
                gradesStr += grade + " "; 
            }
            string passOnTimeStr;
            if (PassOnTime)
            {
                passOnTimeStr = "сдал сессию вовремя";
            }
            else
            {
                passOnTimeStr = "сдал сессию не вовремя";
            }
            string typeOfStudentStr;
            if (StudentType == TypeOfStudent.Paid)
            {
                typeOfStudentStr = "платник";
            }
            else
            {
                typeOfStudentStr = "бюджетник";
            }
            return FullName + " : " + "Оценки: " + gradesStr + "; " + passOnTimeStr + "; " + typeOfStudentStr;
        }
    }
}
