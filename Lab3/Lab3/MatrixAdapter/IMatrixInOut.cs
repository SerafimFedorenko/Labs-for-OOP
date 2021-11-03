using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary;

namespace MatrixAdapter
{
    public interface IMatrixInOut
    {
        Matrix InputMatrix();
        void OutputMatrix(Matrix matrix);
    }
}
