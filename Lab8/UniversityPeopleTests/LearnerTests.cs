using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleLip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleLip.Tests
{
    [TestClass()]
    public class LearnerTests
    {
        [TestMethod()]
        public void IntelligenceTest()
        {
            List<int> grades = new List<int>() { 5, 4, 5, 6, 7, 8 };
            Student student = new Student("Вишняк", 2002, "ГГТУ", "ИТП-22", grades);
            Assert.AreEqual(5.8333, student.Intelligence(), 0.001);
        }
    }
}