using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    /// <summary>
    /// Класс студент
    /// </summary>
    public class Student : Learner
    {
        /// <summary>
        /// Группа студента
        /// </summary>
        public string Group { get; set; }
        /// <summary>
        /// Конструктор класса студент
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        /// <param name="educationalInstitution"></param>
        /// <param name="group"></param>
        /// <param name="grades"></param>
        public Student(string surname,int birthday, string educationalInstitution, string group, List<int> grades)
        {
            Surname = surname;
            EducationalInstitution = educationalInstitution;
            Group = group;
            Grades = grades;
            Birthday = birthday;
            Status = "студент";
        }
        /// <summary>
        /// Метод для вывода информации о студенте
        /// </summary>
        /// <returns></returns>
        public override string GetInformation()
        {
            return Surname + " " + Birthday + " " + Status + " " + EducationalInstitution + " " + Group + " " + Intelligence();
        }
        /// <summary>
        /// Упрощенный метод для вывода информации о студенте
        /// </summary>
        /// <returns></returns>
        public string GetLessInformation()
        {
            return Surname + " " + Group + " " + Intelligence();
        }
        /// <summary>
        /// Метод, выясняющий, двоечник ли студент
        /// </summary>
        /// <returns></returns>
        public bool CheckFlunkey()
        {
            if (Intelligence() < 5)
            {
                return true;
            }
            return false;
        }
    }
}
