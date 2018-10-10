using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class QuickFind : IUnionFind
    {
        private int[] id;

        public bool IsAllConnected
        {
            get
            {
                for (int i = 1; i < id.Length; i++)
                {
                    if (!Connected(id[i - 1], id[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }

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
    }
}
