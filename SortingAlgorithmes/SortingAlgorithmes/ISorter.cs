using System;
using System.Collections.Generic;

namespace SortingAlgorithmes
{
    public interface ISorter<in T> where T:IComparable<T>
    {
        void Sort(T[] array);
    }
}