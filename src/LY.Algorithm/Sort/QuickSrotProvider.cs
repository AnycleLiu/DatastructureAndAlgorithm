using LY.Algorithm.Sort;
using System;

public class QuickSortProvider<T> : ISortProvider<T> where T : IComparable<T>
{
    private static void Swap(T[] arr, int i, int j)
    {
        T t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }

    private static int Partition(T[] arr, int start, int end, int idx, bool reverse = false)
    {
        if (start >= end - 1) return start;

        T val = arr[idx];
        int cur = start;
        Swap(arr, idx, end - 1);

        for (int i = start; i < end - 1; i++)
        {
            int cr = arr[i].CompareTo(val);
            if (reverse && cr > 0 || !reverse && cr < 0)
            {
                Swap(arr, cur, i);
                ++cur;
            }
        }
        Swap(arr, cur, end - 1);

        return cur;
    }

    private static void QuickSort(T[] arr, int start, int end, bool reverse = false)
    {
        if (start >= end - 1) return;

        int idx = start;
        int m = Partition(arr, start, end, idx, reverse);
        QuickSort(arr, start, m, reverse);
        QuickSort(arr, m + 1, end, reverse);
    }

    public void Sort(T[] arr)
    {
        if (arr == null) throw new ArgumentNullException(nameof(arr));
        if (arr.Length == 0) return;

        QuickSort(arr, 0, arr.Length, false);
    }

    public void Reverse(T[] arr)
    {
        if (arr == null) throw new ArgumentNullException(nameof(arr));
        if (arr.Length == 0) return;

        QuickSort(arr, 0, arr.Length, true);
    }
}
