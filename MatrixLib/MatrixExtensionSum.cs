using System;

namespace MatrixLib
{
    public interface MatrixSum<T>
    {
        T GetElementSum(T element1, T element2);
    }

    static class MatrixExtensionSum
    {
        public static UsualMatrix<T> SumMatrixes<T>(UsualMatrix<T> matrix1, UsualMatrix<T> matrix2, MatrixSum<T> summer)
        {
            if (matrix1.Size != matrix2.Size)
            {
                throw new ArgumentException("Both matrixes must have equal size");
            }

            if (summer != null)
            {
                throw new ArgumentNullException(nameof(summer));
            }

            UsualMatrix<T> matrix = new UsualMatrix<T>(matrix1.Size);

            for (int i = 0; i < matrix.Size; i++)
            {
                for (int j = 0; j < matrix.Size; j++)
                {
                    matrix[i, j] = summer.GetElementSum(matrix1[i, j], matrix2[i, j]);
                }
            }

            return matrix;
        }
    }
}
