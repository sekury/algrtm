using System;

namespace Algorithms
{
    class WeightedQuickUnionWithPathCompression : IUnionFind
    {
        private int[] id;
        private int[] sz;

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
        }
    }
}
