using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    /// <summary>
    /// Класс школьник
    /// </summary>
    public class Schooler : Learner
    {
        /// <summary>
        /// Номер класса школьника
        /// </summary>
        public int Group { get; set; }
        /// <summary>
        /// Конструктор класса школьник
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        /// <param name="educationalInstitution"></param>
        /// <param name="group"></param>
        /// <param name="grades"></param>
        public Schooler(string surname, int birthday, string educationalInstitution, int group, List<int> grades)
        {
            Surname = surname;
            EducationalInstitution = educationalInstitution;
            Group = group;
            Grades = grades;
            Birthday = birthday;
            Status = "школьник";
        }
        /// <summary>
        /// Метод для вывода информации о школьнике
        /// </summary>
        /// <returns></returns>
        public override string GetInformation()
        {
            return Surname + " " + Birthday + " " + Status + " " + EducationalInstitution + " " + Group + " " + Intelligence();
        }
        /// <summary>
        /// Метод, выясняющий, есть ли у школьника хотя бы две двойки
        /// </summary>
        /// <returns></returns>
        public bool CheckMoreOnlyTwo()
        {
            int quantityOfTwo = 0;
            foreach (int grade in Grades)
            {
                if (grade <= 2)
                {
                    quantityOfTwo += 1;
                }
            }
            if(quantityOfTwo > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Метод, выясняющий отличник ли школьник
        /// </summary>
        /// <returns></returns>
        public bool CheckExcellentLittleSchooler()
        {
            if (Intelligence() >= 9)
            {
                return true;
            }
            return false;
        }
    }
}
