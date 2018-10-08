namespace Algorithms
{
    public interface IUnionFind
    {
        void Union(int p, int q);

        bool Connected(int p, int q); 
    }
}