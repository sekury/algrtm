using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class WeightedQuickUnionWithPathCompression : IUnionFind
    {
        private int[] id;
        private int[] sz;

        public bool IsAllConnected
        {
            get
            {
                var count = 0;
                for (int i = 0; i < id.Length; i++)
                {
                    if (id[i] == i)
                    {
                        count++;
                        if (count > 1)
                        {
                            return false;
                        }
                    }
                }
                return count == 1;
            }
        }

        public WeightedQuickUnionWithPathCompression(int n)
        {
            this.id = new int[n];
            for (var i = 0; i < n; i++)
            {
                id[i] = i;
            }
            this.sz = new int[n];
        }

        private int root(int i)
        {
            while (i != id[i])
            {
                id[i] = id[id[i]];  // path compression
                i = id[i];
            }
            return i;
        }

        public bool Connected(int p, int q) => root(p) == root(q);

        public void Union(int p, int q)
        {
            int i = root(p);
            int j = root(q);
            if (i == j) return;
            if (sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }

            if (IsAllConnected)
            {
                Console.WriteLine("All elements are connected:");
                for (int index = 0; index < id.Length; index++)
                {
                    Console.Write(index + " ");
                }
                Console.WriteLine();
                Array.ForEach(id, item =>
                {
                    Console.Write(item + " ");
                });
                Console.WriteLine();
            }
        }

        public int Find(int i)
        {
            var componentRoot = root(i);
            var elements = new List<int>();

            for (int j = 0; j < id.Length; j++)
            {
                if (root(j) == componentRoot)
                {
                    elements.Add(j);
                }
            }
            Console.WriteLine($"{{{string.Join(", ", elements)}}}");
            return elements.Max();
        }
    }
}
