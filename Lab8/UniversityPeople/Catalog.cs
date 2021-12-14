using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLib
{
    /// <summary>
    /// Класс содержащий список людей и методы над ним
    /// </summary>
    public class Catalog
    {
        /// <summary>
        /// Список людей
        /// </summary>
        public List<Human> People = new List<Human>();
        /// <summary>
        /// Метод, возвращающий отсортированный по алфавиту список работающих
        /// </summary>
        /// <returns></returns>
        public List<Worker> GetWorkersSorted()
        {
            List<Worker> workersList = new List<Worker>();
            foreach (Human human in People)
            {
                if(human is Worker)
                {

                    workersList.Add((Worker)human);
                }
            }
            Worker[] workersArr = workersList.ToArray();
            Array.Sort(workersArr);
            return workersArr.ToList();
        }
        /// <summary>
        /// Метод, возвращающий список школьников с больше чем двумя двойками
        /// </summary>
        /// <returns></returns>
        public List<Schooler> GetMoreOnlyTwoSchoolers()
        {
            List<Schooler> moreOnlyTwoSchoolers = new List<Schooler>();
            foreach (Human human in People)
            {
                if(human is Schooler)
                {
                    Schooler schooler = (Schooler)human;
                    if(schooler.CheckMoreOnlyTwo())
                    {
                        moreOnlyTwoSchoolers.Add(schooler);
                    }
                }
            }
            return moreOnlyTwoSchoolers;
        }
        /// <summary>
        /// Метод, возвращающий двоечников в определённом универе
        /// </summary>
        /// <param name="uni">Универ, в котором ищутся двоечники</param>
        /// <returns></returns>
        public List<Student> GetFlunkeysInUni(string uni)
        {
            List<Student> flunkeysInUni = new List<Student>();
            foreach (Human human in People)
            {
                if(human is Student)
                {
                    Student student = (Student)human;
                    if (student.CheckFlunkey() && student.EducationalInstitution == uni)
                    {
                        flunkeysInUni.Add(student);
                    }
                }
            }
            return flunkeysInUni;
        }
        /// <summary>
        /// Метод, добавляющий человека в список людей
        /// </summary>
        /// <param name="human"></param>
        public void Add(Human human)
        {
            People.Add(human);
        }
    }
}