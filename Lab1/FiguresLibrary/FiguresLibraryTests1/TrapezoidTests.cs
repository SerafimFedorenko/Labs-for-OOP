using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresLibrary.Tests
{
    [TestClass()]
    public class TrapezoidTests
    {
        [TestMethod()]
        public void CalcSquareTest()
        {
            Trapezoid testTrapezoid = new(3, 4);
            Assert.AreEqual(testTrapezoid.CalcSquare(), 1.249, 0.001);
        }
        [TestMethod()]
        public void CalcPerimeterTest()
        {
            Trapezoid testTrapezoid = new(3, 4);
            Assert.AreEqual(testTrapezoid.CalcPerimeter(), 4.5257, 0.001);
        }

        [TestMethod()]
        public void CalcSidesTest()
        {
            Trapezoid testTrapezoid = new(3, 4);
            double[] expectedSides = new double[4] { 1.09861228867, 1.0410811, 1.38629436112, 1 };
            for (int i = 0; i < 4; i++)
                Assert.AreEqual(testTrapezoid.CalcSides()[i], expectedSides[i], 0.001);
        }

        [TestMethod()]
        public void IsExist_True()
        {
            Trapezoid testTrapezoid = new(5, 6);
            Assert.IsTrue(testTrapezoid.IsExist());
        }

        [TestMethod()]
        public void IsExist_False()
        {
            Trapezoid testTrapezoid = new(0.5, 2);
            Assert.IsFalse(testTrapezoid.IsExist());
        }

        [TestMethod()]
        public void IsBelongsToTheBorder_False()
        {
            Trapezoid testTrapezoid = new(5, 7);
            Assert.IsFalse(testTrapezoid.IsBelongsToTheBorder(6, 1));
        }

        [TestMethod()]
        public void IsBelongsToTheBorder_True()
        {
            Trapezoid testTrapezoid = new(5, 7);
            Assert.IsTrue(testTrapezoid.IsBelongsToTheBorder(5, 1));
        }

        [TestMethod()]
        public void IsBelongsToTheFigure_False()
        {
            Trapezoid testTrapezoid = new(5, 7);
            Assert.IsFalse(testTrapezoid.IsBelongsToTheFigure(4, 1));
        }

        [TestMethod()]
        public void IsBelongsToTheFigure_True()
        {
            Trapezoid testTrapezoid = new(5, 7);
            Assert.IsTrue(testTrapezoid.IsBelongsToTheFigure(6, 1));
        }
    }
}