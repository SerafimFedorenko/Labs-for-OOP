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
    public class StateStudentTests
    {
        [DataTestMethod()]
        [DataRow(55, true, 44, 4, 8, 7, 9, 7)]
        [DataRow(50, true, 40, 4, 8, 7, 9, 7)]
        [DataRow(60, true, 40, 9, 8, 9, 8, 10)]
        [DataRow(40, true, 40, 5, 5, 5, 6, 6)]
        [DataRow(0, false, 44, 4, 8, 7, 9, 7)]
        [DataRow(0, true, 44, 4, 4, 4, 5, 5)]
        [DataRow(0, false, 44, 4, 4, 4, 5, 5)]
        public void GetGrantTest(double expResult, bool passOnTime, double minGrant, params int[] gradesArr)
        {
            List<int> grades = gradesArr.ToList();
            Student student = StudentFabric.GetStudent(grades, passOnTime, "Иванов Иван Иванович", TypeOfStudent.State);
            Assert.AreEqual(expResult, student.GetGrant(minGrant));
        }
    }
}