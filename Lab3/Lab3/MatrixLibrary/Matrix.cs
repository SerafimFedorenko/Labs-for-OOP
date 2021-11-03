using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Matrix
    {
        private int[,] _matrix;
        private string _name;
        private int _rows, _columns;
        public int Rows
        {
            get
            {
                return _rows;
            }
            set
            {
                _rows = value;
            }
        }
        public int Columns
        {
            get
            {
                return _columns;
            }
            set
            {
                _columns = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int this[int x, int y]
        {
            get
            {
                return _matrix[x, y];
            }
            set
            {
                _matrix[x, y] = value;
            }
        }
        public Matrix()
        {
            _matrix = new int[0,0];
        }
        public Matrix(int[,] matrix, string name)
        {
            _matrix = matrix;
            Rows = matrix.GetLength(0);
            Columns = matrix.GetLength(1);
            Name = name;
        }
        public Matrix(int rows, int columns, string name)
        {
            _matrix = new int[rows, columns];
            Columns = columns;
            Rows = rows;
            Name = name;
        }
        public double GetAverageMeanOfNegative(int n)
        {
            List<int> negativeElements = GetListOfNegativeElements();
            double sumOfNegative = 0;
            int totalQuantity = 0;
            foreach (int element in negativeElements)
            {
                int quantity = 0;
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (element == this[i, j])
                        {
                            quantity++;
                        }
                    }
                }
                if (quantity > n)
                {
                    totalQuantity += quantity;
                    sumOfNegative += element * quantity;
                }
            }
            if (totalQuantity == 0)
            {
                throw new Exception("Вычисление невозможно! " +
                $"В матрице нет отрицательных элементов повторяющихся больше{n} раз!");
            }
            return sumOfNegative / totalQuantity;
        }
        public double GetAverageMeanOfNegative()
        {
            List<int> negativeElements = GetListOfNegativeElements();
            double sumOfNegative = 0;
            int totalQuantity = 0;
            foreach (int element in negativeElements)
            {
                int quantity = 0;
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (element == this[i, j])
                        {
                            quantity++;
                        }
                    }
                }
                totalQuantity += quantity;
                sumOfNegative += element * quantity;
            }
            if (totalQuantity == 0)
            {
                throw new Exception("Вычисление невозможно! " +
                $"В матрице нет отрицательных элементов!");
            }
            return sumOfNegative / totalQuantity;
        }
        private List<int> GetListOfNegativeElements()
        {
            List<int> negativeElements = new List<int>();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (!negativeElements.Contains(this[i, j]) && this[i, j] < 0)
                    {
                        negativeElements.Add(this[i, j]);
                    }
                }
            }
            return negativeElements;
        }
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (!matrix1.IsEqual(matrix2))
            {
                throw new Exception("Умножение невозможно! " +
                "Матрицы имеют разные размерности!");
            }
            Matrix result = new Matrix(matrix1.Rows, matrix1.Columns, "NewMatrix");
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i, j] * matrix2[i, j];
                }
            }
            return result;
        }
        public static bool operator true(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if(matrix[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator false(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IsEqual(Matrix matrix)
        {
            if (Columns == matrix.Columns && Rows == matrix.Rows)
            {
                return true;
            }
            return false;
        }
    }
}