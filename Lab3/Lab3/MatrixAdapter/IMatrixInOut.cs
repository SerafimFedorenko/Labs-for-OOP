using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary;

namespace MatrixAdapter
{
    /// <summary>
    /// Интерфейс для реализации ввода и вывода маатрицы 
    /// </summary>
    public interface IMatrixInOut
    {
        /// <summary>
        /// Ввод матрицы
        /// </summary>
        /// <returns></returns>
        Matrix InputMatrix();
        /// <summary>
        /// Вывод матрицы
        /// </summary>
        /// <param name="matrix"></param>
        void OutputMatrix(Matrix matrix);
    }
}
