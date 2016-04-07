using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearcherLib
{
    public class BinarySearchTree<T>
    {
        private IComparer<T> comparer;
        private T key;
        private BinarySearchTree<T> rightNode;
        private BinarySearchTree<T> leftNode; 

        public BinarySearchTree(T root, IComparer<T> comparer = null)
        {
            key = root;

            if (comparer != null)
            {
                this.comparer = comparer;
            }
            else
            {
                if ((typeof(T).GetInterface("IComparable") != null) || (typeof(T).GetInterface("IComparable `1") != null))
                {
                    this.comparer = Comparer<T>.Default;
                }
                else
                {
                    throw new ArgumentNullException(nameof(comparer));
                }
            }
        }

        public void Add(T element)
        {
            int compareResult = comparer.Compare(element, key);

            if (compareResult == 0)
            {
                throw new ArgumentException("This key is exist");
            }

            if (compareResult > 0)
            {
                AddNode(ref rightNode, element);
            }
            else
            {
                AddNode(ref leftNode, element);
            }            
        }

        public BinarySearchTree<T> Search(T element)
        {
            int compareResult = comparer.Compare(element, key);

            if (compareResult == 0)
            {
                return this;
            }

            return (compareResult > 0) ? rightNode.Search(element) : leftNode.Search(element);
        }

        public IEnumerable<T> GetPreOrder()
        {
            yield return key;

            if (leftNode != null)
            {
                foreach (var keyValue in leftNode.GetPreOrder())
                {
                    yield return keyValue;
                }
            }

            if (rightNode != null)
            {
                foreach (var keyValue in rightNode.GetPreOrder())
                {
                    yield return keyValue;
                }
            }
        }

        public IEnumerable<T> GetInOrder()
        {
            if (leftNode != null)
            {
                foreach (var keyValue in leftNode.GetInOrder())
                {
                    yield return keyValue;
                }
            }

            yield return key;

            if (rightNode != null)
            {
                foreach (var keyValue in rightNode.GetInOrder())
                {
                    yield return keyValue;
                }
            }
        }

        public IEnumerable<T> GetPostOrder()
        {
            if (leftNode != null)
            {
                foreach (var keyValue in leftNode.GetPostOrder())
                {
                    yield return keyValue;
                }
            }

            if (rightNode != null)
            {
                foreach (var keyValue in rightNode.GetPostOrder())
                {
                    yield return keyValue;
                }
            }

            yield return key;
        }

        private void AddNode(ref BinarySearchTree<T> tempNode, T element)
        {
            if (tempNode == null)
            {
                tempNode = new BinarySearchTree<T>(element, comparer);
            }
            else
            {
                tempNode.Add(element);
            }
        }
    }
}
