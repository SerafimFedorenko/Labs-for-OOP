using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void GetAverageMeanOfNegativeTest()
        {
            int[,] array2D = new int[,] { {-4,-4, -2}, {-2,-2,1 }, {-3,-3,-1 } };
            Matrix testMatrix = new Matrix(array2D, "TestMatrix");
            double result = testMatrix.GetAverageMeanOfNegative(1);
            Assert.AreEqual(-2.85714, result, 0.01);
        }

        [TestMethod()]
        public void MultForElemeentsTest()
        {
            int[,] array2D1 = new int[,] { { -4, -4, -2 }, { -2, -2, 1 }, { -3, 3, -1 } };
            int[,] array2D2 = new int[,] { { -3, 5, 0 }, { 2, 0, 1 }, { -3, -3, 0 } };
            int[,] expArray = new int[,] { { 12, -20, 0 }, { -4, 0, 1 }, { 9, -9, 0 } };
            Matrix matrix1 = new Matrix(array2D1, "matrix1");
            Matrix matrix2 = new Matrix(array2D2, "matrix2");
            Matrix expMatrix = new Matrix(expArray, "expMatrix");
            Matrix testMatrix = matrix1 * matrix2;
            Assert.AreEqual(expMatrix.Rows, testMatrix.Rows);
            Assert.AreEqual(expMatrix.Columns, testMatrix.Columns);
            for(int i = 0; i < testMatrix.Rows; i++)
            {
                for (int j = 0; j < testMatrix.Columns; j++)
                {
                    Assert.AreEqual(expMatrix[i, j], testMatrix[i, j]);
                }
            }
        }
        [TestMethod()]
        public void IsEqualTest()
        {
            int[,] array2D1 = new int[,] { { -4, -4, -2 }, { -2, -2, 1 }, { -3, 3, -1 } };
            int[,] array2D2 = new int[,] { { -4, -4}, { -2, -2}, { -3, 3} };
            int[,] array2D3 = new int[,] { { -3, 5, 0}, { 2, 0, 1 }, { -3, -3, 0 } };
            Matrix matrix1 = new Matrix(array2D1, "matrix1");
            Matrix matrix2 = new Matrix(array2D2, "matrix1");
            Matrix matrix3 = new Matrix(array2D3, "matrix3");
            Assert.IsTrue(matrix1.IsEqual(matrix3));
            Assert.IsFalse(matrix1.IsEqual(matrix2));
        }
        [TestMethod]
        public void OperatorTrueTest()
        {
            int[,] array2D1 = new int[,] { { -4, -4, -2 }, { -2, -2, 1 }, { -3, 3, -1 } };
            Matrix matrix1 = new Matrix(array2D1, "matrix1");
            bool flag = false;
            if (matrix1)
            {
                flag = true;
            }
            Assert.IsTrue(flag);
        }
        [TestMethod]
        public void OperatorFalseTest()
        {
            int[,] array2D1 = new int[,] { { -3, 5, 0 }, { 2, 0, 1 }, { -3, -3, 0 } };
            Matrix matrix1 = new Matrix(array2D1, "matrix1");
            bool flag = false;
            if (matrix1)
            {
                flag = true;
            }
            Assert.IsFalse(flag);
        }
    }
}