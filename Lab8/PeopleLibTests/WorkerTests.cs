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
    public class WorkerTests
    {

        [TestMethod()]
        public void IntelligenceTest()
        {
            int[] salaries = new int[12] { 337, 440, 431, 312, 567, 315, 764, 653, 654, 231, 432, 764 };
            Worker worker = new Worker("Иванович", 2000, "Электрик","ГГТУ",salaries);
            Assert.AreEqual(764, worker.Intelligence());
        }
    }
}