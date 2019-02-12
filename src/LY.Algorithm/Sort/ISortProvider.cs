using System;

namespace LY.Algorithm.Sort
{
    public interface ISortProvider<T> where T : IComparable<T>
    {
        void Sort(T[] arr);

        void Reverse(T[] arr);
    }
}
