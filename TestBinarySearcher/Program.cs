using System;
using System.Collections.Generic;
using BinarySearcherLib;

namespace TestBinarySearcher
{
    class Program
    {
        class Comparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x == y)
                {
                    return 0;
                }

                return (x > y) ? 1 : -1;
            }
        }

        class ComparerString : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                int value1 = int.Parse(x);
                int value2 = int.Parse(y);

                if (value1 == value2)
                {
                    return 0;
                }

                return (value1 > value2) ? 1 : -1;
            }
        }

        class ComparerBook : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                if (x.CountOfPages == y.CountOfPages)
                {
                    return 0;
                }

                return (x.CountOfPages > y.CountOfPages) ? 1 : -1;
            }
        }

        class ComparerPoint : IComparer<Point>
        {
            public int Compare(Point x, Point y)
            {
                if (x.X == y.X)
                {
                    return 0;
                }

                return (x.X > y.X) ? 1 : -1;
            }
        }

        public class Book : IComparable
        {
            public string Title { get; }
            public int CountOfPages { get; }

            public Book(string title, int countOfPages)
            {
                Title = title;
                CountOfPages = countOfPages;
            }

            public int CompareTo(object other)
            {
                Book book = (Book)other;

                if (CountOfPages == book.CountOfPages)
                {
                    return 0;
                }

                if (CountOfPages < book.CountOfPages)
                {
                    return -1;
                }

                return 1;
            }
        }

        public struct Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        static void Main(string[] args)
        {
            BinarySearchTree<int> tree = new BinarySearchTree<int>(10, new Comparer());

            tree.Add(5);
            tree.Add(3);
            tree.Add(7);
            tree.Add(1);
            tree.Add(4);
            tree.Add(9);
            tree.Add(6);
            tree.Add(15);
            tree.Add(25);
            tree.Add(11);

            foreach (var key in tree.GetPreOrder())
            {
                Console.WriteLine(key);   
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            BinarySearchTree<int> tree1 = new BinarySearchTree<int>(10);

            tree1.Add(5);
            tree1.Add(3);
            tree1.Add(7);
            tree1.Add(1);
            tree1.Add(4);
            tree1.Add(9);
            tree1.Add(6);
            tree1.Add(15);
            tree1.Add(25);
            tree1.Add(11);

            foreach (var key in tree1.GetPreOrder())
            {
                Console.WriteLine(key);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            BinarySearchTree<string> treeString1 = new BinarySearchTree<string>("10", new ComparerString());

            treeString1.Add("5");
            treeString1.Add("3");
            treeString1.Add("7");
            treeString1.Add("1");
            treeString1.Add("4");
            treeString1.Add("9");
            treeString1.Add("6");
            treeString1.Add("15");
            treeString1.Add("25");
            treeString1.Add("11");

            foreach (var key in treeString1.GetPreOrder())
            {
                Console.WriteLine(key);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            BinarySearchTree<string> treeString2 = new BinarySearchTree<string>("10");

            treeString2.Add("5");
            treeString2.Add("3");
            treeString2.Add("7");
            treeString2.Add("1");
            treeString2.Add("4");
            treeString2.Add("9");
            treeString2.Add("6");
            treeString2.Add("15");
            treeString2.Add("25");
            treeString2.Add("11");

            foreach (var key in treeString2.GetPreOrder())
            {
                Console.WriteLine(key);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            BinarySearchTree<Book> treeBook1 = new BinarySearchTree<Book>(new Book("Richter", 800), new ComparerBook());

            treeBook1.Add(new Book("Richter", 801));
            treeBook1.Add(new Book("Richter1", 80));
            treeBook1.Add(new Book("Richter2", 70));
            treeBook1.Add(new Book("Richter3", 500));
            treeBook1.Add(new Book("Richter4", 900));
            treeBook1.Add(new Book("Richter5", 1000));
            treeBook1.Add(new Book("Richter6", 850));
            treeBook1.Add(new Book("Richter7", 1100));
            treeBook1.Add(new Book("Richter8", 700));

            foreach (var key in treeBook1.GetPreOrder())
            {
                Console.WriteLine(key.CountOfPages);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            BinarySearchTree<Book> treeBook2 = new BinarySearchTree<Book>(new Book("Richter", 800));

            treeBook2.Add(new Book("Richter1", 801));
            treeBook2.Add(new Book("Richter2", 80));
            treeBook2.Add(new Book("Richter3", 70));
            treeBook2.Add(new Book("Richter4", 500));
            treeBook2.Add(new Book("Richter5", 900));
            treeBook2.Add(new Book("Richter6", 1000));
            treeBook2.Add(new Book("Richter7", 850));
            treeBook2.Add(new Book("Richter8", 1100));
            treeBook2.Add(new Book("Richter9", 700));

            foreach (var key in treeBook2.GetPreOrder())
            {
                Console.WriteLine(key.CountOfPages);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            BinarySearchTree<Point> treePoint = new BinarySearchTree<Point>(new Point(800, 800), new ComparerPoint());

            treePoint.Add(new Point(80, 800));
            treePoint.Add(new Point(700, 800));
            treePoint.Add(new Point(40, 800));
            treePoint.Add(new Point(100, 800));
            treePoint.Add(new Point(810, 800));
            treePoint.Add(new Point(1000, 800));
            treePoint.Add(new Point(900, 800));
            treePoint.Add(new Point(1100, 800));
            treePoint.Add(new Point(8200, 800));

            foreach (var key in treePoint.GetPreOrder())
            {
                Console.WriteLine(key.X);
            }

            Console.ReadLine();
        }
    }
}
