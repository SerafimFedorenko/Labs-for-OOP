using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary.Tests
{
    [TestClass()]
    public class GroupTests
    {
        [TestMethod()]
        public void getAverageGradeTest()
        {
            Group group = new Group();
            List<int> grades = new List<int>() { 4, 8, 7, 9, 7 };
            Student student = StudentFabric.GetStudent(grades, true, "Иванов Иван Иванович", TypeOfStudent.State);
            group.AddStudent(student);
            grades = new List<int>() { 4, 4, 5, 5, 5 };
            student = StudentFabric.GetStudent(grades, true, "Иванов Иван Кузьмич", TypeOfStudent.State);
            group.AddStudent(student);
            grades = new List<int>() { 8, 8, 8, 9, 10 };
            student = StudentFabric.GetStudent(grades, true, "Иванов Иван Ильич", TypeOfStudent.State);
            group.AddStudent(student);
            grades = new List<int>() { 9, 10, 8, 9, 10 };
            student = StudentFabric.GetStudent(grades, false, "Иванов Иван Петрович", TypeOfStudent.State);
            group.AddStudent(student);
            grades = new List<int>() { 6, 6, 5, 5, 5 };
            student = StudentFabric.GetStudent(grades, true, "Иванов Иван Александрович", TypeOfStudent.Paid);
            group.AddStudent(student);
            double expResult = 6.96;
            Assert.AreEqual(expResult, group.GetAverageGrade(), 0.001);
        }

        [TestMethod()]
        public void GetAverageGrantTest()
        {
            Group group = new Group();
            double minGrant = 40;
            List<int> grades = new List<int>() { 4, 8, 7, 9, 7 };
            Student student = StudentFabric.GetStudent(grades, true, "Иванов Иван Иванович", TypeOfStudent.State);
            group.AddStudent(student);
            grades = new List<int>() { 4, 4, 5, 5, 5 };
            student = StudentFabric.GetStudent(grades, true, "Иванов Иван Кузьмич", TypeOfStudent.State);
            group.AddStudent(student);
            grades = new List<int>() { 8, 8, 8, 9, 10 };
            student = StudentFabric.GetStudent(grades, true, "Иванов Иван Ильич", TypeOfStudent.State);
            group.AddStudent(student);
            grades = new List<int>() { 9, 10, 8, 9, 10 };
            student = StudentFabric.GetStudent(grades,  false, "Иванов Иван Петрович", TypeOfStudent.State);
            group.AddStudent(student);
            grades = new List<int>() { 6, 6, 5, 5, 5 };
            student = StudentFabric.GetStudent(grades, true, "Иванов Иван Александрович", TypeOfStudent.Paid);
            group.AddStudent(student);
            double expResult = 27.5;
            Assert.AreEqual(expResult, group.GetAverageGrant(minGrant), 0.001);
        }
    }
}