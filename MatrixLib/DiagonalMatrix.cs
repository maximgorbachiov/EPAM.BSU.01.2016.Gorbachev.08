using System;

namespace MatrixLib
{
    public class DiagonalMatrix<T> : UsualMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size) {   }
       
        public override T this[int i, int j]
        {
            get
            {
                if (((i >= 0) && (i < Size)) && ((j >= 0) && (j < Size)))
                {
                    return matrix[i, j];
                }
                throw new ArgumentException("index can't be negative or bigger than matrix side size");
            }

            set
            {
                if (((i >= 0) && (i < Size)) && (i == j))
                {
                    OnChange(matrix, new MatrixEventArgs(typeof(DiagonalMatrix<T>) + " element at [" + i + ", " + j + "] was change"));
                    matrix[i, j] = value;
                }
                throw new ArgumentException("index can't be negative or bigger than matrix side size or doesn't belong to main matrix diagonal");
            }
        }
    }
}
