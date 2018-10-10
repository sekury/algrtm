using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class QuickFind : IUnionFind
    {
        private int[] id;

        public QuickFind(int n)
        {
            this.id = new int[n];
            for (var i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }

        public int Find(int i)
        {
            var component = id[i];
            var elements = new List<int>();
            for (int j = 0; j < id.Length; j++)
            {
                if (id[j] == component)
                {
                    elements.Add(j);
                }
            }
            Console.WriteLine($"{{{string.Join(", ", elements)}}}");
            return elements.Max();
        }

        public bool Connected(int p, int q)
        {
            return id[p] == id[q];
        }

        public void Union(int p, int q)
        {
            var pid = id[p];
            var qid = id[q];
            for (int i = 0; i < id.Length; i++)
            {
                if (id[i] == pid)
                {
                    id[i] = qid;
                }
            }
        }
    }
}
