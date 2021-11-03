using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    /// <summary>
    /// Класс, реализующий матрицу целых чиселы
    /// </summary>
    public class Matrix
    {
        private int[,] _matrix;
        private string _name;
        private int _rows, _columns;
        /// <summary>
        /// Свойство содержащее количество строк матрицы
        /// </summary>
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
        /// <summary>
        /// Свойство содержащее количество столбцов матрицы
        /// </summary>
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
        /// <summary>
        /// Свойтво содержащее имя матрицы
        /// </summary>
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
        /// <summary>
        /// Индексатор класса матрица
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Конструктор, создающий пустую матрицу нулевого размера
        /// </summary>
        public Matrix()
        {
            _matrix = new int[0,0];
        }
        /// <summary>
        /// Конструктор, создающий матрицу на основе переданного двумерного массива
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="name"></param>
        public Matrix(int[,] matrix, string name)
        {
            _matrix = matrix;
            Rows = matrix.GetLength(0);
            Columns = matrix.GetLength(1);
            Name = name;
        }
        /// <summary>
        /// Конструктор, создающий пустую матрицу задаанного размера
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="name"></param>
        public Matrix(int rows, int columns, string name)
        {
            _matrix = new int[rows, columns];
            Columns = columns;
            Rows = rows;
            Name = name;
        }
        /// <summary>
        /// Метод вычисляющий среднее арифметическое отрицательных числел, повторяющихся больше раз, чем заданное число
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Метод, вычисляющий среднее арифметическое всех отрицательных числел в матрице
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Метод, возвращающий список отрицательных элементов матрицы 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Оператор поэлементного умножения матриц
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Оператор true, возвращающий true, если в матрице нет нулевых элементов
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Оператор false, возвращающий true, если в матрице есть хотя бы один нулевой элемент
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
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