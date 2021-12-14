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
    public class StudentTests
    {
        [DataTestMethod()]
        [DataRow(7, true, 4, 8, 7, 9, 7)]
        [DataRow(4.6, false, 4, 4, 5, 5, 5)]
        [DataRow(8.6, true, 8, 8, 8, 9, 10)]
        [DataRow(9.2, true, 9, 10, 8, 9, 10)]
        [DataRow(5.4, true, 6, 6, 5, 5, 5)]
        public void GetAverageGradeTest(double expResult, bool passOnTime, params int[] gradesArr)
        {
            List<int> grades = gradesArr.ToList();
            Student student = StudentFabric.GetStudent(grades, passOnTime, "Иванов Иван Иванович", TypeOfStudent.State);
            Assert.AreEqual(expResult, student.GetAverageGrade());
            student = StudentFabric.GetStudent(grades, passOnTime, "Иванов Иван Иванович", TypeOfStudent.Paid);
            Assert.AreEqual(expResult, student.GetAverageGrade());
        }
    }
}