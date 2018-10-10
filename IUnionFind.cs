namespace Algorithms
{
    public interface IUnionFind
    {
        bool IsAllConnected { get; }

        int Find(int i);

        void Union(int p, int q);

        bool Connected(int p, int q); 
    }
}
