using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLip.Tests
{
    [TestClass()]
    public class StudentTests
    {

        [TestMethod()]
        public void CheckFlunkeyTest()
        {
            List<int> grades = new List<int>() { 5, 2, 2, 3, 4, 1 };
            Student student = new Student("Вишняк", 2002, "ГГТУ", "ИТП-22", grades);
            Assert.AreEqual(true, student.CheckFlunkey());
            grades = new List<int>() { 5, 2, 7, 2, 10, 9 };
            student = new Student("Вишняк", 2002, "ГГТУ", "ИТП-22", grades);
            Assert.AreEqual(false, student.CheckFlunkey());
        }
        [TestMethod()]
        public void IntelligenceTest()
        {
            List<int> grades = new List<int>() { 5, 4, 5, 6, 7, 8 };
            Student student = new Student("Вишняк", 2002, "ГГТУ", "ИТП-22", grades);
            Assert.AreEqual(5.8333, student.Intelligence(), 0.001);
        }
    }
}