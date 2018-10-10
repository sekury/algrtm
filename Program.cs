using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            RunQuickFind();
            RunQuickUnion();
        }

        private static void RunQuickUnion()
        {
            Console.WriteLine("Quick Union:");

            IUnionFind qu = new WeightedQuickUnionWithPathCompression(10);
            qu.Union(0, 1);
            qu.Union(1, 2);
            Console.WriteLine($"0 {(qu.Connected(1, 2) ? "is" : "is not")} connected with 2");
            Console.WriteLine($"0 {(qu.Connected(0, 9) ? "is" : "is not")} connected with 9");

            qu.Union(2, 8);
            qu.Union(9, 8);
            Console.WriteLine($"0 {(qu.Connected(0, 9) ? "is" : "is not")} connected with 9");

            qu.Union(0, 3);
            qu.Union(0, 4);
            qu.Union(2, 5);
            qu.Union(6, 9);
            qu.Union(1, 7);
        }

        private static void RunQuickFind()
        {
            Console.WriteLine("Quick Find:");

            IUnionFind qf = new QuickFind(10);
            qf.Union(0, 1);
            qf.Union(1, 2);
            Console.WriteLine($"0 {(qf.Connected(1, 2) ? "is" : "is not")} connected with 2");
            Console.WriteLine($"0 {(qf.Connected(0, 9) ? "is" : "is not")} connected with 9");

            qf.Union(2, 8);
            qf.Union(9, 8);
            Console.WriteLine($"0 {(qf.Connected(0, 9) ? "is" : "is not")} connected with 9");
        }
    }
}
