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
    public class SchoolerTests
    {
        [TestMethod()]
        public void CheckMoreOnlyTwoTest()
        {
            List<int> grades = new List<int>() { 9, 10, 8, 10, 10, 10 };
            Schooler schooler = new Schooler("Шух", 2002, "СШ №1 г. Жлобина", 2, grades);
            Assert.AreEqual(false, schooler.CheckMoreOnlyTwo());
            grades = new List<int>() { 1, 2, 8, 10, 10, 10 };
            schooler = new Schooler("Шух", 2002, "СШ №1 г. Жлобина", 2, grades);
            Assert.AreEqual(true, schooler.CheckMoreOnlyTwo());
        }

        [TestMethod()]
        public void CheckExcellentLittleSchoolerTest()
        {
            List<int> grades = new List<int>() { 9, 10, 8, 10, 10, 10 };
            Schooler schooler = new Schooler("Шух", 2002, "СШ №1 г. Жлобина", 2, grades);
            Assert.AreEqual(true, schooler.CheckExcellentLittleSchooler());
            grades = new List<int>() { 9, 8, 10, 8, 8, 8 };
            schooler = new Schooler("Шух", 2002, "СШ №1 г. Жлобина", 2, grades);
            Assert.AreEqual(false, schooler.CheckExcellentLittleSchooler());
        }
        [TestMethod()]
        public void IntelligenceTest()
        {
            List<int> grades = new List<int>() { 5, 4, 5, 6, 7, 8 };
            Schooler student = new Schooler("Вишняк", 2002, "ГГТУ", 2, grades);
            Assert.AreEqual(5.8333, student.Intelligence(), 0.001);
        }
    }
}