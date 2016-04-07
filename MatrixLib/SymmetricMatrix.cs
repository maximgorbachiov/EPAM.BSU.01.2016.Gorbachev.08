using System;

namespace MatrixLib
{
    public class SymmetricMatrix<T> : UsualMatrix<T>
    {
        public SymmetricMatrix(int size) : base(size) {   }

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
                if (((i >= 0) && (i < Size)) && ((j >= 0) && (j < Size)))
                {
                    OnChange(matrix, new MatrixEventArgs(typeof(SymmetricMatrix<T>) + " element at [" + i + ", " + j + "] was change"));
                    matrix[i, j] = value;
                    matrix[j, i] = value;
                }
                throw new ArgumentException("index can't be negative or bigger than matrix side size");
            }
        }
    }
}
