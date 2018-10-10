namespace Algorithms
{
    public interface IUnionFind
    {
        int Find(int i);
        
        void Union(int p, int q);

        bool Connected(int p, int q); 
    }
}
