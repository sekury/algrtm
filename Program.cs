using System;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Quick Find:");

            var qf = new QuickFind(10);
            qf.Union(0, 1);
            qf.Union(1, 2);
            Console.WriteLine($"0 {(qf.Connected(1, 2) ? "is" : "is not")} connected with 2");
            Console.WriteLine($"0 {(qf.Connected(0, 9) ? "is" : "is not")} connected with 9");

            qf.Union(2, 8);
            qf.Union(9, 8);
            Console.WriteLine($"0 {(qf.Connected(0, 9) ? "is" : "is not")} connected with 9");

            Console.WriteLine("Quick Union:");

            var qu = new WeightedQuickUnionWithPathCompression(10);
            qu.Union(0, 1);
            qu.Union(1, 2);
            Console.WriteLine($"0 {(qu.Connected(1, 2) ? "is" : "is not")} connected with 2");
            Console.WriteLine($"0 {(qu.Connected(0, 9) ? "is" : "is not")} connected with 9");

            qu.Union(2, 8);
            qu.Union(9, 8);
            Console.WriteLine($"0 {(qu.Connected(0, 9) ? "is" : "is not")} connected with 9");
        }
    }
}
