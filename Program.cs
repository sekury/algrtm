using System;
using System.Linq;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            RunQuickFind();
            RunQuickUnion();
            RunSuccessWithDelete();
        }

        private static void RunSuccessWithDelete()
        {
            var swd = new SuccesorWithDelete(10);
            PrintSuccessorWithDeleteState(swd);
            swd.Delete(0);
            PrintSuccessorWithDeleteState(swd);
            swd.Delete(4);
            PrintSuccessorWithDeleteState(swd);
            swd.Delete(5);
            PrintSuccessorWithDeleteState(swd);
            swd.Delete(9);
            PrintSuccessorWithDeleteState(swd);
        }

        private static void PrintSuccessorWithDeleteState(SuccesorWithDelete swd)
        {
            Console.WriteLine("Succesors:");
            Array.ForEach(Enumerable.Range(0, 10).ToArray(), (x) =>
            {
                if (swd.Successor(x, out int y))
                {
                    Console.WriteLine($"Succesor of {x} is {y}");
                }
            });
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

            Console.WriteLine($"Max element for component containg 2 is {qu.Find(2)}");
            Console.WriteLine($"Max element for component containg 3 is {qu.Find(3)}");

            qu.Union(0, 3);
            qu.Union(0, 4);
            qu.Union(2, 5);
            qu.Union(6, 9);
            qu.Union(1, 7);

            Console.WriteLine($"Max element for component containg 3 is {qu.Find(3)}");
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

            Console.WriteLine($"Max element for component containg 2 is {qf.Find(2)}");
            Console.WriteLine($"Max element for component containg 3 is {qf.Find(3)}");

            qf.Union(0, 3);
            qf.Union(0, 4);
            qf.Union(2, 5);
            qf.Union(6, 9);
            qf.Union(1, 7);
        }
    }
}
