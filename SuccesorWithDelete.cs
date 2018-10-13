using System;
using System.Linq;

namespace Algorithms
{
    class SuccesorWithDelete
    {
        private int[] id;

        public SuccesorWithDelete(int n)
        {
            this.id = new int[n];
            for (int i = 0; i < id.Length - 1; i++)
            {
                id[i] = i + 1;
            }
            id[id.Length - 1] = id.Length - 1;
            Console.WriteLine(string.Join(", ", id));
        }

        public bool Successor(int x, out int y)
        {
            y = x;
            if (id[x] != x)
            {
                y = id[x];
                return true;
            }
            return false;
        }

        public bool Previous(int x, out int p)
        {
            p = x;
            for (int i = x - 1; i >= 0; i--)
            {
                if (id[i] == x)
                {
                    p = i;
                    return true;
                }
            }
            return false;
        }

        public void Delete(int x)
        {
            if (Previous(x, out int p))
            {
                if (Successor(x, out int y))
                {
                    id[p] = y;
                }
                else
                {
                    id[p] = p;
                }
                id[x] = x;
            }
        }
    }
}
