using System;

namespace MatrixLib
{
    public class MatrixEventArgs : EventArgs
    {
        public string Message { get; }

        public MatrixEventArgs(string message)
        {
            Message = message;
        }
    }

    public interface IVisitor
    {
        
    }

    public class UsualMatrix<T>
    {
        protected T[,] matrix;
        protected EventHandler<MatrixEventArgs> MatrixHandler = delegate {    };
        
        public int Size { get; }

        public UsualMatrix(int size)
        {
            if (size > 0)
            {
                Size = size;
                matrix = new T[size, size];
            }
            else
            {
                throw new ArgumentException(nameof(size) + " is negative");
            }
        }

        public virtual T this[int i, int j]
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
                    OnChange(matrix, new MatrixEventArgs(typeof(UsualMatrix<T>) + " element at [" + i + ", " + j + "] was change"));
                    matrix[i, j] = value;
                }
                throw new ArgumentException("index can't be negative or bigger than matrix side size");
            }
        }

        protected void OnChange(object sender, MatrixEventArgs e)
        {
            MatrixHandler(sender, e);
        }
    }
}
