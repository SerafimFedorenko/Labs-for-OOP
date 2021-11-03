using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary;

namespace MatrixAdapter
{
    public class ConsoleInOutMatrix : IMatrixInOut
    {
        public Matrix InputMatrix()
        {
            bool flag = false;
            int rows;
            int columns;
            Console.WriteLine("Введите имя матрицы");
            string name = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите количество строк матрицы");
                string rowsStr = Console.ReadLine();
                flag = Int32.TryParse(rowsStr, out rows);
                if (rows <= 0) flag = false;
            }
            while (!flag);
            do
            {
                Console.WriteLine("Введите количество столбцов матрицы");
                string columnsStr = Console.ReadLine();
                flag = Int32.TryParse(columnsStr, out columns);
                if (columns <= 0) flag = false;
            }
            while (!flag);  
            int[,] matrix = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.WriteLine($"Введите {name}[{i}][{j}]:");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Matrix matrixObject = new Matrix(matrix, name);
            return matrixObject;
        }

        public void OutputMatrix(Matrix matrix)
        {
            Console.WriteLine($"Матрица {matrix.Name}:");
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{ matrix[i, j]} ");
                }
                Console.Write("\n");
            }
        }
    }
}
